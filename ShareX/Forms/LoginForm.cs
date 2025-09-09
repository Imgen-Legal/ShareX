using Newtonsoft.Json;
using ShareX.HelpersLib;
using System;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShareX.Forms
{
    public partial class LoginForm : Form
    {
        private readonly string DirectusBaseUrl = ConfigurationManager.AppSettings["DirectusBaseUrl"];
        private const string LOGIN_ENDPOINT = "/auth/login";

        public string UserEmail { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            this.Icon = ShareXResources.Icon;

            NativeMethods.UseImmersiveDarkMode(this.Handle, ShareXResources.IsDarkTheme);
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please, enter Email and Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnLogin.Enabled = false;
            btnLogin.Text = "Entering...";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var loginData = new { email = email, password = password };
                    string json = JsonConvert.SerializeObject(loginData);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync($"{DirectusBaseUrl}{LOGIN_ENDPOINT}", content);

                    await HandleLoginResponseAsync(response, email);
                }
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Failed to connect to the Directus server. Check your internet connection or URL.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "Login";
            }
        }

        private async Task HandleLoginResponseAsync(HttpResponseMessage response, string email)
        {
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var loginResponse = JsonConvert.DeserializeObject<DirectusLoginResponse>(responseBody);

                string accessToken = loginResponse.Data.AccessToken;
                string refreshToken = loginResponse.Data.RefreshToken;

                SessionManager.AccessToken = accessToken;
                SessionManager.RefreshToken = refreshToken;
                SessionManager.UserEmail = email;

                TokenManager.SaveTokens(accessToken, refreshToken, email);

                SessionManager.UserEmail = email;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var errorResponse = JsonConvert.DeserializeObject<DirectusErrorResponse>(responseBody);
                string errorMessage = errorResponse.Errors[0].Message;

                if (errorMessage == "Invalid user credentials.")
                {
                    MessageBox.Show("Invalid user credentials.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"An error occurred: {errorMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}