using BlazorInputFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODA.Services
{
    public interface IBlazorInputFileService
    {
        /// <summary>
        /// Uploads Data string and resturns the saved Name File
        /// </summary>
        /// <param name="fileListEntry"></param>
        /// <param name="subDirectory"></param>
        /// <returns></returns>
        Task<string> UploadAsync(IFileListEntry fileListEntry, string subDirectory);
    }
}
