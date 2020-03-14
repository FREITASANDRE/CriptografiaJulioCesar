using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
