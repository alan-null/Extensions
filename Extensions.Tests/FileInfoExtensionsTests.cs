using System.IO;
using Xunit;

namespace Extensions.Tests
{
    public class FileInfoExtensionsTests
    {
        [Fact]
        public void ReadLines_Test()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var path = $"{currentDirectory}/test.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            var line1 = "test-content-1";
            var line2 = "test-content-2";
            File.AppendAllLines(path, new[] { line1 });
            File.AppendAllLines(path, new[] { line2 });
            var fileInfo = new FileInfo(path);

            Assert.Equal(new[] { line1, line2 }, fileInfo.ReadLines());
        }
    }
}
