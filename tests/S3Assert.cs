using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalS3.Test
{
    public static class S3Assert
    {
        public static void DirectoryExists(string name)
        {
            string targetPath = Path.Combine(LocalS3Test.TestBasePath, name);
            Assert.IsTrue(Directory.Exists(targetPath), string.Format("Directory {0} not found.", targetPath));
        }

        public static void DirectoryDoesNotExists(string name)
        {
            string targetPath = Path.Combine(LocalS3Test.TestBasePath, name);
            Assert.IsFalse(Directory.Exists(targetPath), string.Format("Directory {0} should not exists.", targetPath));
        }

        public static void FileExists(string name)
        {
            string targetPath = Path.Combine(LocalS3Test.TestBasePath, name);
            Assert.IsTrue(File.Exists(targetPath), string.Format("File {0} not found.", targetPath));
        }
    }
}
