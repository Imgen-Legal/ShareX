using Newtonsoft.Json;
using ShareX.HelpersLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing;
using System.Configuration;

namespace ShareX.Forms
{
    public partial class CaseSelectionForm : Form
    {
        public CaseSelectionForm(DirectusCase currentCase = null, List<DirectusPatient> currentPatients = null) : this()
        {
            var currentPatient = currentPatients?.FirstOrDefault();
            _previousPatient = currentPatient;
            _lastConfirmedPatientId = currentPatient?.Id;
            SelectedCase = currentCase;
            SelectedPatients = currentPatients ?? new List<DirectusPatient>();
        }

        public DirectusCase SelectedCase { get; private set; }
        public List<DirectusPatient> SelectedPatients { get; private set; }

        private string _lastConfirmedPatientId = null;

        private DirectusPatient _previousPatient = null;

        private static readonly string RedirectUrl = ConfigurationManager.AppSettings["RedirectUrl"];
        private static readonly string PresentationBuilderUrl = ConfigurationManager.AppSettings["PlatformBaseUrl"] + "/presentation-builder";

        private const int dropdownLimit = 100;

        public CaseSelectionForm()
        {
            InitializeComponent();
            this.Text = "Select Case/Patient";
            this.Icon = ShareXResources.Icon;

            this.Font = new Font(this.Font.FontFamily, 10F);

            searchComboBox.DropDownStyle = ComboBoxStyle.DropDown;
            searchComboBox.AutoCompleteMode = AutoCompleteMode.None;
            searchComboBox.AutoCompleteSource = AutoCompleteSource.None;
            searchComboBox.DropDownHeight = 400;
            searchComboBox.Font = new Font(searchComboBox.Font.FontFamily, 12F, FontStyle.Regular);
            searchComboBox.BackColor = Color.FromArgb(60, 60, 60);
            searchComboBox.ForeColor = Color.White;
            searchComboBox.FlatStyle = FlatStyle.Flat;

            searchComboBox.SelectedIndexChanged += SearchComboBox_SelectedIndexChanged;

            btnSearch.Click += btnSearch_Click;
            btnOk.Click += btnOk_Click;
            btnCancel.Click += (sender, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            btnRedirect.Click += BtnRedirect_Click;

            NativeMethods.UseImmersiveDarkMode(this.Handle, ShareXResources.IsDarkTheme);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FilterItems(false);
        }

        private void SearchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            object selectedItem = searchComboBox.SelectedItem;

            if (selectedItem != null)
            {
                PropertyInfo originalDataProp = selectedItem.GetType().GetProperty("OriginalData");
                if (originalDataProp != null)
                {
                    CaseDisplayModel selectedDisplayModel = originalDataProp.GetValue(selectedItem, null) as CaseDisplayModel;

                    if (selectedDisplayModel != null)
                    {
                        SelectedCase = selectedDisplayModel.OriginalCase;
                        SelectedPatients = new List<DirectusPatient> { selectedDisplayModel.OriginalPatient };
                        return;
                    }
                }
            }

            SelectedCase = null;
            SelectedPatients = new List<DirectusPatient>();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (searchComboBox.SelectedIndex == -1 || SelectedCase == null || SelectedPatients == null || SelectedPatients.Count == 0)
            {
                MessageBox.Show("Please select a case/patient from the dropdown list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var currentPatientId = SelectedPatients.First().Id;
            var selectedCaseId = SelectedCase.Id;

            if (!string.IsNullOrEmpty(_lastConfirmedPatientId) && currentPatientId != _lastConfirmedPatientId && Program.MainForm != null)
            {
                var result = MessageBox.Show(
                    "All unsaved screenshots of the previous case will be removed. \nDo you want to continue?",
                    "Confirm patient change",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    return;
                }

                CleanUpTasks();
            }

            if (SelectedCase != null && SelectedPatients.Any())
            {
                _lastConfirmedPatientId = currentPatientId;
                _previousPatient = SelectedPatients.First();
                try
                {
                    if (Program.UploadersConfig != null)
                    {
                        Program.UploadersConfig.DirectusSessionPatientId = currentPatientId;
                        Program.UploadersConfig.DirectusSessionCaseId = selectedCaseId;
                    }
                }
                catch { /* ignore */ }
            }

            try
            {
                var caseId = SelectedCase.Id;
                var patientId = currentPatientId;

                string fullUrl = $"{PresentationBuilderUrl}/{caseId}?selectedPatient=\"{patientId}\"";
                Program.UploadersConfig.DirectusSessionPatientId = patientId;
                Program.UploadersConfig.DirectusSessionCaseId = selectedCaseId;

                Process.Start(new ProcessStartInfo(fullUrl) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Successfully selected case, but could not open Presentation Builder link: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnRedirect_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo(RedirectUrl) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not open URL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static readonly string DirectusBaseUrl = ConfigurationManager.AppSettings["DirectusBaseUrl"];


        private async Task<List<CaseDisplayModel>> LoadItemsAsync(string filterQuery)
        {
            try
            {
                this.Text = "Loading data...";
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", SessionManager.AccessToken);

                    var statusFilter = "&filter[case_id][status][_in]=Created,In%20progress,Done";

                    var sortQuery = "&sort=case_id.name,last_name";

                    var url = $"{DirectusBaseUrl}/items/patient?fields=*,case_id.*&{filterQuery}{statusFilter}{sortQuery}&limit={dropdownLimit}";

                    var response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    var json = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<DirectusPatientResponse>(json);

                    var patients = result.Data;

                    var displayModels = patients
                        .Where(p => p.Case != null)
                        .Select(p => new CaseDisplayModel
                        {
                            CaseId = p.Case?.Id,
                            CaseName = p.Case?.Name,
                            Status = p.Case?.Status,
                            PatientName = p.FirstName,
                            PatientLastName = p.LastName,
                            PatientMiddleName = p.MiddleName,
                            OriginalCase = p.Case,
                            OriginalPatient = p
                        }).ToList();

                    this.Text = "Select case/patient";
                    return displayModels;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return new List<CaseDisplayModel>();
            }
        }

        private string FormatDisplayModel(CaseDisplayModel model)
        {
            string patientFullName = $"{model.PatientLastName} {model.PatientName} {model.PatientMiddleName}";
            if (!string.IsNullOrEmpty(model.CaseName))
            {
                return $"{model.CaseName} - {patientFullName}";
            }
            else
            {
                return patientFullName;
            }
        }

        private async void FilterItems(bool initialLoad)
        {
            if (initialLoad)
            {
                searchComboBox.Focus();
                return;
            }

            string currentSearchText = searchComboBox.Text;
            try
            {
                var searchText = currentSearchText?.Trim() ?? "";

                searchComboBox.SelectedIndex = -1;
                SelectedCase = null;
                SelectedPatients = null;

                var filterQueries = new List<string> { "filter[case_id][_nnull]=true" };

                if (!string.IsNullOrEmpty(searchText))
                {
                    var words = searchText
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(w => Uri.EscapeDataString(w.ToLowerInvariant()))
                        .ToArray();

                    var andConditions = new List<string>();

                    for (int i = 0; i < words.Length; i++)
                    {
                        string word = words[i];
                        string orCondition = string.Join("&", new[]
                        {
                            $"filter[_and][{i}][_or][0][first_name][_icontains]={word}",
                            $"filter[_and][{i}][_or][1][middle_name][_icontains]={word}",
                            $"filter[_and][{i}][_or][2][last_name][_icontains]={word}",
                            $"filter[_and][{i}][_or][3][case_id][name][_icontains]={word}"
                        });

                        andConditions.Add(orCondition);
                    }

                    filterQueries.Add(string.Join("&", andConditions));
                }

                string combinedFilterQuery = string.Join("&", filterQueries.Select(q => q.Replace("[", "%5B").Replace("]", "%5D")));

                var displayModels = await LoadItemsAsync(combinedFilterQuery);

                var dataSourceList = displayModels.Select(m => new
                {
                    FormattedName = FormatDisplayModel(m),
                    OriginalData = m
                }).ToList();

                searchComboBox.DataSource = null;
                searchComboBox.DisplayMember = "FormattedName";
                searchComboBox.ValueMember = "OriginalData";
                searchComboBox.DataSource = dataSourceList;

                searchComboBox.SelectedIndex = -1;
                SelectedCase = null;
                SelectedPatients = new List<DirectusPatient>();
                searchComboBox.Text = currentSearchText;

                try
                {
                    if (Program.UploadersConfig != null &&
                        !string.IsNullOrEmpty(Program.UploadersConfig.DirectusSessionPatientId))
                    {
                        var sessPatientId = Program.UploadersConfig.DirectusSessionPatientId;
                        var match = dataSourceList
                            .Select(x => x.OriginalData as CaseDisplayModel)
                            .FirstOrDefault(m => m?.OriginalPatient?.Id == sessPatientId);

                        if (match != null)
                        {
                            _lastConfirmedPatientId = match.OriginalPatient?.Id;
                            _previousPatient = match.OriginalPatient;
                        }
                    }
                }
                catch
                {
                    // ignore
                }

                if (displayModels.Count > 0 && !initialLoad)
                    searchComboBox.DroppedDown = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Search error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                searchComboBox.Focus();
            }
        }


        private void CleanUpTasks()
        {
            Program.MainForm.ClearTasksList();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
