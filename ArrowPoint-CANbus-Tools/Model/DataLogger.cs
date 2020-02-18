using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowPointCANBusTool.Model
{
    public class DataLogger
    {
        public const string LOG_TO_DISK = "DISK";
        public const string LOG_TO_FTP = "FTP";
        public const string LOG_TO_SFTP = "SFTP";

        public const string ROTATE_BY_MIN = "MIN";
        public const string ROTATE_BY_MB = "MB";

        public const string ARCHIVE_NEVER = "NEVER";
        public const string ARCHIVE_BY_MB = "MB";
        public const string ARCHIVE_BY_COUNT = "COUNT";
        public const string ARCHIVE_BY_TIME = "TIME";

        public string LogTo { get; set; }
        public string RotateBy { get; set; }
        public int RotateMinutes { get; set; }
        public string RotateMB { get; set; }
        public string LocalDirectory { get; set; }
        public string ArchiveDirectory { get; set; }
        public string RemoteHost { get; set; }
        public int RemotePort { get; set; }
        public string RemoteDirectory { get; set; }
        public string Username { get; set; }

        [JsonConverter(typeof(EncryptingJsonConverter), "#my*S3cr3t-Proheli0nKey")]
        public string Password { get; set; }        
    }
}
