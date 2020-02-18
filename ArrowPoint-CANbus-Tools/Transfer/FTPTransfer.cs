using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;


namespace ArrowPointCANBusTool.Transfer
{
    class FTPTransfer : TransferBase
    {
        public override bool TestConnection()
        {
            try
            {
                UriBuilder builder = new UriBuilder("ftp://" + Host + "/test")
                {
                    Port = Port
                };

                // Get the object used to communicate with the server.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(builder.Uri);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.UsePassive = true;

                // This example assumes the FTP site uses anonymous logon.
                request.Credentials = new NetworkCredential(Username, Password);

                Stream requestStream = request.GetRequestStream();

                requestStream.Close();                

                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        public override bool UploadFile(string filename)
        {

            FileInfo fileInf = new FileInfo(filename);
            string uri = "ftp://" + Host + "/" + fileInf.Name;

            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(uri));
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.UsePassive = true;
            request.UseBinary = true;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential(Username, Password);

            // Copy the contents of the file to the request stream.
            byte[] fileContents  = File.ReadAllBytes(filename);
            request.ContentLength = fileContents.Length;

            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(fileContents, 0, fileContents.Length);
            }

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                Console.WriteLine($"Upload File Complete, status {response.StatusDescription}");
            }            

            return true;
        }
    }
}

