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
    public abstract class TransferBase
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

        public abstract bool TestConnection();

    }
}
