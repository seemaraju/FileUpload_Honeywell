using FileUpload_Honeywell.ViewModels;
using System.Linq.Expressions;
using System.Reflection;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
namespace FileUpload_Honeywell.Models
{
    public class MockFileDetailsRepository : IFileDetails
    {
        private List<FileDetails> _fileDetailList;

        #region
        ///<summary>
        ///Constructor call       
        /// </summary>  
        /// <returns></returns>
        #endregion
        public MockFileDetailsRepository()
        {
            _fileDetailList = new List<FileDetails>()
            {
            
            };
        }
        #region
        ///<summary>
        ///Add method gets call when new file has uploaded and store it in list and get max id no.
        ///it accept filedetails as param
        /// </summary>  
        /// <param name="fileDetails"></param>
        /// <returns></returns>
        #endregion
        public FileDetails Add(FileDetails fileDetails)
        {
            try
            {
                if (_fileDetailList.Count == 0)
                {
                    fileDetails.Id = 1;
                }
                else
                {
                    fileDetails.Id = _fileDetailList.Max(item => item.Id) + 1;
                }

                _fileDetailList.Add(fileDetails);
                return fileDetails;

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally 
            { 

            }

            return fileDetails;
        }
        #region
        ///<summary>
        ///GetAll method returns all upload files.        
        /// </summary>        
        /// <returns></returns>
        #endregion
        public List<FileDetails> GetAll()
        {
            
            return _fileDetailList;
        }
        #region
        ///<summary>
        ///when user wants to filter files based on id then GetFileDetails gets call.
        ///it accept id as param
        /// </summary>  
        /// <param name="id"></param>
        /// <returns></returns>
        #endregion
        public FileDetails GetFileDetails(int id)
        {
            return _fileDetailList.FirstOrDefault(e=>e.Id == id);
            
        }
    }
}
