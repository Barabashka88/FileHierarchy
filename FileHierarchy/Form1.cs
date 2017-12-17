using System;
using System.IO;
using System.Windows.Forms;

namespace FileHierarchy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void chooseSerializeFolderButton_Click(object sender, EventArgs e)
        {
          if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string[] files = Directory.GetFileSystemEntries(folderBrowserDialog.SelectedPath);
                //string[] files = Directory.GetFileSystemEntries("E:\\Папка найкращого хлопця в світі)\\TestFolder");
                var tet = "";
                foreach (var elem in files)
                {
                    FileAttributes atr = File.GetAttributes(elem);
                    if ((atr & FileAttributes.Directory) == FileAttributes.Directory)
                        MessageBox.Show(elem+"  Is a directory ");
                    else
                        MessageBox.Show(elem + "   Is a file");

                }
                MessageBox.Show("   Files found: " + files.Length, "Message");
            }
        }

        private void GetAllEnttriesInFolder(string path)
        {
            string[] files = Directory.GetFileSystemEntries(path);
        }
    }
}
