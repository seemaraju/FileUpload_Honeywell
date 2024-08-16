namespace FileUpload_Honeywell.Models
{
    public class FileDetails
    {
        public string? FileName { get; set; } 
        public long FileSize { get; set; }
        public int Id { get; set; }

        public string? FilePath { get; set; }
        public bool Isselected { get; set; }
    }
}
