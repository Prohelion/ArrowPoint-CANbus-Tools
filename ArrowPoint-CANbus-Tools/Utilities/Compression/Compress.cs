using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowPointCANBusTool.Utilities.Compression
{
    public static class Compress
    {

        public static string FileToCompress(string filename)
        {
            string pathNoFileName = Path.GetDirectoryName(filename);
            string filenameNoPath = Path.GetFileName(filename);
            string zipFilename = pathNoFileName + @"\" + Path.GetFileNameWithoutExtension(filename) + ".zip";

            using (var zip = ZipFile.Open(@zipFilename, ZipArchiveMode.Create))
            {
                // using the method                
                var entry = zip.CreateEntry(filenameNoPath);
                entry.LastWriteTime = DateTimeOffset.Now;

                using (var stream = File.OpenRead(@filename))
                using (var entryStream = entry.Open())
                    stream.CopyTo(entryStream);
            }

            return zipFilename;
        }

    }
}
