using Amazon.S3.Model;
using System.IO;
using Xunit;

namespace LocalS3.Test
{
    public class ObjectTest : LocalS3Test
    {
        private string existingBucket = "object-test-bucket";
        private string missedBucket = "some-other-bucket";

        [Fact]
        public void SetUp()
        {
            this.client.PutBucket(new PutBucketRequest { BucketName = existingBucket });
        }

        [Fact]
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
