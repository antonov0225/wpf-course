using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileExplorer
{
    /// <summary>
    /// Helper to query all about directories
    /// </summary>
    public class DirectoryItem
    {
        /// <summary>
        /// The type of this item
        /// </summary>
        public DirectoryItemType Type { get; set; }

        /// <summary>
        ///The absolute path
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// The name of this directory item
        /// </summary>
        public string Name {
            get {
                return Type==DirectoryItemType.Drive? FullPath:DirectoryStructure.GetFileFolderName(FullPath);
            }
        }

       
    }
}
