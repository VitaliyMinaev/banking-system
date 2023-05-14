namespace BankingSystem.UI
{
    partial class AuthenticateForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            loginCheckBox = new CheckBox();
            btnSubmit = new Button();
            passwordTextBox = new TextBox();
            usernameTextBox = new TextBox();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(loginCheckBox);
            panel1.Controls.Add(btnSubmit);
            panel1.Controls.Add(passwordTextBox);
            panel1.Controls.Add(usernameTextBox);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(370, 363);
            panel1.TabIndex = 0;
            // 
            // loginCheckBox
            // 
            loginCheckBox.AutoSize = true;
            loginCheckBox.Location = new Point(3, 133);
            loginCheckBox.Name = "loginCheckBox";
            loginCheckBox.Size = new Size(193, 24);
            loginCheckBox.TabIndex = 6;
            loginCheckBox.Text = "Already have an account";
            loginCheckBox.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            btnSubmit.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSubmit.Location = new Point(3, 163);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(165, 37);
            btnSubmit.TabIndex = 4;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += BtnSubmit_Click;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            passwordTextBox.Location = new Point(3, 93);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(360, 34);
            passwordTextBox.TabIndex = 3;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // usernameTextBox
            // 
            usernameTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            usernameTextBox.Location = new Point(3, 33);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(360, 34);
            usernameTextBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 70);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 1;
            label2.Text = "Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 10);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 0;
            label1.Text = "Username";
            // 
            // AuthenticateForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(394, 387);
            Controls.Add(panel1);
            Name = "AuthenticateForm";
            Text = "Authorize";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnSubmit;
        private TextBox passwordTextBox;
        private TextBox usernameTextBox;
        private Label label2;
        private Label label1;
        private CheckBox loginCheckBox;
    }
}