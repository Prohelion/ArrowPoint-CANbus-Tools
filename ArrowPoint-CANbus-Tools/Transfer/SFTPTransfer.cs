using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowPointCANBusTool.Transfer
{
    class SFTPTransfer : TransferBase
    {


        public override bool UploadFile(string filename)
        { 

            Console.WriteLine("Creating client and connecting");
            using (var client = new SftpClient(Host, Port, Username, Password))
            {
                client.Connect();
                Console.WriteLine("Connected to {0}", Host);
 
                client.ChangeDirectory(DestinationDirectory);
                Console.WriteLine("Changed directory to {0}", DestinationDirectory);
  
                using (var fileStream = new FileStream(SourceDirectory + filename, FileMode.Open))
                {
                    Console.WriteLine("Uploading {0} ({1:N0} bytes)", filename, fileStream.Length);
                    client.BufferSize = 4 * 1024; // bypass Payload error large files
                    client.UploadFile(fileStream, Path.GetFileName(SourceDirectory + filename));
                }
            }

            return true;

        }

    }
}
