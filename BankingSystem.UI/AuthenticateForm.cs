using BankingSystem.Common.Contracts.Requests;
using BankingSystem.UI.Extensions;
using BankingSystem.UI.Http;
using BankingSystem.UI.Models;
using System;

namespace BankingSystem.UI
{
    public partial class AuthenticateForm : Form
    {
        private readonly BankingSystemApi _api;
        public AuthenticateForm()
        {
            InitializeComponent();

            _api = new BankingSystemApi();
        }

        private async void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                AuthResponse? result = null;
                if(loginCheckBox.Checked)
                {
                    result = await _api.LoginAsync(new LoginRequest
                    {
                        Username = usernameTextBox.Text,
                        Password = passwordTextBox.Text,
                    });
                }
                else
                {
                    result = await _api.RegisterAsync(new RegistrationRequest
                    {
                        Username = usernameTextBox.Text,
                        Password = passwordTextBox.Text,
                    });
                }

                if (result.Success == false)
                {
                    MessageBox.Show(result.Failure.ErrorMessages.BuildErrorMessage(),
                        "Bad request",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                var mainForm = new MainForm(result.SuccessObject);
                mainForm.ShowDialog();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}