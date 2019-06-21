using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ArrowPointCANBusTool.Services
{
    public class UpdateService
    {

        public const string RELEASE_URL_API = "https://api.github.com/repos/Prohelion/ArrowPoint-CANbus-Tools/releases/latest";
        public const string RELEASE_URL = "https://github.com/Prohelion/ArrowPoint-CANbus-Tools/releases";

        private int releaseNumber = 0;
        private int productVersion = 0;

        private string releaseTag = "";
        private string releaseName = "";
        private string releaseDesc = "";
        private bool gotReleaseDetails = false;        

        public UpdateService()
        {
            try
            {

                using (var webClient = new System.Net.WebClient())
                {
                    webClient.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko");
                    webClient.Headers.Add("Content-Type", "application/json");

                    var json = webClient.DownloadString(RELEASE_URL_API);
                    // Now parse with JSON.Net
                    dynamic release = JsonConvert.DeserializeObject(json);
                    releaseTag = release.tag_name;
                    releaseName = release.name;
                    releaseDesc = release.body;

                    Assembly assembly = Assembly.GetExecutingAssembly();
                    FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
                    string version = fileVersionInfo.ProductVersion;

                    releaseNumber = RelesaseNumberToInt(releaseTag);
                    productVersion = RelesaseNumberToInt(version);
                    gotReleaseDetails = true;

                }
        
            } catch (WebException ex)
            {

                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = ex.Response as HttpWebResponse;
                    if (response != null)
                    {
                        Console.WriteLine("HTTP Status Code: " + (int)response.StatusCode);
                    }
                    else
                    {
                        // no http status code available
                    }
                }

                    gotReleaseDetails = false;
            }
        }

        private int RelesaseNumberToInt(string releaseNumber)
        {
            int parsedNumber = 0;

            try
            {
                int[] nums = Array.ConvertAll(releaseNumber.Split('.'), int.Parse);

                if (nums.Length >= 0) parsedNumber = parsedNumber + nums[0] * 10000;
                if (nums.Length >= 1) parsedNumber = parsedNumber + nums[1] * 100;
                if (nums.Length >= 2) parsedNumber = parsedNumber + nums[2];
            }
            catch { }
            
            return parsedNumber;
        }

        public bool IsUpdateAvailable
        {
            get
            {
                if (gotReleaseDetails == false) return false;
                return releaseNumber > productVersion;
            }
        }

        public string ReleaseName
        {
            get
            {
                return releaseName;
            }
        }

        public string ReleaseNumber
        {
            get
            {
                return releaseTag;
            }
        }


        public string ReleaseDesc
        {
            get
            {
                return releaseDesc;
            }
        }
    }
}
