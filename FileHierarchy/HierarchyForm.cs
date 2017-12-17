using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace FileHierarchy
{
    public partial class HierarchyForm : Form
    {
        public HierarchyForm()
        {
            InitializeComponent();
        }

        private void chooseSerializeFolderButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowserDialog.SelectedPath;
                string folderName = new DirectoryInfo(path).Name;
                Folder root = new Folder(folderName);
                AddToHierarchy(path, root);
                MessageBox.Show(@"Your folder has been serialized \n Its time to save it", @"Completed", MessageBoxButtons.OK);
                SaveToFile(root);
            }
        }

        private void SaveToFile(Folder folder)
        {
            saveFileDialog.FileName = folder.GetName();
            saveFileDialog.Filter = @"txt files (*.txt)|*.txt|dat files (*.dat)|*.dat|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SerializeFolder(folder, saveFileDialog.FileName);
            }
            else
            {
                MessageBox.Show($@"Your folder ({folder.GetName()}) has not been saved");
            }
        }

        private void SerializeFolder(Folder folder, string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, folder);
            }
        }
        private Folder DeserializeFolder(string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
            {
                Folder deserializedFolder = (Folder)formatter.Deserialize(fileStream);
                return deserializedFolder;
            }
        }

        private void AddToHierarchy(string path, Folder folder)
        {
            string[] foderEntriesPaths = Directory.GetFileSystemEntries(path);
            if (foderEntriesPaths.Length == 0)
            {
                return;
            }
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
                    string fileName = new FileInfo(subEntryPath).Name;
                    string fileContent = System.IO.File.ReadAllText(subEntryPath);
                    File file = new File(fileName, fileContent);
                    folder.Add(file);
                }
            }
        }
    }
}
