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

        public static void FileToCompress(string sourceFile, string destFile)
        {

            string filenameNoPath = Path.GetFileName(sourceFile);
            
            using (var zip = ZipFile.Open(@destFile, ZipArchiveMode.Create))
            {
                // using the method                
                var entry = zip.CreateEntry(filenameNoPath);
                entry.LastWriteTime = DateTimeOffset.Now;

                using (var stream = File.OpenRead(@sourceFile))
                using (var entryStream = entry.Open())
                    stream.CopyTo(entryStream);
            }
            
        }

    }
}
