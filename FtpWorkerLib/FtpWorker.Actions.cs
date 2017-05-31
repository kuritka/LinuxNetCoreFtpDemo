using System;
using System.Net;
using FluentFTP;
using System.Threading;
using FtpWorkerLib.Extensions;
using System.IO;
using System.IO.Compression;

namespace FtpWorkerLib
{

  partial class FtpWorker 
     {
        private void Upload(FtpClient conn, string name)
        {
            //download method  exists as well
            conn.UploadFile(name,$"{workingDirectoryUpload}\\{name}");
        }


        private void Download(FtpClient conn )
        {
            foreach (FtpListItem item in conn.GetListing(conn.GetWorkingDirectory(),
                            FtpListOption.Modify | FtpListOption.Size | FtpListOption.DerefLinks)) 
            {
                switch (item.Type) 
                {
                        case FtpFileSystemObjectType.Directory:
                        break;
                        case FtpFileSystemObjectType.File:
                            item.FullName.Message();
                            using(Stream istream = conn.OpenRead(item.FullName)) 
                            {
                                using(var zippedFile = File.Create($"{item.Name}.gz")){
                                    using(var newGzipStream = new GZipStream(zippedFile, CompressionLevel.Optimal)){
                                        istream.CopyTo(newGzipStream);
                                    }
                                }
                            }

                        break;
                        case FtpFileSystemObjectType.Link:
                        break;
                } 
            }
        }

    }
}