using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Asmin.Packages.MinIO.Client;
using Minio;
using Minio.DataModel;

namespace Asmin.Packages.MinIO.Service
{
    class MinIOService : IMinIOService
    {
        private MinioClient _minioClient;

        public MinIOService(IMinIOClientFactory clientFactory)
        {
            _minioClient = clientFactory.Client;
        }

        public async Task<bool> MakeBucketAsync(string bucketName, string loc = "us-east-1")
        {
            bool returnValue = false;

            try
            {
                bool checkBucketExists = await _minioClient.BucketExistsAsync(bucketName);

                if (!checkBucketExists)
                {
                    await _minioClient.MakeBucketAsync(bucketName, loc);
                }

                returnValue = true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"[Make-Bucket]  Exception: {e}");
            }

            return returnValue;
        }

        public async Task<bool> RemoveBucketAsync(string bucketName)
        {
            bool returnValue = false;

            try
            {
                bool checkBucketExists = await _minioClient.BucketExistsAsync(bucketName);

                if (checkBucketExists)
                {
                    await _minioClient.RemoveBucketAsync(bucketName);
                    returnValue = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"[Remove-Bucket]  Exception: {e}");
            }

            return returnValue;
        }

        public Task<bool> BucketExistsAsync(string bucketName)
        {
            return _minioClient.BucketExistsAsync(bucketName);
        }

        public Task<ListAllMyBucketsResult> GetBucketListAsync()
        {
            return _minioClient.ListBucketsAsync();
        }

        public async Task<bool> UploadFileAsync(MemoryStream stream, string bucketName, string fileName)
        {
            bool returnValue = false;

            try
            {
                bool checkBucketExists = await _minioClient.BucketExistsAsync(bucketName);

                if (!checkBucketExists)
                {
                    await _minioClient.MakeBucketAsync(bucketName);
                }

                await _minioClient.PutObjectAsync(bucketName, fileName, stream, stream.Length);

                returnValue = true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"[Upload-Object]  Exception: {e}");
            }

            return returnValue;
        }

        public async Task<bool> DeleteFileAsync(string bucketName, string fileName)
        {
            bool returnValue = false;

            try
            {
                await _minioClient.RemoveObjectAsync(bucketName, fileName);
                returnValue = true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"[Delete-Object]  Exception: {e}");
            }

            return returnValue;
        }

        public async Task<bool> CheckFileExistsAsync(string bucketName, string fileName)
        {
            bool returnValue = false;

            try
            {
                var objectStat = await _minioClient.StatObjectAsync(bucketName, fileName);

                returnValue = objectStat != null;
            }
            catch (Exception e)
            {
                Console.WriteLine($"[Object-Status] Exception: {e.Message}");
            }

            return returnValue;
        }

        public Task<string> GetPresignedObjectUrlAsync(string bucketName, string fileName, int expirySecond = 86400)
        {
            try
            {
                return _minioClient.PresignedGetObjectAsync(bucketName, fileName, expirySecond);
            }
            catch (Exception e)
            {
                Console.WriteLine($"[Presigned-Object-Url] Exception: {e.Message}");
                return Task.FromResult<string>("");
            }
        }
    }
}
