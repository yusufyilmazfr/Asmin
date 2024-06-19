using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Packages.MinIO.Configuration
{
    /// <summary>
    /// MinIO configuration
    /// </summary>
    public class MinIOConfiguration : IMinIOConfiguration
    {
        public string EndPoint { get; set; }
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
    }
}
