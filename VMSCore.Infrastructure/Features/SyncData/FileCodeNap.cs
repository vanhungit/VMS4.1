using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMSCore.Infrastructure.Features.SyncData
{
    public class FileCodeNap
    {
        public string[] GetAllFile(string LocationFolder)
        {
            string[] files = Directory.GetFiles(LocationFolder).OrderBy(f => int.Parse(Path.GetFileNameWithoutExtension(f))).ToArray();
            return files;
        }
    }
}
