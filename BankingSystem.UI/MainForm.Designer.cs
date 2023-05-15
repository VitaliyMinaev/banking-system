namespace BankingSystem.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label2 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            amountTextBox = new TextBox();
            label6 = new Label();
            bankAccountIdTextBox = new TextBox();
            updateBankAccountBtn = new Button();
            label4 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox1 = new TextBox();
            updateBankAccountStatusBtn = new Button();
            label5 = new Label();
            topUpBtn = new Button();
            topUpTextBox = new TextBox();
            label7 = new Label();
            panel3 = new Panel();
            withdrawBtn = new Button();
            label8 = new Label();
            replenishAmountTextBox = new TextBox();
            label10 = new Label();
            recipientIdTextBox = new TextBox();
            replenishBtn = new Button();
            label9 = new Label();
            usersListView = new ListView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(44, 20);
            label2.TabIndex = 3;
            label2.Text = "Users";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(updateBankAccountStatusBtn);
            panel1.Location = new Point(253, 35);
            panel1.Name = "panel1";
            panel1.Size = new Size(436, 162);
            panel1.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(label1);
            panel2.Controls.Add(amountTextBox);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(bankAccountIdTextBox);
            panel2.Controls.Add(updateBankAccountBtn);
            panel2.Location = new Point(-2, -2);
            panel2.Name = "panel2";
            panel2.Size = new Size(436, 162);
            panel2.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 59);
            label1.Name = "label1";
            label1.Size = new Size(62, 20);
            label1.TabIndex = 8;
            label1.Text = "Amount";
            // 
            // amountTextBox
            // 
            amountTextBox.Location = new Point(3, 82);
            amountTextBox.Name = "amountTextBox";
            amountTextBox.Size = new Size(426, 27);
            amountTextBox.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 4);
            label6.Name = "label6";
            label6.Size = new Size(114, 20);
            label6.TabIndex = 6;
            label6.Text = "Bank account id";
            // 
            // bankAccountIdTextBox
            // 
            bankAccountIdTextBox.Location = new Point(3, 29);
            bankAccountIdTextBox.Name = "bankAccountIdTextBox";
            bankAccountIdTextBox.Size = new Size(426, 27);
            bankAccountIdTextBox.TabIndex = 1;
            // 
            // updateBankAccountBtn
            // 
            updateBankAccountBtn.Location = new Point(3, 115);
            updateBankAccountBtn.Name = "updateBankAccountBtn";
            updateBankAccountBtn.Size = new Size(123, 35);
            updateBankAccountBtn.TabIndex = 0;
            updateBankAccountBtn.Text = "Update";
            updateBankAccountBtn.UseVisualStyleBackColor = true;
            updateBankAccountBtn.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 59);
            label4.Name = "label4";
            label4.Size = new Size(62, 20);
            label4.TabIndex = 8;
            label4.Text = "Amount";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(3, 82);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(426, 27);
            textBox2.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 4);
            label3.Name = "label3";
            label3.Size = new Size(114, 20);
            label3.TabIndex = 6;
            label3.Text = "Bank account id";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(3, 29);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(426, 27);
            textBox1.TabIndex = 1;
            // 
            // updateBankAccountStatusBtn
            // 
            updateBankAccountStatusBtn.Location = new Point(3, 115);
            updateBankAccountStatusBtn.Name = "updateBankAccountStatusBtn";
            updateBankAccountStatusBtn.Size = new Size(123, 35);
            updateBankAccountStatusBtn.TabIndex = 0;
            updateBankAccountStatusBtn.Text = "Update";
            updateBankAccountStatusBtn.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(258, 9);
            label5.Name = "label5";
            label5.Size = new Size(139, 20);
            label5.TabIndex = 6;
            label5.Text = "Bank account status";
            // 
            // topUpBtn
            // 
            topUpBtn.Location = new Point(3, 63);
            topUpBtn.Name = "topUpBtn";
            topUpBtn.Size = new Size(123, 35);
            topUpBtn.TabIndex = 0;
            topUpBtn.Text = "Top up";
            topUpBtn.UseVisualStyleBackColor = true;
            topUpBtn.Click += topUpBtn_Click;
            // 
            // topUpTextBox
            // 
            topUpTextBox.Location = new Point(3, 30);
            topUpTextBox.Name = "topUpTextBox";
            topUpTextBox.Size = new Size(426, 27);
            topUpTextBox.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 7);
            label7.Name = "label7";
            label7.Size = new Size(62, 20);
            label7.TabIndex = 8;
            label7.Text = "Amount";
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Controls.Add(withdrawBtn);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(replenishAmountTextBox);
            panel3.Controls.Add(topUpTextBox);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(topUpBtn);
            panel3.Controls.Add(recipientIdTextBox);
            panel3.Controls.Add(replenishBtn);
            panel3.Location = new Point(253, 223);
            panel3.Name = "panel3";
            panel3.Size = new Size(436, 316);
            panel3.TabIndex = 10;
            // 
            // withdrawBtn
            // 
            withdrawBtn.Location = new Point(132, 63);
            withdrawBtn.Name = "withdrawBtn";
            withdrawBtn.Size = new Size(123, 35);
            withdrawBtn.TabIndex = 14;
            withdrawBtn.Text = "Withdraw";
            withdrawBtn.UseVisualStyleBackColor = true;
            withdrawBtn.Click += withdrawBtn_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(3, 159);
            label8.Name = "label8";
            label8.Size = new Size(62, 20);
            label8.TabIndex = 13;
            label8.Text = "Amount";
            // 
            // replenishAmountTextBox
            // 
            replenishAmountTextBox.Location = new Point(3, 182);
            replenishAmountTextBox.Name = "replenishAmountTextBox";
            replenishAmountTextBox.Size = new Size(426, 27);
            replenishAmountTextBox.TabIndex = 12;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(3, 104);
            label10.Name = "label10";
            label10.Size = new Size(88, 20);
            label10.TabIndex = 11;
            label10.Text = "Recipient id";
            // 
            // recipientIdTextBox
            // 
            recipientIdTextBox.Location = new Point(3, 129);
            recipientIdTextBox.Name = "recipientIdTextBox";
            recipientIdTextBox.Size = new Size(426, 27);
            recipientIdTextBox.TabIndex = 10;
            // 
            // replenishBtn
            // 
            replenishBtn.Location = new Point(3, 215);
            replenishBtn.Name = "replenishBtn";
            replenishBtn.Size = new Size(123, 35);
            replenishBtn.TabIndex = 9;
            replenishBtn.Text = "Replenish";
            replenishBtn.UseVisualStyleBackColor = true;
            replenishBtn.Click += replenishBtn_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(258, 200);
            label9.Name = "label9";
            label9.Size = new Size(82, 20);
            label9.TabIndex = 11;
            label9.Text = "Operations";
            // 
            // usersListView
            // 
            usersListView.Location = new Point(12, 35);
            usersListView.MultiSelect = false;
            usersListView.Name = "usersListView";
            usersListView.RightToLeft = RightToLeft.No;
            usersListView.Size = new Size(235, 504);
            usersListView.TabIndex = 15;
            usersListView.UseCompatibleStateImageBehavior = false;
            usersListView.SelectedIndexChanged += usersListView_SelectedIndexChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(701, 557);
            Controls.Add(usersListView);
            Controls.Add(label9);
            Controls.Add(panel3);
            Controls.Add(label5);
            Controls.Add(panel1);
            Controls.Add(label2);
            Name = "MainForm";
            Text = "Main form";
            Load += MainForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Panel panel1;
        private Button updateBankAccountStatusBtn;
        private Panel panel2;
        private Label label1;
        private TextBox amountTextBox;
        private Label label6;
        private TextBox bankAccountIdTextBox;
        private Button updateBankAccountBtn;
        private Label label4;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox1;
        private Label label5;
        private Button topUpBtn;
        private TextBox topUpTextBox;
        private Label label7;
        private Panel panel3;
        private Button withdrawBtn;
        private Label label8;
        private TextBox replenishAmountTextBox;
        private Label label10;
        private TextBox recipientIdTextBox;
        private Button replenishBtn;
        private Label label9;
        private ListView usersListView;
    }
}