﻿namespace FileHierarchy
{
    partial class HierarchyForm
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.chooseDeserializeFileButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chooseSerializeFolderButton
            // 
            this.chooseSerializeFolderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chooseSerializeFolderButton.Location = new System.Drawing.Point(12, 12);
            this.chooseSerializeFolderButton.Name = "chooseSerializeFolderButton";
            this.chooseSerializeFolderButton.Size = new System.Drawing.Size(195, 65);
            this.chooseSerializeFolderButton.TabIndex = 0;
            this.chooseSerializeFolderButton.Text = "Choose folder for serialize into file";
            this.chooseSerializeFolderButton.UseVisualStyleBackColor = true;
            this.chooseSerializeFolderButton.Click += new System.EventHandler(this.chooseSerializeFolderButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // chooseDeserializeFileButton
            // 
            this.chooseDeserializeFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chooseDeserializeFileButton.Location = new System.Drawing.Point(12, 147);
            this.chooseDeserializeFileButton.Name = "chooseDeserializeFileButton";
            this.chooseDeserializeFileButton.Size = new System.Drawing.Size(195, 65);
            this.chooseDeserializeFileButton.TabIndex = 1;
            this.chooseDeserializeFileButton.Text = "Choose file for deserialize and unpack ino folder";
            this.chooseDeserializeFileButton.UseVisualStyleBackColor = true;
            this.chooseDeserializeFileButton.Click += new System.EventHandler(this.chooseDeserializeFileButton_Click);
            // 
            // HierarchyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 224);
            this.Controls.Add(this.chooseDeserializeFileButton);
            this.Controls.Add(this.chooseSerializeFolderButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HierarchyForm";
            this.Text = "Hierarchy";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button chooseSerializeFolderButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button chooseDeserializeFileButton;
    }
}

