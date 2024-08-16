using FileUpload_Honeywell.Models;
using Microsoft.AspNetCore.Http;

namespace FileUpload_Honeywell.ViewModels
{
    public class UploadFileCreateViewModel
    {
        public List<IFormFile>? UploadFiles { get; set; }
        public string? FileName { get; set; }
        public long FileSize { get; set; }
        public int Id { get; set; }
        public string? FilePath { get; set; }
        public List<FileDetails> FileDetails = new List<FileDetails>();

        public bool Isselected { get; set; }
    }
}
