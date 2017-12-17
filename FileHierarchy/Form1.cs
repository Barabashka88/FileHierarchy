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
                string path = folderBrowserDialog.SelectedPath;
                string folderName = new DirectoryInfo(path).Name;
                Folder root = new Folder(folderName);
                AddToHierarchy(path, root);
            }
        }

        private void AddToHierarchy(string path, Folder folder)
        {
            string[] foderEntriesPaths = Directory.GetFileSystemEntries(path);
            if (foderEntriesPaths.Length != 0)
            {
                foreach (var subEntryPath in foderEntriesPaths)
                {
                    FileAttributes atr = System.IO.File.GetAttributes(subEntryPath);
                    if ((atr & FileAttributes.Directory) == FileAttributes.Directory)
                    {
                        Folder subFolder = new Folder(new DirectoryInfo(subEntryPath).Name);
                        folder.Add(subFolder);
                        AddToHierarchy(subEntryPath, subFolder);
                    }
                    else
                    {
                        folder.Add(new File(new FileInfo(subEntryPath).Name, System.IO.File.ReadAllText(subEntryPath)));
                    }
                }
            }
        }
    }
}
