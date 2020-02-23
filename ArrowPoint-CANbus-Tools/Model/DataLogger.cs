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
        private const string LOG_TO_DISK = "DISK";
        private const string LOG_TO_FTP = "FTP";
        private const string LOG_TO_SFTP = "SFTP";

        private const string ROTATE_BY_MIN = "MIN";
        private const string ROTATE_BY_MB = "MB";

        private const string ARCHIVE_NEVER = "NEVER";
        //public const string ARCHIVE_BY_MB = "MB";
        //public const string ARCHIVE_BY_COUNT = "COUNT";
        //public const string ARCHIVE_BY_TIME = "TIME";
        

        public string LogTo { get; set; }
        public string RotateBy { get; set; }
        public int RotateMinutes { get; set; }
        public int RotateMB { get; set; }
        public string LocalDirectory { get; set; }
        public string ArchiveDirectory { get; set; }
        public string RemoteHost { get; set; }
        public int RemotePort { get; set; }
        public string RemoteDirectory { get; set; }
        public string Username { get; set; }

        [JsonConverter(typeof(EncryptingJsonConverter), "#my*S3cr3t-Proheli0nKey")]
        public string Password { get; set; }

        public void LogToLocalDisk() { LogTo = LOG_TO_DISK; }
        public void LogToFTP() { LogTo = LOG_TO_FTP; }
        public void LogToSFTP() { LogTo = LOG_TO_SFTP; }
        public void RotateByMin() { RotateBy = ROTATE_BY_MIN; }
        public void RotateByMB() { RotateBy = ROTATE_BY_MB; }

        public bool IsLogToLocalDisk() { return LogTo.Equals(LOG_TO_DISK); }
        public bool IsLogToFTP() { return LogTo.Equals(LOG_TO_FTP); }
        public bool IsLogToSFTP() { return LogTo.Equals(LOG_TO_SFTP); }
        public bool IsLogRemote() { return IsLogToFTP() || IsLogToSFTP(); }

        public bool IsRotateByMin() { return RotateBy.Equals(ROTATE_BY_MIN); }
        public bool IsRotateByMB() { return RotateBy.Equals(ROTATE_BY_MB); } 

        public long RotateBytes()
        {
            if (RotateMB == 0)
                return 10 * 1024 * 1024;
            else
                return RotateMB * 1024 * 1024;
        }

    }
}
