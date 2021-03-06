﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LocalS3.Test
{
    public static class S3Assert
    {
        public static void DirectoryExists(string name)
        {
            string targetPath = Path.Combine(LocalS3Test.TestBasePath, name);
            Assert.True(Directory.Exists(targetPath), string.Format("Directory {0} not found.", targetPath));
        }

        public static void DirectoryDoesNotExists(string name)
        {
            string targetPath = Path.Combine(LocalS3Test.TestBasePath, name);
            Assert.False(Directory.Exists(targetPath), string.Format("Directory {0} should not exists.", targetPath));
        }

        public static void FileExists(string name)
        {
            string targetPath = Path.Combine(LocalS3Test.TestBasePath, name);
            Assert.True(File.Exists(targetPath), string.Format("File {0} not found.", targetPath));
        }
    }
}
