using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Minio.DataModel;

namespace Asmin.Packages.MinIO.Service
{
    /// <summary>
    /// This interface provides MinIO client methods.
    /// </summary>
    public interface IMinIOService
    {
        /// <summary>
        /// Make bucket to MinIO server.
        /// It creates new bucket when bucket does not exists.
        /// Return true when bucket was created successfully or bucket exists.
        /// </summary>
        /// <param name="bucketName">MinIO bucket name</param>
        /// <param name="loc">Location, not required. Default us-east-1</param>
        /// <returns></returns>
        Task<bool> MakeBucketAsync(string bucketName, string loc = "us-east-1");
        /// <summary>
        /// Remove specified bucket. Return false when operation unsuccessful or bucket does not exists
        /// </summary>
        /// <param name="bucketName">Bucket name</param>
        /// <returns></returns>
        Task<bool> RemoveBucketAsync(string bucketName);
        /// <summary>
        /// Check specified bucket exists.
        /// </summary>
        /// <param name="bucketName">Bucket name</param>
        /// <returns></returns>
        Task<bool> BucketExistsAsync(string bucketName);
        /// <summary>
        /// Create an async task for list of bucket.
        /// </summary>
        /// <returns></returns>
        Task<ListAllMyBucketsResult> GetBucketListAsync();
        /// <summary>
        /// Add file to MinIO server. If the bucket doesn't exist we create new bucket with specified bucket name.
        /// </summary>
        /// <param name="stream">File stream</param>
        /// <param name="bucketName">MinIO bucket name</param>
        /// <param name="fileName">MinIO file name</param>
        /// <returns></returns>
        Task<bool> UploadFileAsync(MemoryStream stream, string bucketName, string fileName);
        /// <summary>
        /// Remove file from MinIO server.
        /// </summary>
        /// <param name="bucketName">MinIO bucket name</param>
        /// <param name="fileName">MinIO file name</param>
        /// <returns></returns>
        Task<bool> DeleteFileAsync(string bucketName, string fileName);
        /// <summary>
        /// Check file exists. Return true when file exists otherwise false.
        /// </summary>
        /// <param name="bucketName"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        Task<bool> CheckFileExistsAsync(string bucketName, string fileName);
        /// <summary>
        /// Get presigned object link from MinIO server. Return empty string when file or bucket does not exist.
        /// </summary>
        /// <param name="bucketName">MinIO bucket name</param>
        /// <param name="fileName">MinIO file name</param>
        /// <param name="expirySecond">Expiry second, default 1 day.</param>
        /// <returns></returns>
        Task<string> GetPresignedObjectUrlAsync(string bucketName, string fileName, int expirySecond = 86400);
    }
}
