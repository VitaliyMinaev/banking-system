using BankingSystem.Common.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingSystem.UI
{
    public partial class MainForm : Form
    {
        private readonly string _jwt;
        public MainForm()
        {
            InitializeComponent();

            _jwt = String.Empty;
        }

        public MainForm(AuthenticationSuccessResponse response)
        {
            InitializeComponent();

            _jwt = response.AccessToken;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            accessTokenTextBox.Text = _jwt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
