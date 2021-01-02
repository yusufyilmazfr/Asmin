using System;
using System.Collections.Generic;
using System.Text;
using Minio;

namespace Asmin.Packages.MinIO.Client
{
    /// <summary>
    /// IMinIOClient provides MinIO client instance.
    /// </summary>
    interface IMinIOClientFactory
    {
        /// <summary>
        /// Current instance
        /// </summary>
        MinioClient Client { get; }
    }
}
