namespace FileHierarchy
{
    partial class Form1
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
            this.chooseSerializeFolderButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // chooseSerializeFolderButton
            // 
            this.chooseSerializeFolderButton.Location = new System.Drawing.Point(13, 13);
            this.chooseSerializeFolderButton.Name = "chooseSerializeFolderButton";
            this.chooseSerializeFolderButton.Size = new System.Drawing.Size(195, 45);
            this.chooseSerializeFolderButton.TabIndex = 0;
            this.chooseSerializeFolderButton.Text = "Folder for serialize";
            this.chooseSerializeFolderButton.UseVisualStyleBackColor = true;
            this.chooseSerializeFolderButton.Click += new System.EventHandler(this.chooseSerializeFolderButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 224);
            this.Controls.Add(this.chooseSerializeFolderButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button chooseSerializeFolderButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}

