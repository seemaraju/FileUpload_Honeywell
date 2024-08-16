using FileUpload_Honeywell.ViewModels;

namespace FileUpload_Honeywell.Models
{
    public interface IFileDetails
    {
        FileDetails GetFileDetails(int id);
        FileDetails Add(FileDetails fileDetails);
        List<FileDetails> GetAll();
    }
}
