using System;
using System.IO;
using System.Reflection;

namespace NaniWeb
{
    public static class Utilities
    {
        public static DirectoryInfo CurrentDirectory => new FileInfo(Uri.UnescapeDataString(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath)).Directory;
    }
}