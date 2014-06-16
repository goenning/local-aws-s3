using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amazon.S3.Model;
using System.Net;
using Amazon.S3;

namespace LocalS3.Test
{
    [TestClass]
    public class BucketTest : LocalS3Test
    {
        [TestMethod]
        public void PutNewBucket()
        {
            var response = this.client.PutBucket(new PutBucketRequest { 
                BucketName = "my-test"
            });

            S3Assert.DirectoryExists("my-test");
        }

        [TestMethod]
        [ExpectedException(typeof(AmazonS3Exception))]
        public void CantPutBucketTwice()
        {
            this.client.PutBucket(new PutBucketRequest { BucketName = "my-test" });
            this.client.PutBucket(new PutBucketRequest { BucketName = "my-test" });
        }

        [TestMethod]
        public void DeleteExistingBucket()
        {
            var response1 = this.client.PutBucket(new PutBucketRequest { BucketName = "my-test" });
            var response2 = this.client.DeleteBucket(new DeleteBucketRequest { BucketName = "my-test" });

            S3Assert.DirectoryDoesNotExists("my-test");
        }

        [TestMethod]
        public void ShouldListAllBuckets()
        {
            this.client.PutBucket(new PutBucketRequest { BucketName = "my-test1" });
            this.client.PutBucket(new PutBucketRequest { BucketName = "my-test2" });
            this.client.PutBucket(new PutBucketRequest { BucketName = "my-test3" });

            var response = this.client.ListBuckets();
            Assert.AreEqual(3, response.Buckets.Count);
            Assert.AreEqual("my-test1", response.Buckets[0].BucketName);
            Assert.AreEqual("my-test2", response.Buckets[1].BucketName);
            Assert.AreEqual("my-test3", response.Buckets[2].BucketName);
        }

        [TestMethod]
        public void CantDeleteBucketWithObjects()
        {
            //Todo
        }
    }
}
