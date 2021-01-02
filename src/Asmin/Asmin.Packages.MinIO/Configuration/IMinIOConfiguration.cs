using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Packages.MinIO.Configuration
{
    /// <summary>
    /// MinIO configuration
    /// </summary>
    public interface IMinIOConfiguration
    {
        /// <summary>
        /// MinIO endpoint, IP
        /// </summary>
        public string EndPoint { get; set; }
        /// <summary>
        /// MinIO user name
        /// </summary>
        public string AccessKey { get; set; }
        /// <summary>
        /// MinIO password
        /// </summary>
        public string SecretKey { get; set; }
    }
}
