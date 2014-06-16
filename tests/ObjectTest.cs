using Amazon.S3.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace LocalS3.Test
{
    [TestClass]
    public class ObjectTest : LocalS3Test
    {
        private string existingBucket = "object-test-bucket";
        private string missedBucket = "some-other-bucket";

        [TestInitialize]
        public void SetUp()
        {
            this.client.PutBucket(new PutBucketRequest { BucketName = existingBucket });
        }

        [TestMethod]
        public void PutObjectOnRoot()
        {
            var response = this.client.PutObject(new PutObjectRequest 
            { 
                BucketName = existingBucket, 
                Key = "demo.txt",
                InputStream = File.Open("assets/demo.txt", FileMode.Open, FileAccess.Read)
            });

            S3Assert.FileExists("object-test-bucket/demo.txt");
        }
    }
}
