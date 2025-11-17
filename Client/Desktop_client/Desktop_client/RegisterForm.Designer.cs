<<<<<<< HEAD
﻿namespace Desktop_client
{
    partial class RegisterForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.RegisterBorrowerButton = new System.Windows.Forms.Button();
            this.GoToMainPageButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(247, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1434, 172);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome to the Library";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(583, 378);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 72);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(583, 457);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 72);
            this.label3.TabIndex = 3;
            this.label3.Text = "Email";
            // 
            // NameTextBox
            // 
            this.NameTextBox.BackColor = System.Drawing.Color.Bisque;
            this.NameTextBox.Font = new System.Drawing.Font("Palatino Linotype", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTextBox.Location = new System.Drawing.Point(889, 378);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(272, 57);
            this.NameTextBox.TabIndex = 5;
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.BackColor = System.Drawing.Color.Bisque;
            this.EmailTextBox.Font = new System.Drawing.Font("Palatino Linotype", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailTextBox.Location = new System.Drawing.Point(889, 457);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(272, 57);
            this.EmailTextBox.TabIndex = 6;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.BackColor = System.Drawing.Color.Bisque;
            this.PasswordTextBox.Font = new System.Drawing.Font("Palatino Linotype", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTextBox.Location = new System.Drawing.Point(889, 548);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(272, 57);
            this.PasswordTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(583, 534);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(261, 72);
            this.label4.TabIndex = 8;
            this.label4.Text = "Password";
            // 
            // RegisterBorrowerButton
            // 
            this.RegisterBorrowerButton.BackColor = System.Drawing.Color.RosyBrown;
            this.RegisterBorrowerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RegisterBorrowerButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RegisterBorrowerButton.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
            this.RegisterBorrowerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RegisterBorrowerButton.Font = new System.Drawing.Font("Palatino Linotype", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterBorrowerButton.ForeColor = System.Drawing.Color.Bisque;
            this.RegisterBorrowerButton.Location = new System.Drawing.Point(938, 668);
            this.RegisterBorrowerButton.Name = "RegisterBorrowerButton";
            this.RegisterBorrowerButton.Size = new System.Drawing.Size(191, 72);
            this.RegisterBorrowerButton.TabIndex = 9;
            this.RegisterBorrowerButton.Text = "Register";
            this.RegisterBorrowerButton.UseVisualStyleBackColor = false;
            this.RegisterBorrowerButton.Click += new System.EventHandler(this.RegisterBorrowerButton_Click);
            // 
            // GoToMainPageButton
            // 
            this.GoToMainPageButton.BackColor = System.Drawing.Color.RosyBrown;
            this.GoToMainPageButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.GoToMainPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GoToMainPageButton.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
            this.GoToMainPageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GoToMainPageButton.Font = new System.Drawing.Font("Palatino Linotype", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GoToMainPageButton.ForeColor = System.Drawing.Color.Bisque;
            this.GoToMainPageButton.Location = new System.Drawing.Point(122, 840);
            this.GoToMainPageButton.Name = "GoToMainPageButton";
            this.GoToMainPageButton.Size = new System.Drawing.Size(191, 72);
            this.GoToMainPageButton.TabIndex = 10;
            this.GoToMainPageButton.Text = "main page";
            this.GoToMainPageButton.UseVisualStyleBackColor = false;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Desktop_client.Properties.Resources.register_page;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1927, 980);
            this.Controls.Add(this.GoToMainPageButton);
            this.Controls.Add(this.RegisterBorrowerButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.EmailTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button RegisterBorrowerButton;
        private System.Windows.Forms.Button GoToMainPageButton;
    }
=======
﻿namespace Desktop_client
{
    partial class RegisterForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.RegisterBorrowerButton = new System.Windows.Forms.Button();
            this.GoToMainPageButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(247, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1434, 172);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome to the Library";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(583, 378);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 72);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(583, 457);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 72);
            this.label3.TabIndex = 3;
            this.label3.Text = "Email";
            // 
            // NameTextBox
            // 
            this.NameTextBox.BackColor = System.Drawing.Color.Bisque;
            this.NameTextBox.Font = new System.Drawing.Font("Palatino Linotype", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTextBox.Location = new System.Drawing.Point(889, 378);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(272, 57);
            this.NameTextBox.TabIndex = 5;
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.BackColor = System.Drawing.Color.Bisque;
            this.EmailTextBox.Font = new System.Drawing.Font("Palatino Linotype", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailTextBox.Location = new System.Drawing.Point(889, 457);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(272, 57);
            this.EmailTextBox.TabIndex = 6;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.BackColor = System.Drawing.Color.Bisque;
            this.PasswordTextBox.Font = new System.Drawing.Font("Palatino Linotype", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTextBox.Location = new System.Drawing.Point(889, 548);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(272, 57);
            this.PasswordTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(583, 534);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(261, 72);
            this.label4.TabIndex = 8;
            this.label4.Text = "Password";
            // 
            // RegisterBorrowerButton
            // 
            this.RegisterBorrowerButton.BackColor = System.Drawing.Color.RosyBrown;
            this.RegisterBorrowerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RegisterBorrowerButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RegisterBorrowerButton.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
            this.RegisterBorrowerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RegisterBorrowerButton.Font = new System.Drawing.Font("Palatino Linotype", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterBorrowerButton.ForeColor = System.Drawing.Color.Bisque;
            this.RegisterBorrowerButton.Location = new System.Drawing.Point(938, 668);
            this.RegisterBorrowerButton.Name = "RegisterBorrowerButton";
            this.RegisterBorrowerButton.Size = new System.Drawing.Size(191, 72);
            this.RegisterBorrowerButton.TabIndex = 9;
            this.RegisterBorrowerButton.Text = "Register";
            this.RegisterBorrowerButton.UseVisualStyleBackColor = false;
            this.RegisterBorrowerButton.Click += new System.EventHandler(this.RegisterBorrowerButton_Click);
            // 
            // GoToMainPageButton
            // 
            this.GoToMainPageButton.BackColor = System.Drawing.Color.RosyBrown;
            this.GoToMainPageButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.GoToMainPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GoToMainPageButton.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
            this.GoToMainPageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GoToMainPageButton.Font = new System.Drawing.Font("Palatino Linotype", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GoToMainPageButton.ForeColor = System.Drawing.Color.Bisque;
            this.GoToMainPageButton.Location = new System.Drawing.Point(122, 840);
            this.GoToMainPageButton.Name = "GoToMainPageButton";
            this.GoToMainPageButton.Size = new System.Drawing.Size(191, 72);
            this.GoToMainPageButton.TabIndex = 10;
            this.GoToMainPageButton.Text = "main page";
            this.GoToMainPageButton.UseVisualStyleBackColor = false;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Desktop_client.Properties.Resources.register_page;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1927, 980);
            this.Controls.Add(this.GoToMainPageButton);
            this.Controls.Add(this.RegisterBorrowerButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.EmailTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button RegisterBorrowerButton;
        private System.Windows.Forms.Button GoToMainPageButton;
    }
>>>>>>> 7e8896f6eaeb727f99ba64333cdd65172b716097
}