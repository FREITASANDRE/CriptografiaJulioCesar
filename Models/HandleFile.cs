using Newtonsoft.Json;
using System.IO;

namespace ConvertCriptJulioCesar
{
    public static class HandleFile
    {
        public static void SaveFile(string pFileName, dynamic pContent)
        {
            using (StreamWriter lOutputFile = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), pFileName)))
            {
                lOutputFile.Write(JsonConvert.SerializeObject(pContent));
            }
        }

    }
}
