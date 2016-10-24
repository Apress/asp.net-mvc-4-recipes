using CH12.R3.Web.Models;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;

namespace CH12.R3.Web.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            return View("Index");
        }


        public ActionResult UploadFile()
        {
            if (Request.Files.Count > 0)
            {
                //try and connect to storage account
                //connection information and container name are configured in 
                //the web.config file
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                     CloudConfigurationManager.GetSetting("StorageConnectionString"));

                //create a storage client instance
                var storageClient = storageAccount.CreateCloudBlobClient();

                //get a referance to the container
                var storageContainer = storageClient.GetContainerReference(ConfigurationManager.AppSettings.Get("CloudStorageContainerReference"));

                //create storage container if it does not exist
                storageContainer.CreateIfNotExists();
                for(int fileNum=0; fileNum<Request.Files.Count; fileNum++)
                {
                    if (Request.Files[fileNum] != null && Request.Files[fileNum].ContentLength > 0)
                    {
                        //Get a referance to a new block blob from the storage service using the name of the uploaded file
                        var azureBlockBlob = storageContainer.GetBlockBlobReference(Request.Files[fileNum].FileName);

                        //upload the file to the Azure service
                        azureBlockBlob.UploadFromStream(Request.Files[fileNum].InputStream);

                    }
                }
                //view list of files that you have uploaded
                return RedirectToAction("FileList");
            }
            return View("UploadFile");
        }

        public ActionResult FileList()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                     CloudConfigurationManager.GetSetting("StorageConnectionString"));

            var storageClient = storageAccount.CreateCloudBlobClient();

            var storageContainer = storageClient.GetContainerReference(
                ConfigurationManager.AppSettings.Get("CloudStorageContainerReference"));
            var blobsList = new FileListModel(storageContainer.ListBlobs(useFlatBlobListing: true));
            return View("FileList",blobsList);
        }

    }
}
