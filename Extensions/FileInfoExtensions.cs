using System.Collections.Generic;
using System.IO;

namespace Extensions
{
    public static class FileInfoExtensions
    {
        public static IEnumerable<string> ReadLines(this FileInfo fileInfo)
        {
            using (StreamReader sr = fileInfo.OpenText())
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    yield return s;
                }
            }
        }
    }
}
