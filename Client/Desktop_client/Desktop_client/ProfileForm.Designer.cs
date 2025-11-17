<<<<<<< HEAD
﻿namespace Desktop_client
{
    partial class ProfileForm
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
            this.AuthorComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BooksComboBox = new System.Windows.Forms.ComboBox();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.ReserveButton = new System.Windows.Forms.Button();
            this.UserCollectionComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DueAtTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ReturnButton = new System.Windows.Forms.Button();
            this.SuggestionsButton = new System.Windows.Forms.Button();
            this.ExitAppButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(32, 1027);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1726, 87);
            this.label1.TabIndex = 2;
            this.label1.Text = "This is your profile page, where you can see our collection";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(645, 1114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1000, 87);
            this.label2.TabIndex = 3;
            this.label2.Text = "and reserve your book to pick up";
            // 
            // AuthorComboBox
            // 
            this.AuthorComboBox.BackColor = System.Drawing.Color.Linen;
            this.AuthorComboBox.Font = new System.Drawing.Font("Palatino Linotype", 13.875F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AuthorComboBox.FormattingEnabled = true;
            this.AuthorComboBox.Location = new System.Drawing.Point(1901, 120);
            this.AuthorComboBox.Name = "AuthorComboBox";
            this.AuthorComboBox.Size = new System.Drawing.Size(476, 57);
            this.AuthorComboBox.TabIndex = 4;
            this.AuthorComboBox.SelectedIndexChanged += new System.EventHandler(this.AuthorComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(1922, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(438, 72);
            this.label3.TabIndex = 5;
            this.label3.Text = "Select the author";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(1238, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(344, 72);
            this.label4.TabIndex = 6;
            this.label4.Text = "List of books";
            // 
            // BooksComboBox
            // 
            this.BooksComboBox.BackColor = System.Drawing.Color.Linen;
            this.BooksComboBox.Font = new System.Drawing.Font("Palatino Linotype", 13.875F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BooksComboBox.FormattingEnabled = true;
            this.BooksComboBox.Location = new System.Drawing.Point(1169, 120);
            this.BooksComboBox.Name = "BooksComboBox";
            this.BooksComboBox.Size = new System.Drawing.Size(476, 57);
            this.BooksComboBox.TabIndex = 7;
            this.BooksComboBox.SelectedIndexChanged += new System.EventHandler(this.BooksComboBox_SelectedIndexChanged);
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.BackColor = System.Drawing.Color.Linen;
            this.DescriptionTextBox.Font = new System.Drawing.Font("Palatino Linotype", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionTextBox.Location = new System.Drawing.Point(1324, 476);
            this.DescriptionTextBox.Multiline = true;
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.ReadOnly = true;
            this.DescriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.DescriptionTextBox.Size = new System.Drawing.Size(908, 441);
            this.DescriptionTextBox.TabIndex = 8;
            // 
            // ReserveButton
            // 
            this.ReserveButton.BackColor = System.Drawing.Color.RosyBrown;
            this.ReserveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReserveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReserveButton.Font = new System.Drawing.Font("Palatino Linotype", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReserveButton.Location = new System.Drawing.Point(2290, 821);
            this.ReserveButton.Name = "ReserveButton";
            this.ReserveButton.Size = new System.Drawing.Size(196, 96);
            this.ReserveButton.TabIndex = 9;
            this.ReserveButton.Text = "Reserve";
            this.ReserveButton.UseVisualStyleBackColor = false;
            this.ReserveButton.Click += new System.EventHandler(this.ReserveButton_Click);
            // 
            // UserCollectionComboBox
            // 
            this.UserCollectionComboBox.BackColor = System.Drawing.Color.Linen;
            this.UserCollectionComboBox.Font = new System.Drawing.Font("Palatino Linotype", 13.875F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserCollectionComboBox.FormattingEnabled = true;
            this.UserCollectionComboBox.Location = new System.Drawing.Point(92, 120);
            this.UserCollectionComboBox.Name = "UserCollectionComboBox";
            this.UserCollectionComboBox.Size = new System.Drawing.Size(476, 57);
            this.UserCollectionComboBox.TabIndex = 11;
            this.UserCollectionComboBox.SelectedIndexChanged += new System.EventHandler(this.UserCollectionComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(117, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(425, 72);
            this.label5.TabIndex = 12;
            this.label5.Text = "My list of books";
            // 
            // DueAtTextBox
            // 
            this.DueAtTextBox.BackColor = System.Drawing.Color.Linen;
            this.DueAtTextBox.Font = new System.Drawing.Font("Palatino Linotype", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DueAtTextBox.Location = new System.Drawing.Point(92, 617);
            this.DueAtTextBox.Name = "DueAtTextBox";
            this.DueAtTextBox.Size = new System.Drawing.Size(468, 57);
            this.DueAtTextBox.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(109, 533);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(191, 72);
            this.label6.TabIndex = 14;
            this.label6.Text = "Due at";
            // 
            // ReturnButton
            // 
            this.ReturnButton.BackColor = System.Drawing.Color.RosyBrown;
            this.ReturnButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReturnButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReturnButton.Font = new System.Drawing.Font("Palatino Linotype", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReturnButton.Location = new System.Drawing.Point(660, 600);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(196, 96);
            this.ReturnButton.TabIndex = 15;
            this.ReturnButton.Text = "Return";
            this.ReturnButton.UseVisualStyleBackColor = false;
            this.ReturnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // SuggestionsButton
            // 
            this.SuggestionsButton.BackColor = System.Drawing.Color.RosyBrown;
            this.SuggestionsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SuggestionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SuggestionsButton.Font = new System.Drawing.Font("Palatino Linotype", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SuggestionsButton.Location = new System.Drawing.Point(2198, 1122);
            this.SuggestionsButton.Name = "SuggestionsButton";
            this.SuggestionsButton.Size = new System.Drawing.Size(196, 96);
            this.SuggestionsButton.TabIndex = 16;
            this.SuggestionsButton.Text = "Suggestions";
            this.SuggestionsButton.UseVisualStyleBackColor = false;
            this.SuggestionsButton.Click += new System.EventHandler(this.SuggestionsButton_Click);
            // 
            // ExitAppButton
            // 
            this.ExitAppButton.BackColor = System.Drawing.Color.RosyBrown;
            this.ExitAppButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitAppButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitAppButton.Font = new System.Drawing.Font("Palatino Linotype", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitAppButton.Location = new System.Drawing.Point(1890, 1122);
            this.ExitAppButton.Name = "ExitAppButton";
            this.ExitAppButton.Size = new System.Drawing.Size(196, 96);
            this.ExitAppButton.TabIndex = 17;
            this.ExitAppButton.Text = "Exit";
            this.ExitAppButton.UseVisualStyleBackColor = false;
            this.ExitAppButton.Click += new System.EventHandler(this.ExitAppButton_Click);
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Desktop_client.Properties.Resources.profile_page;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(2533, 1256);
            this.Controls.Add(this.ExitAppButton);
            this.Controls.Add(this.SuggestionsButton);
            this.Controls.Add(this.ReturnButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DueAtTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.UserCollectionComboBox);
            this.Controls.Add(this.ReserveButton);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.BooksComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AuthorComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ProfileForm";
            this.Text = "ProfileForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox AuthorComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox BooksComboBox;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.Button ReserveButton;
        private System.Windows.Forms.ComboBox UserCollectionComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox DueAtTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button ReturnButton;
        private System.Windows.Forms.Button SuggestionsButton;
        private System.Windows.Forms.Button ExitAppButton;
    }
=======
﻿namespace Desktop_client
{
    partial class ProfileForm
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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(189, 750);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1726, 87);
            this.label1.TabIndex = 2;
            this.label1.Text = "This is your profile page, where you can see our collection";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(924, 850);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1000, 87);
            this.label2.TabIndex = 3;
            this.label2.Text = "and reserve your book to pick up";
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Desktop_client.Properties.Resources.profile_page;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1927, 980);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ProfileForm";
            this.Text = "ProfileForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
>>>>>>> 7e8896f6eaeb727f99ba64333cdd65172b716097
}