using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace LocalS3
{
    public class LocalAmazonS3Client : IAmazonS3
    {
        public string BasePath { get; private set; }
        public LocalAmazonS3Client(string basePath)
        {
            this.BasePath = basePath;
            if (!Directory.Exists(this.BasePath))
                Directory.CreateDirectory(this.BasePath);

        }

        public PutBucketResponse PutBucket(PutBucketRequest request)
        {
            string targetFolder = Path.Combine(this.BasePath, request.BucketName);
            if (Directory.Exists(targetFolder))
                throw new AmazonS3Exception("Bucket already exists.");

            Directory.CreateDirectory(targetFolder);
            return new PutBucketResponse { ContentLength = 0, HttpStatusCode = HttpStatusCode.OK };
        }

        public DeleteBucketResponse DeleteBucket(DeleteBucketRequest request)
        {
            string targetFolder = Path.Combine(this.BasePath, request.BucketName);
            if (!Directory.Exists(targetFolder))
                throw new AmazonS3Exception("Bucket does not exists.");

            Directory.Delete(targetFolder);
            return new DeleteBucketResponse { ContentLength = 0, HttpStatusCode = HttpStatusCode.OK };
        }

        public ListBucketsResponse ListBuckets()
        {
            return this.ListBuckets(new ListBucketsRequest());
        }

        public ListBucketsResponse ListBuckets(ListBucketsRequest request)
        {
            List<S3Bucket> buckets = new List<S3Bucket>();
            foreach (var folder in Directory.EnumerateDirectories(this.BasePath))
                buckets.Add(new S3Bucket { BucketName = Path.GetFileName(folder) });
            return new ListBucketsResponse { Buckets = buckets };
        }

        public GetObjectResponse GetObject(GetObjectRequest request)
        {
            throw new NotImplementedException();
        }

        public DeleteObjectsResponse DeleteObjects(DeleteObjectsRequest request)
        {
            throw new NotImplementedException();
        }

        public DeleteObjectResponse DeleteObject(DeleteObjectRequest request)
        {
            throw new NotImplementedException();
        }

        public ListObjectsResponse ListObjects(ListObjectsRequest request)
        {
            throw new NotImplementedException();
        }

        public PutObjectResponse PutObject(PutObjectRequest request)
        {
            string targetFile = Path.Combine(this.BasePath, request.BucketName, request.Key);
            Directory.CreateDirectory(Path.GetDirectoryName(targetFile));
            using (request.InputStream)
            { 
                using(Stream target = File.Create(targetFile))
                {
                    request.InputStream.CopyTo(target);
                }
            }
            return new PutObjectResponse();
        }

        public void Dispose()
        {

        }

        private void CreateDirectory(string path)
        {

        }

        #region Not Implemented Methods

        public AbortMultipartUploadResponse AbortMultipartUpload(AbortMultipartUploadRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<AbortMultipartUploadResponse> AbortMultipartUploadAsync(AbortMultipartUploadRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public CompleteMultipartUploadResponse CompleteMultipartUpload(CompleteMultipartUploadRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<CompleteMultipartUploadResponse> CompleteMultipartUploadAsync(CompleteMultipartUploadRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public CopyObjectResponse CopyObject(CopyObjectRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<CopyObjectResponse> CopyObjectAsync(CopyObjectRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public CopyPartResponse CopyPart(CopyPartRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<CopyPartResponse> CopyPartAsync(CopyPartRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<DeleteBucketResponse> DeleteBucketAsync(DeleteBucketRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public DeleteBucketPolicyResponse DeleteBucketPolicy(DeleteBucketPolicyRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<DeleteBucketPolicyResponse> DeleteBucketPolicyAsync(DeleteBucketPolicyRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public DeleteBucketTaggingResponse DeleteBucketTagging(DeleteBucketTaggingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<DeleteBucketTaggingResponse> DeleteBucketTaggingAsync(DeleteBucketTaggingRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public DeleteBucketWebsiteResponse DeleteBucketWebsite(DeleteBucketWebsiteRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<DeleteBucketWebsiteResponse> DeleteBucketWebsiteAsync(DeleteBucketWebsiteRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public DeleteCORSConfigurationResponse DeleteCORSConfiguration(DeleteCORSConfigurationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<DeleteCORSConfigurationResponse> DeleteCORSConfigurationAsync(DeleteCORSConfigurationRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public DeleteLifecycleConfigurationResponse DeleteLifecycleConfiguration(DeleteLifecycleConfigurationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<DeleteLifecycleConfigurationResponse> DeleteLifecycleConfigurationAsync(DeleteLifecycleConfigurationRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<DeleteObjectResponse> DeleteObjectAsync(DeleteObjectRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<DeleteObjectsResponse> DeleteObjectsAsync(DeleteObjectsRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public GetACLResponse GetACL(GetACLRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GetACLResponse> GetACLAsync(GetACLRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public GetBucketLocationResponse GetBucketLocation(GetBucketLocationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GetBucketLocationResponse> GetBucketLocationAsync(GetBucketLocationRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public GetBucketLoggingResponse GetBucketLogging(GetBucketLoggingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GetBucketLoggingResponse> GetBucketLoggingAsync(GetBucketLoggingRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public GetBucketNotificationResponse GetBucketNotification(GetBucketNotificationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GetBucketNotificationResponse> GetBucketNotificationAsync(GetBucketNotificationRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public GetBucketPolicyResponse GetBucketPolicy(GetBucketPolicyRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GetBucketPolicyResponse> GetBucketPolicyAsync(GetBucketPolicyRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public GetBucketRequestPaymentResponse GetBucketRequestPayment(GetBucketRequestPaymentRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GetBucketRequestPaymentResponse> GetBucketRequestPaymentAsync(GetBucketRequestPaymentRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public GetBucketTaggingResponse GetBucketTagging(GetBucketTaggingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GetBucketTaggingResponse> GetBucketTaggingAsync(GetBucketTaggingRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public GetBucketVersioningResponse GetBucketVersioning(GetBucketVersioningRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GetBucketVersioningResponse> GetBucketVersioningAsync(GetBucketVersioningRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public GetBucketWebsiteResponse GetBucketWebsite(GetBucketWebsiteRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GetBucketWebsiteResponse> GetBucketWebsiteAsync(GetBucketWebsiteRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public GetCORSConfigurationResponse GetCORSConfiguration(GetCORSConfigurationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GetCORSConfigurationResponse> GetCORSConfigurationAsync(GetCORSConfigurationRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public GetLifecycleConfigurationResponse GetLifecycleConfiguration(GetLifecycleConfigurationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GetLifecycleConfigurationResponse> GetLifecycleConfigurationAsync(GetLifecycleConfigurationRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<GetObjectResponse> GetObjectAsync(GetObjectRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public GetObjectMetadataResponse GetObjectMetadata(GetObjectMetadataRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GetObjectMetadataResponse> GetObjectMetadataAsync(GetObjectMetadataRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public GetObjectTorrentResponse GetObjectTorrent(GetObjectTorrentRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GetObjectTorrentResponse> GetObjectTorrentAsync(GetObjectTorrentRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public string GetPreSignedURL(GetPreSignedUrlRequest request)
        {
            throw new NotImplementedException();
        }

        public InitiateMultipartUploadResponse InitiateMultipartUpload(InitiateMultipartUploadRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<InitiateMultipartUploadResponse> InitiateMultipartUploadAsync(InitiateMultipartUploadRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<ListBucketsResponse> ListBucketsAsync(ListBucketsRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public ListMultipartUploadsResponse ListMultipartUploads(ListMultipartUploadsRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ListMultipartUploadsResponse> ListMultipartUploadsAsync(ListMultipartUploadsRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<ListObjectsResponse> ListObjectsAsync(ListObjectsRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public ListPartsResponse ListParts(ListPartsRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ListPartsResponse> ListPartsAsync(ListPartsRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public ListVersionsResponse ListVersions(ListVersionsRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ListVersionsResponse> ListVersionsAsync(ListVersionsRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public PutACLResponse PutACL(PutACLRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PutACLResponse> PutACLAsync(PutACLRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<PutBucketResponse> PutBucketAsync(PutBucketRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public PutBucketLoggingResponse PutBucketLogging(PutBucketLoggingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PutBucketLoggingResponse> PutBucketLoggingAsync(PutBucketLoggingRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public PutBucketNotificationResponse PutBucketNotification(PutBucketNotificationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PutBucketNotificationResponse> PutBucketNotificationAsync(PutBucketNotificationRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public PutBucketPolicyResponse PutBucketPolicy(PutBucketPolicyRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PutBucketPolicyResponse> PutBucketPolicyAsync(PutBucketPolicyRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public PutBucketRequestPaymentResponse PutBucketRequestPayment(PutBucketRequestPaymentRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PutBucketRequestPaymentResponse> PutBucketRequestPaymentAsync(PutBucketRequestPaymentRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public PutBucketTaggingResponse PutBucketTagging(PutBucketTaggingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PutBucketTaggingResponse> PutBucketTaggingAsync(PutBucketTaggingRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public PutBucketVersioningResponse PutBucketVersioning(PutBucketVersioningRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PutBucketVersioningResponse> PutBucketVersioningAsync(PutBucketVersioningRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public PutBucketWebsiteResponse PutBucketWebsite(PutBucketWebsiteRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PutBucketWebsiteResponse> PutBucketWebsiteAsync(PutBucketWebsiteRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public PutCORSConfigurationResponse PutCORSConfiguration(PutCORSConfigurationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PutCORSConfigurationResponse> PutCORSConfigurationAsync(PutCORSConfigurationRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public PutLifecycleConfigurationResponse PutLifecycleConfiguration(PutLifecycleConfigurationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PutLifecycleConfigurationResponse> PutLifecycleConfigurationAsync(PutLifecycleConfigurationRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<PutObjectResponse> PutObjectAsync(PutObjectRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public RestoreObjectResponse RestoreObject(RestoreObjectRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<RestoreObjectResponse> RestoreObjectAsync(RestoreObjectRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public UploadPartResponse UploadPart(UploadPartRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<UploadPartResponse> UploadPartAsync(UploadPartRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
