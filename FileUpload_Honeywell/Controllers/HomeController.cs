using FileUpload_Honeywell.Models;
using FileUpload_Honeywell.ViewModels;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace FileUpload_Honeywell.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IFileDetails _fileDetails;
        private readonly IHostingEnvironment _hostingEnvironment;
        public HomeController(IFileDetails filedetails, IHostingEnvironment hostingEnvironment)
        {
            _fileDetails = filedetails;
            _hostingEnvironment = hostingEnvironment;
        }
        #region        
        /// <summary>
        /// Index method 
        /// </summary>        
        /// <returns></returns>
        #endregion
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        #region        
        /// <summary>
        /// When click on Filepath Name in table Edit action method gets call. It accpet id as parameter to filter records from table.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        #endregion
        public IActionResult Edit(int id)
        {
            TempData["ID"] = id;
          
            return RedirectToAction("Create");            
        }

        #region
        /// <summary>
           ///  
        /// </summary>
        /// <returns></returns>
        #endregion
        [Route("")]
        [HttpGet]

        #region
        ///<summary>
        ///When click on Upload menu Create method gets call and return view with select file option.
        ///Also this method calls when user click on particular filepath.
        /// </summary>  
        /// <returns></returns>
        #endregion
        public IActionResult Create()
        {
            try {            

           List<FileDetails> details = _fileDetails.GetAll();
            if (details.Count >0)
            {
                UploadFileCreateViewModel vm = new UploadFileCreateViewModel();
                foreach (var item in details)
                {

                    if (item.Id == Convert.ToInt32(TempData["ID"]))
                    {
                        vm = new UploadFileCreateViewModel
                        {

                            Id = item.Id,
                            FileName = item.FileName,
                            FileSize = item.FileSize,
                            FilePath = item.FilePath,
                            Isselected = true
                           
                        };
                    }
                }             

                vm.FileDetails.AddRange(details);
                return View(vm);
            }
           
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
            }
            return View();
        }

        #region
        /// <summary>   
        ///   After selecting file when user click on upload button Create method gets call and retrun view with data.          
        /// </summary>
        /// <returns></returns>
        #endregion
        [Route("")]
        [HttpPost]
        public IActionResult Create(UploadFileCreateViewModel model)
        {
            try
            {

            
            if (ModelState.IsValid)
            {

                if (model.UploadFiles != null && model.UploadFiles.Count > 0)
                {
                    foreach (IFormFile file in model.UploadFiles)
                    {
                        string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                        
                        string uniqueFileName = file.FileName;
                        string filePath = Path.Combine(uploadFolder, uniqueFileName);
                        file.CopyTo(new FileStream(filePath, FileMode.Create));

                        FileDetails newFileDetails = new FileDetails()
                        {
                            FileName = file.FileName,
                            FileSize = file.Length,
                            Id = model.Id,
                            FilePath = filePath,
                            Isselected = true

                        };

                        var result = _fileDetails.Add(newFileDetails);

                        model.FileDetails.Add(result);

                    }
                  

                }
                return View(model);
            }
           
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {

            }
            return View();
        }
      

    }
}