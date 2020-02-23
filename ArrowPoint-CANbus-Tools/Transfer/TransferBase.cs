using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArrowPointCANBusTool.Utilities.Compression;

namespace ArrowPointCANBusTool.Transfer
{
    abstract class TransferBase
    {

        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string DestinationDirectory { get; set; }
        public string SourceDirectory { get; set; }
        public string ArchiveDirectory { get; set; }
        public bool DeleteAfterUpload { get; set; }
        public bool ArchiveAfterUpload { get; set; }

        public abstract bool UploadFile(string filename);

        public bool UploadFileCompressed(string filename)
        {

            string zipFilename = Compress.FileToCompress(filename);

            bool result = UploadFile(zipFilename);

            if (File.Exists(@zipFilename))
            {
                File.Delete(@zipFilename);
            }

            return result;
        }

        public abstract bool TestConnection();

    }
}
