using BlazorInputFile;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ODA.Services.Implementations
{
    public class BlazorInputFileService : IBlazorInputFileService
    {
        IWebHostEnvironment HostEnv { get; set; }
        public BlazorInputFileService(IWebHostEnvironment environment)
        {
            HostEnv = environment;
        }

        public async Task<string> UploadAsync(IFileListEntry fileListEntry, string subDirectory)
        {
            //Create Save Path//Generate New Token
            string fileName = Guid.NewGuid().ToString() + fileListEntry.Name;
            var path = Path.Combine(HostEnv.ContentRootPath, "wwwroot", "images", subDirectory, fileName);
            var ms = new MemoryStream();
            await fileListEntry.Data.CopyToAsync(ms);
            //Use Stream to Copy
            using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write))
                ms.WriteTo(file);
            return fileName;
        }
    }
}
