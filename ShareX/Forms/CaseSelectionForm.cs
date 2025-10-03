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
        public DirectusCase SelectedCase { get; private set; }
        public List<DirectusPatient> SelectedPatients { get; private set; }

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
            searchComboBox.Font = new Font(searchComboBox.Font.FontFamily, 12F, FontStyle.Regular); // Increased font size inside dropdown/textbox
            searchComboBox.BackColor = Color.FromArgb(60, 60, 60);
            searchComboBox.ForeColor = Color.White;
            searchComboBox.FlatStyle = FlatStyle.Flat;

            searchComboBox.SelectedIndexChanged += SearchComboBox_SelectedIndexChanged;

            btnSearch.Click += btnSearch_Click;
            btnOk.Click += btnOk_Click;
            btnCancel.Click += (sender, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            btnRedirect.Click += BtnRedirect_Click;

            NativeMethods.UseImmersiveDarkMode(this.Handle, ShareXResources.IsDarkTheme);

            FilterItems(true);
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

            try
            {
                var caseId = SelectedCase.Id;
                var patientId = SelectedPatients.First().Id;

                string fullUrl = $"{PresentationBuilderUrl}/{caseId}?selectedPatient=\"{patientId}\"";
                Program.UploadersConfig.DirectusSessionPatientId = patientId;
                Program.UploadersConfig.DirectusSessionMetadata = "test";

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
                    var url = $"{DirectusBaseUrl}/items/patient?fields=*,case_id.*&{filterQuery}&limit={dropdownLimit}";

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
            string patientFullName = $"{model.PatientName} {model.PatientLastName}";
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
            string currentSearchText = searchComboBox.Text;
            try
            {
                var searchText = currentSearchText?.Trim() ?? "";

                searchComboBox.SelectedIndex = -1;
                SelectedCase = null;
                SelectedPatients = null;

                var filterQueries = new List<string>();
                filterQueries.Add("filter[case_id][_nnull]=true");

                if (!string.IsNullOrEmpty(searchText))
                {
                    var searchTerms = searchText.ToLowerInvariant();
                    var encodedSearchTerms = Uri.EscapeDataString(searchTerms);
                    var orConditions = new List<string>();
                    int index = 0;

                    var words = searchText.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string firstWord = words.Length > 0 ? Uri.EscapeDataString(words[0].ToLowerInvariant()) : "";
                    string secondWord = words.Length > 1 ? Uri.EscapeDataString(words[1].ToLowerInvariant()) : "";

                    orConditions.Add($"filter[_or][{index++}][case_id][name][_icontains]={encodedSearchTerms}");

                    if (words.Length > 1)
                    {
                        orConditions.Add($"filter[_or][{index++}][_and][0][first_name][_icontains]={firstWord}");
                        orConditions.Add($"filter[_or][{index - 1}][_and][1][last_name][_icontains]={secondWord}");

                        orConditions.Add($"filter[_or][{index++}][_and][0][first_name][_icontains]={secondWord}");
                        orConditions.Add($"filter[_or][{index - 1}][_and][1][last_name][_icontains]={firstWord}");
                    }

                    orConditions.Add($"filter[_or][{index++}][first_name][_icontains]={encodedSearchTerms}");
                    orConditions.Add($"filter[_or][{index++}][last_name][_icontains]={encodedSearchTerms}");

                    filterQueries.Add(string.Join("&", orConditions));
                }

                var combinedFilterQuery = string.Join("&", filterQueries.Select(q => q.Replace("[", "%5B").Replace("]", "%5D")));

                var displayModels = await LoadItemsAsync(combinedFilterQuery);

                searchComboBox.DataSource = null;

                var dataSourceList = displayModels.Select(m => new
                {
                    FormattedName = FormatDisplayModel(m),
                    OriginalData = m
                }).ToList();

                searchComboBox.DisplayMember = "FormattedName";
                searchComboBox.ValueMember = "OriginalData";

                searchComboBox.DataSource = dataSourceList;

                searchComboBox.SelectedIndex = -1;
                SelectedCase = null;
                SelectedPatients = new List<DirectusPatient>();

                searchComboBox.Text = currentSearchText;

                if (displayModels.Count > 0 && !initialLoad)
                {
                    searchComboBox.DroppedDown = true;
                }
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
    }
}
