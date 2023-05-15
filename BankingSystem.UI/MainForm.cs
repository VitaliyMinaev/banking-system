using BankingSystem.Common.Contracts.Requests;
using BankingSystem.Common.Contracts.Responses;
using BankingSystem.UI.Http;
using System;

namespace BankingSystem.UI
{
    public partial class MainForm : Form
    {
        private readonly BankingSystemApi _api;
        private readonly string _jwt;
        public MainForm()
        {
            InitializeComponent();

            _jwt = String.Empty;
            _api = new BankingSystemApi();
        }

        public MainForm(AuthenticationSuccessResponse response)
        {
            InitializeComponent();
            usersListView.View = View.List;

            _jwt = response.AccessToken;
            _api = new BankingSystemApi();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            var users = await _api.GetUsersAsync(_jwt);
            FillUserListBox(users);
        }

        private void FillUserListBox(List<UserViewModel> users)
        {
            foreach (UserViewModel user in users)
            {
                var listBoxItem = new ListViewItem(user.Username);
                listBoxItem.Tag = user;
                usersListView.Items.Add(listBoxItem);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void usersListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (usersListView.SelectedItems.Count == 0)
                return;

            var selectedItem = usersListView.SelectedItems[0];
            if (selectedItem != null)
            {
                var user = (UserViewModel)selectedItem.Tag;
                recipientIdTextBox.Text = user.Id.ToString();
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var bankAccount = await _api.GetBankAccountAsync(_jwt);
            bankAccountIdTextBox.Text = bankAccount.Id.ToString();
            amountTextBox.Text = bankAccount.Money.ToString();
        }

        private async void topUpBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var amount = topUpTextBox.Text;
                var operation = await _api.TopUpAsync(_jwt, Convert.ToDouble(amount));
                MessageBox.Show($"New bank account amount: {operation.BankAccountAmount}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                amountTextBox.Text = operation.BankAccountAmount.ToString();
            }
            catch (InvalidOperationException exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Initial server error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void withdrawBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var amount = topUpTextBox.Text;
                var operation = await _api.WithdrawAsync(_jwt, Convert.ToInt32(amount));
                MessageBox.Show($"New bank account amount: {operation.BankAccountAmount}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                amountTextBox.Text = operation.BankAccountAmount.ToString();
            }
            catch (InvalidOperationException exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Initial server error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void replenishBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var amount = topUpTextBox.Text;
                var request = new ReplenishRequest { RecipientId = Guid.Parse(recipientIdTextBox.Text), Amount = int.Parse(replenishAmountTextBox.Text) };
                var operation = await _api.ReplenishAsync(_jwt, request);
                MessageBox.Show($"New bank account amount: {operation.BankAccountAmount}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                amountTextBox.Text = operation.BankAccountAmount.ToString();
            }
            catch (InvalidOperationException exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Initial server error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
