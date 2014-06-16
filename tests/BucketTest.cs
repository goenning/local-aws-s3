using System;
using Amazon.S3.Model;
using System.Net;
using Amazon.S3;
using Xunit;

namespace LocalS3.Test
{
    public class BucketTest : LocalS3Test
    {
        [Fact]
        public void PutNewBucket()
        {
            var response = this.client.PutBucket(new PutBucketRequest { 
                BucketName = "my-test"
            });

            S3Assert.DirectoryExists("my-test");
        }

        [Fact]
        public void CantPutBucketTwice()
        {
            this.client.PutBucket(new PutBucketRequest { BucketName = "my-test" });
            Assert.Throws<AmazonS3Exception>(() =>
            {
                this.client.PutBucket(new PutBucketRequest { BucketName = "my-test" });
            });
        }

        [Fact]
        public void DeleteExistingBucket()
        {
            var response1 = this.client.PutBucket(new PutBucketRequest { BucketName = "my-test" });
            var response2 = this.client.DeleteBucket(new DeleteBucketRequest { BucketName = "my-test" });

            S3Assert.DirectoryDoesNotExists("my-test");
        }

        [Fact]
        public void ShouldListAllBuckets()
        {
            this.client.PutBucket(new PutBucketRequest { BucketName = "my-test1" });
            this.client.PutBucket(new PutBucketRequest { BucketName = "my-test2" });
            this.client.PutBucket(new PutBucketRequest { BucketName = "my-test3" });

            var response = this.client.ListBuckets();
            Assert.Equal(3, response.Buckets.Count);
            Assert.Equal("my-test1", response.Buckets[0].BucketName);
            Assert.Equal("my-test2", response.Buckets[1].BucketName);
            Assert.Equal("my-test3", response.Buckets[2].BucketName);
        }

        [Fact]
        public void CantDeleteBucketWithObjects()
        {
            //Todo
        }
    }
}
