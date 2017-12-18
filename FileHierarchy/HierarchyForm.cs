using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
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
            folderBrowserDialog.Description = "Choose folder for pack and serialize.";
            
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;
                string path = folderBrowserDialog.SelectedPath;
                string folderName = new DirectoryInfo(path).Name;
                Folder root = new Folder(folderName);
                AddToHierarchy(path, root);
                MessageBox.Show("Your folder has been saved and serialized. \n Its time to save it.", "Completed!",
                    MessageBoxButtons.OK);
                SaveToFile(root);
                Cursor.Current = Cursors.Arrow;
            }
        }

        private void SaveToFile(Folder folder)
        {
            saveFileDialog.FileName = folder.Name;
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|dat files (*.dat)|*.dat|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SerializeFolder(folder, saveFileDialog.FileName);
                MessageBox.Show("File saved.", "Completed");
            }
            else
            {
                MessageBox.Show($"Your folder ({folder.Name}) has not been saved.");
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
            try
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
                {
                    var folder = (Folder)formatter.Deserialize(fileStream);
                    return folder;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"There is an error while parsing file into folder: {e.Message}.", "An error occurred");
                return null;
            }
        }

        private async Task AddToHierarchy(string path, Folder folder)
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
                    await AddToHierarchy(subEntryPath, subFolder);
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

        private void chooseDeserializeFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|dat files (*.dat)|*.dat|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 3;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Folder folder = DeserializeFolder(openFileDialog.FileName);
                if (folder != null)
                {
                    MessageBox.Show("Now, lets choose a folder where unpack.", "Completed!");
                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        string path = Path.Combine(folderBrowserDialog.SelectedPath, folder.Name);
                        if (!Directory.Exists(path))
                        {
                            UnpackHierarchy(folderBrowserDialog.SelectedPath, folder);
                            MessageBox.Show("All completed successfully.\nOpen and check in File Explorer.","Completed");
                        }
                        else
                        {
                            MessageBox.Show("Can't unpack folder here.\nThe folder with same name already exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void UnpackHierarchy(string path, Entry entry)
        {
            string newPath = Path.Combine(path, entry.Name);

            if (entry is Folder folder)
            {
                Directory.CreateDirectory(newPath);

                foreach (var subEntry in folder.Children)
                {
                    UnpackHierarchy(newPath, subEntry);
                }
            }
            else if (entry is File file)
            {
                System.IO.File.Create(newPath).Close();
                System.IO.File.WriteAllText(newPath, file.Content);
            }
        }
    }
}
