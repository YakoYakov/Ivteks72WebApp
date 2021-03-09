using System.IO;
using System.Reflection;

namespace Ivteks72.Postman.Utilities
{
    class ResourceReader
    {
        public static string GetResource(string key)
        {
            
            var assembly = typeof(PostmanImp).GetTypeInfo().Assembly;
            
            Stream resource = assembly.GetManifestResourceStream($"Ivteks72.PostmanRecoder.Resources.{key}.json");
            using (var reader = new StreamReader(resource))
            {
                return reader.ReadToEnd();
            }
            
        }
    }
}
