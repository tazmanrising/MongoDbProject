using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Web.WebApi;
using Umbraco.Core;
using Umbraco.Core.Models;

namespace JobManager.Controllers.APIs
{
    public class ProfileApiController : UmbracoApiController
    {
        [HttpGet]
        public HttpResponseMessage GetCurrentMemberProfile()
        {

            var memberId = Members.GetCurrentMemberId();
            var currentMember = Members.GetById(memberId);

            var response = Request.CreateResponse(HttpStatusCode.OK, currentMember);
            return response;
        }

        [HttpGet]
        public HttpResponseMessage GetMemberProfile(int id)
        {

            var currentMember = Members.GetById(id);


            var response = Request.CreateResponse(HttpStatusCode.OK, currentMember.GetProperty("memberProfilePicture"));
            return response;
        }


        [HttpPost]
        public HttpResponseMessage SaveImage()
        {

            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var filePath = HttpContext.Current.Server.MapPath("~/" + postedFile.FileName);
                    postedFile.SaveAs(filePath);
                    // NOTE: To store in memory use postedFile.InputStream
                }

                return Request.CreateResponse(HttpStatusCode.Created);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);

        }

        [HttpPost]
        public async Task<HttpResponseMessage> AddFile()
        {
            try
            {

                var memberId = Members.GetCurrentMemberId();
                var currentMember = Members.GetById(memberId);

                //========================================

                //https://our.umbraco.org/forum/umbraco-7/using-umbraco-7/64041-Unable-to-save-an-image-into-a-media-file-via-mediaservice
                //The method overloads you are looking for are actually extension methods for IContentBase 
                //which should become available to you by referencing the namespace:
                //using Umbraco.Core.Models;

                //var filePath = @"C:\MyImage.jpg";
                var filePath = HttpContext.Current.Server.MapPath("~/App_Data/TEMP/FileUploads/Tom.png");
                var file = new FileStream(filePath, FileMode.Open);

                var parent = Services.MediaService.GetRootMedia().Single();
                var media = Services.MediaService.CreateMedia("File1", parent, "Image");
                media.SetValue("umbracoFile", Path.GetFileName(filePath), file);

                Services.MediaService.Save(media);

                
                //var oldPic = currentMember.GetPropertyValue("memberProfilePicture");
                
                //var memberPic = currentMember.
                // .SetValue("favouriteLanguage", "Ruby");
                
                //The MemberService is available through the ApplicationContext, 
                //but the if you are using a SurfaceController or the UmbracoUserControl then the MemberService is available through a local Services property.

                //var memberService = ApplicationContext.Current.Services.MemberService;
                //memberService.Save(currentMember.Name);


                //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound);

                var memberService = ApplicationContext.Current.Services.MemberService;
                //var memberId = Members.GetCurrentMember().Id;
                var member = memberService.GetById(memberId);
                string xfilePath = HttpContext.Current.Server.MapPath("~/App_Data/TEMP/FileUploads/Tom.png");
                //1017
                member.SetValue("memberProfilePicture", media);
                memberService.Save(member);




                //Here is how to show an image from an umbraco 7 media picker, and show it on the web page
                //<img src =”@Umbraco.Media(CurrentPage.myImage).Url” alt =”@CurrentPage.title” />





                //mediaService.Save(newImage);
                //if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(originalPath)))
                //{
                //    System.IO.File.Delete(HttpContext.Current.Server.MapPath(originalPath));
                //}
                //return PartialView("File");
                //==================================

                //string originalPath = HttpContext.Current.Server.MapPath("~/App_Data/TEMP/FileUploads/Tom.png");
                //IMediaService mediaService = ApplicationContext.Current.Services.MediaService;
                //var newImage = mediaService.CreateMedia("myTestImage", -1, "Image");
                //byte[] buffer = System.IO.File.ReadAllBytes(System.IO.Path.GetFullPath(HttpContext.Current.Server.MapPath(originalPath)));
                //MemoryStream memoryStream = new MemoryStream(buffer);
                //newImage.SetValue("umbracoFile", "myNewImage.png", memoryStream);
                //////https://our.umbraco.org/Documentation/Reference/Management/Models/Media
                ////SetValue("umbracoFile", fileName, fileStream)
                ////mediaService.Save(newImage);
                //if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(originalPath)))
                //{
                //    System.IO.File.Delete(HttpContext.Current.Server.MapPath(originalPath));
                //}




                //if (!Request.Content.IsMimeMultipartContent())
                //{
                //    this.Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
                //}

                string root = HttpContext.Current.Server.MapPath("~/App_Data/TEMP/FileUploads");
                var provider = new MultipartFormDataStreamProvider(root);
                var result = await Request.Content.ReadAsMultipartAsync(provider);

                //// On upload, files are given a generic name like "BodyPart_26d6abe1-3ae1-416a-9429-b35f15e6e5d5"
                //// so this is how you can get the original file name
                var originalFileName = GetDeserializedFileName(result.FileData.First());

                //var uploadedFileInfo = new FileInfo(result.FileData.First().LocalFileName);
                //string path = result.FileData.First().LocalFileName;

                //Do whatever you want to do with your file here

                return this.Request.CreateResponse(HttpStatusCode.OK, originalFileName);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        private string GetDeserializedFileName(MultipartFileData fileData)
        {
            var fileName = GetFileName(fileData);
            return JsonConvert.DeserializeObject(fileName).ToString();
        }

        public string GetFileName(MultipartFileData fileData)
        {
            return fileData.Headers.ContentDisposition.FileName;
        }
    }
}
