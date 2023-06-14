using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com2IoT.Services
{
    public class FileService
    {
        public string fileUrl { get; set; } = string.Empty;
        public FileService()
        {
            UpdateFileUrl();
        }

        public void UpdateFileUrl()
        {
            fileUrl = @".\logs\" + DateTime.Now.ToString("d") + ".txt";
        }

        public void WriteFIle(string data)
        {
            if (!Directory.Exists(@".\logs"))
            {
                Directory.CreateDirectory(@".\logs");
            }

            StreamWriter sw = new StreamWriter(fileUrl, true, Encoding.ASCII);
            sw.WriteLine("[" + DateTime.UtcNow.ToString("G") + "] " + data);
            sw.Close();
        }
    }
}
