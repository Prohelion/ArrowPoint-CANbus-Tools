using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;

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
            string pathNoFileName = Path.GetFullPath(filename);
            string filenameNoPath = Path.GetFileName(filename);
            string zipFilename = pathNoFileName + Path.GetFileNameWithoutExtension(filename) + ".zip";

            using (var zip = ZipFile.Open(@zipFilename, ZipArchiveMode.Create))
            {
                // using the method                
                var entry = zip.CreateEntry(filenameNoPath);
                entry.LastWriteTime = DateTimeOffset.Now;

                using (var stream = File.OpenRead(@filename))
                using (var entryStream = entry.Open())
                    stream.CopyTo(entryStream);
            }

            bool result = UploadFile(filename);

            if (File.Exists(@zipFilename))
            {
                File.Delete(@zipFilename);
            }

            return result;
        }

        public abstract bool TestConnection();

    }
}
