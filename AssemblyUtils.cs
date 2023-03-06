using System.IO;
using System.Reflection;

namespace Radio
{
    public static class AssemblyUtils
    {
        public static Stream ReadResource(string path)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            return assembly.GetManifestResourceStream(path);
        }

        public static string ReadResourceAsString(string path)
        {
            using (var stream = ReadResource(path))
            {
                if (stream == null)
                    return null;

                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}

// penis