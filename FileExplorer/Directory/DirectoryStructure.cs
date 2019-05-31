using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace FileExplorer
{
    class DirectoryStructure
    {
        /// <summary>
        /// Gets all logical drives on a computer
        /// </summary>
        /// <returns></returns>
        public static List<DirectoryItem> GetLogicalDrives()
        {
            return Directory.GetLogicalDrives().Select((drive) =>
                new DirectoryItem
                {
                    FullPath = drive,
                    Type = DirectoryItemType.Drive
                
                }).ToList();
        }

        /// <summary>
        /// Gets the directories top-level content
        /// </summary>
        /// <param name="fullPath">The full path of the directory</param>
        /// <returns></returns>
        public static List<DirectoryItem> GetDirectoryContent(string fullPath)
        {
            List<DirectoryItem> items = new List<DirectoryItem>();
            try
            {

                var dirs = Directory.GetDirectories(fullPath);

                if (dirs.Length > 0)
                {
                    items.AddRange(dirs.Select(dir => new DirectoryItem
                    {
                        FullPath = dir,
                        Type = DirectoryItemType.Folder
                    }));
                }

                var files = Directory.GetFiles(fullPath);

                if (files.Length > 0)
                    items.AddRange(files.Select(filedir => new DirectoryItem
                    {
                        FullPath = filedir,
                        Type = DirectoryItemType.File
                    }));
                return items;

            }
            catch(IOException ex)
            {
                MessageBox.Show(ex.Message);
                return items;
            }
        }

        /// <summary>
        /// Gets the fileo folder name
        /// </summary>
        /// <param name="path">The full path</param>
        /// <returns></returns>
        public static string GetFileFolderName(string path)
        {
            if (string.IsNullOrEmpty(path))
                return string.Empty;
            var normalizedPath = path.Replace('/', '\\');

            var lastIndex = normalizedPath.LastIndexOf('\\');


            if (lastIndex <= 0)
                return path;

            return path.Substring(lastIndex + 1);
        }
    }
}
