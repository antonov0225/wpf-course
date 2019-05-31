using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
namespace FileExplorer
{
    
    class DirectoryItemViewModel:BaseViewModel
    {
        public DirectoryItemType Type { get; set; }

        public string ImageName => 
            Type == DirectoryItemType.Drive ? "drive" : (
            Type == DirectoryItemType.File ? "file" : (IsExpanded ? "folder-open" : "folder-closed")
            );
        
        public string FullPath { get; set; }

        public string Name {
            get {
                return Type == DirectoryItemType.Drive ? FullPath : DirectoryStructure.GetFileFolderName(FullPath);
            }
        }

        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }

        public bool CanExpand {
            get
            {
                return Type != DirectoryItemType.File;
            }
        }

        public bool IsExpanded
        {
            get
            {
                return Children?.Count(f => f != null) > 0;
            }
            set
            {
                if(value==true)
                {
                    Expand();
                }
                else
                {
                    ClearChildren();
                }
            }
        }

        public ICommand ExpandCommand { get; set; }

        public DirectoryItemViewModel(string fullPath, DirectoryItemType type)
        {
            ExpandCommand = new RelayCommand(Expand);
            FullPath = fullPath;
            Type = type;
            ClearChildren();
        }

        private void ClearChildren()
        {
            Children = new ObservableCollection<DirectoryItemViewModel>();

            if (Type != DirectoryItemType.File)
            {
                Children.Add(null);
            }
        }

        private void Expand()
        {
            if(Type == DirectoryItemType.File)
            {
                return;
            }

            var children = DirectoryStructure.GetDirectoryContent(FullPath);
            
            Children = new ObservableCollection<DirectoryItemViewModel>(
                children.Select(
                    content => new DirectoryItemViewModel(
                        content.FullPath,
                        content.Type)));
        }
    }
}
