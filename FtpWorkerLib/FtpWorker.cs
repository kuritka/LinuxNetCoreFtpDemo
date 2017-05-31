using System;
using System.Net;
using FluentFTP;
using System.Threading;
using FtpWorkerLib.Extensions;
using System.IO;
using System.IO.Compression;


namespace FtpWorkerLib
{

    public interface IFtpWorker
    {
        void Process();
    }

    public partial class FtpWorker : IFtpWorker
    {

        const string workingDirectory = "/test/30052017";
        const string workingDirectoryUpload = "/test_upload/30052017";

        public void Process()
        {
             Console.WriteLine("Connecting to FTP!");

             using (FtpClient conn = new FtpClient()) {
                    conn.Host = "d145wh.forpsi.com";
                    conn.Credentials = new NetworkCredential("...", "...");
                    conn.Connect();

                    if (conn.DirectoryExists(workingDirectory)) 
                    {
                        $"Copying files from {workingDirectory}".Message();
                        conn.SetWorkingDirectory(workingDirectory);
                        Download(conn);
                        Upload(conn,"xml.xml.gz");
                    }
                    else
                    {
                        $"{workingDirectory} doesnt exists".Warn();
                    }
                }
         }

    }
}
