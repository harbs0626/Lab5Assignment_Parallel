namespace FlickrViewer
{
   partial class FickrViewerForm
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose( bool disposing )
      {
         if ( disposing && ( components != null ) )
         {
            components.Dispose();
         }
         base.Dispose( disposing );
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
            this.label1 = new System.Windows.Forms.Label();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.imagesListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.imageFormatComboBox = new System.Windows.Forms.ComboBox();
            this.saveResizeButton = new System.Windows.Forms.Button();
            this.saveProgressBar = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.imageResolutionTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.imageSizeTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.imageFileNameTextBox = new System.Windows.Forms.TextBox();
            this.resizeButton = new System.Windows.Forms.Button();
            this.saveOriginalButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Flickr search tags here:";
            // 
            // inputTextBox
            // 
            this.inputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputTextBox.Location = new System.Drawing.Point(163, 13);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(428, 20);
            this.inputTextBox.TabIndex = 1;
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Location = new System.Drawing.Point(163, 172);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(503, 384);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.Location = new System.Drawing.Point(597, 11);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(70, 23);
            this.searchButton.TabIndex = 4;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // imagesListBox
            // 
            this.imagesListBox.FormattingEnabled = true;
            this.imagesListBox.Location = new System.Drawing.Point(12, 97);
            this.imagesListBox.Name = "imagesListBox";
            this.imagesListBox.Size = new System.Drawing.Size(145, 459);
            this.imagesListBox.TabIndex = 5;
            this.imagesListBox.SelectedIndexChanged += new System.EventHandler(this.imagesListBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Please select image format:";
            // 
            // imageFormatComboBox
            // 
            this.imageFormatComboBox.FormattingEnabled = true;
            this.imageFormatComboBox.Location = new System.Drawing.Point(163, 41);
            this.imageFormatComboBox.Name = "imageFormatComboBox";
            this.imageFormatComboBox.Size = new System.Drawing.Size(156, 21);
            this.imageFormatComboBox.TabIndex = 7;
            // 
            // saveResizeButton
            // 
            this.saveResizeButton.Enabled = false;
            this.saveResizeButton.Location = new System.Drawing.Point(305, 126);
            this.saveResizeButton.Name = "saveResizeButton";
            this.saveResizeButton.Size = new System.Drawing.Size(140, 40);
            this.saveResizeButton.TabIndex = 8;
            this.saveResizeButton.Text = "Save or Download (Resized)";
            this.saveResizeButton.UseVisualStyleBackColor = true;
            this.saveResizeButton.Click += new System.EventHandler(this.saveResizeButton_Click);
            // 
            // saveProgressBar
            // 
            this.saveProgressBar.Location = new System.Drawing.Point(163, 97);
            this.saveProgressBar.Name = "saveProgressBar";
            this.saveProgressBar.Size = new System.Drawing.Size(504, 23);
            this.saveProgressBar.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Image Resolution:";
            // 
            // imageResolutionTextBox
            // 
            this.imageResolutionTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.imageResolutionTextBox.ForeColor = System.Drawing.Color.Blue;
            this.imageResolutionTextBox.Location = new System.Drawing.Point(163, 70);
            this.imageResolutionTextBox.Name = "imageResolutionTextBox";
            this.imageResolutionTextBox.ReadOnly = true;
            this.imageResolutionTextBox.Size = new System.Drawing.Size(156, 20);
            this.imageResolutionTextBox.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(341, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Please enter image size (width):";
            // 
            // imageSizeTextBox
            // 
            this.imageSizeTextBox.Location = new System.Drawing.Point(502, 42);
            this.imageSizeTextBox.Name = "imageSizeTextBox";
            this.imageSizeTextBox.Size = new System.Drawing.Size(165, 20);
            this.imageSizeTextBox.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(341, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Image FileName:";
            // 
            // imageFileNameTextBox
            // 
            this.imageFileNameTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.imageFileNameTextBox.ForeColor = System.Drawing.Color.Blue;
            this.imageFileNameTextBox.Location = new System.Drawing.Point(433, 70);
            this.imageFileNameTextBox.Name = "imageFileNameTextBox";
            this.imageFileNameTextBox.ReadOnly = true;
            this.imageFileNameTextBox.Size = new System.Drawing.Size(234, 20);
            this.imageFileNameTextBox.TabIndex = 15;
            // 
            // resizeButton
            // 
            this.resizeButton.Location = new System.Drawing.Point(163, 126);
            this.resizeButton.Name = "resizeButton";
            this.resizeButton.Size = new System.Drawing.Size(136, 40);
            this.resizeButton.TabIndex = 16;
            this.resizeButton.Text = "Resize Image";
            this.resizeButton.UseVisualStyleBackColor = true;
            this.resizeButton.Click += new System.EventHandler(this.resizeButton_Click);
            // 
            // saveOriginalButton
            // 
            this.saveOriginalButton.Location = new System.Drawing.Point(451, 126);
            this.saveOriginalButton.Name = "saveOriginalButton";
            this.saveOriginalButton.Size = new System.Drawing.Size(140, 40);
            this.saveOriginalButton.TabIndex = 17;
            this.saveOriginalButton.Text = "Save or Download (Original)";
            this.saveOriginalButton.UseVisualStyleBackColor = true;
            this.saveOriginalButton.Click += new System.EventHandler(this.saveOriginalButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(597, 126);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(70, 40);
            this.exitButton.TabIndex = 18;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // FickrViewerForm
            // 
            this.AcceptButton = this.searchButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 574);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.saveOriginalButton);
            this.Controls.Add(this.resizeButton);
            this.Controls.Add(this.imageFileNameTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.imageSizeTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.imageResolutionTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.saveProgressBar);
            this.Controls.Add(this.saveResizeButton);
            this.Controls.Add(this.imageFormatComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.imagesListBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "FickrViewerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flickr Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox inputTextBox;
      private System.Windows.Forms.PictureBox pictureBox;
      private System.Windows.Forms.Button searchButton;
      private System.Windows.Forms.ListBox imagesListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox imageFormatComboBox;
        private System.Windows.Forms.Button saveResizeButton;
        private System.Windows.Forms.ProgressBar saveProgressBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox imageResolutionTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox imageSizeTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox imageFileNameTextBox;
        private System.Windows.Forms.Button resizeButton;
        private System.Windows.Forms.Button saveOriginalButton;
        private System.Windows.Forms.Button exitButton;
    }
}

