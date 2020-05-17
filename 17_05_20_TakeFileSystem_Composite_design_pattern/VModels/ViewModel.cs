using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Input;

namespace _17_05_20_TakeFileSystem_Composite_design_pattern.VModels
{
    class ViewModel : ViewModelBase
    {        

        private string _takeFileSystem;
        public string TakeFileSystem
        {
            get => _takeFileSystem;
            set
            {
                _takeFileSystem = value;
                OnPropertyChanged();
            }
        }

        public ICommand GetFileSystem_buttonClick { get; set; }

        public ICommand OpenItInFile_buttonClick { get; set; }

        public ViewModel()
        {
            GetFileSystem_buttonClick = new RelayCommand(GetFileSystem, (object o) => { return true; });

            OpenItInFile_buttonClick = new RelayCommand((object o) => { Process.Start("notepad.exe", "theFileSystem.txt"); Thread.Sleep(1000); File.Delete(Directory.GetCurrentDirectory() + "/theFileSystem.txt"); }, (object o) => { if (File.Exists(Directory.GetCurrentDirectory() + "/theFileSystem.txt")) return true; else return false; });

        }

        private async void GetFileSystem(object o)
        {

            Branch rootBranch = new Branch(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));

            rootBranch = await GetFilesAndDirectories(rootBranch);



            TakeFileSystem = await rootBranch.AllChildrenToString("");

            File.WriteAllText(Directory.GetCurrentDirectory() +  "/theFileSystem.txt", TakeFileSystem);

        }

        private async Task<Branch> GetFilesAndDirectories(Branch rootBranch)
        {
            return await Task.Run(async() => 
            {
                string[] files = Directory.GetFiles(rootBranch.FileOrDirectory);
                string[] folders = Directory.GetDirectories(rootBranch.FileOrDirectory);

                foreach (string s in files)
                {
                    rootBranch.AddChild(new Leaf(s));
                }
                foreach (string s in folders)
                {
                    Branch branch = new Branch(s);
                    rootBranch.AddChild(branch);
                    await GetFilesAndDirectories(branch);
                }

                return rootBranch;
            });


        }
    }
}
