using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalS3.Test
{
    public abstract class LocalS3Test
    {
        public const string TestBasePath = @"C:\temp\local-s3";
        protected LocalAmazonS3Client client;

        public LocalS3Test()
        {
            if (Directory.Exists(TestBasePath))
                Directory.Delete(TestBasePath, true);

            this.client = new LocalAmazonS3Client(TestBasePath);
        }
    }
}
