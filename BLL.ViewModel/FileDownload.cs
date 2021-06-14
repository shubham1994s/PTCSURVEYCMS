using System.Collections.Generic;
using System.IO;

namespace BLL.ViewModel
{
    public class FileDownload
    {
        public List<FileInfo> GetFile()
        {
            List<FileInfo> listFiles = new List<FileInfo>();
            ////Path For download From Network Path.  
            //string fileSavePath = @"\\servername\FileFolderName";
            //DirectoryInfo dirInfo = new DirectoryInfo(fileSavePath);
            //int i = 0;
            //foreach (var item in dirInfo.GetFiles())
            //{
            //    listFiles.Add(new FileInfo()
            //    {
            //        FileId = i + 1,
            //        FileName = item.Name,
            //        FilePath = dirInfo.FullName + @"\" + item.Name
            //    });
            //    i = i + 1;
            //}
            return listFiles;
        }
    }
}
