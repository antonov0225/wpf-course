using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer
{
    class DirectoryStructureViewModel
    {
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }

        public DirectoryStructureViewModel()
        {
            var drives = DirectoryStructure.GetLogicalDrives();

            Items = new ObservableCollection<DirectoryItemViewModel>(
                drives.Select(
                    child => new DirectoryItemViewModel(
                        child.FullPath,
                        DirectoryItemType.Drive)));
        }
    }
}
