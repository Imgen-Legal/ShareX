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
        private const string ME_ENDPOINT = "/users/me";

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

        private void pictureBoxShowPassword_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;

            if (txtPassword.UseSystemPasswordChar)
            {
                pictureBoxShowPassword.Image = global::ShareX.Properties.Resources.eye_hidden;
            }
            else
            {
                pictureBoxShowPassword.Image = global::ShareX.Properties.Resources.eye;
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

                string userId = null;
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Authorization =
                            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                        HttpResponseMessage userMeResponse = await client.GetAsync($"{DirectusBaseUrl}{ME_ENDPOINT}");

                        if (userMeResponse.IsSuccessStatusCode)
                        {
                            string userMeBody = await userMeResponse.Content.ReadAsStringAsync();
                            var userMe = JsonConvert.DeserializeObject<DirectusUserMeResponse>(userMeBody);

                            userId = userMe.Data.Id;
                            loginResponse.UserId = userId;
                        }
                        else
                        {
                            MessageBox.Show("Login successful, but failed to fetch user ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (HttpRequestException)
                {
                    MessageBox.Show("Login successful, but failed to connect to the Directus server to fetch user ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                SessionManager.AccessToken = accessToken;
                SessionManager.RefreshToken = refreshToken;
                SessionManager.UserEmail = email;
                SessionManager.UserId = userId;
                Program.UploadersConfig.DirectusAccessToken = accessToken;
                Program.UploadersConfig.DirectusSessionUser = userId;

                TokenManager.SaveTokens(accessToken, refreshToken, email, userId);

                SessionManager.UserEmail = email;
                SessionManager.UserId = userId;

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