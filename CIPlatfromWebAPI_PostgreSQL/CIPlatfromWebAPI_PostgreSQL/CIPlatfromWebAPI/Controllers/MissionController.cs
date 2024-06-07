using Business_logic_Layer;
using Data_Access_Layer.Repository.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController : ControllerBase
    {
        private readonly BALMission _balMission;
        private readonly ResponseResult result = new ResponseResult();
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;

        public MissionController(BALMission balMission, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _balMission = balMission;
            _environment = environment;
        }

        [HttpGet]
        [Route("MissionList")]
        public ResponseResult MissionList()
        {
            try
            {
                result.Data = _balMission.MissionList();
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpGet]
        [Route("MissionListById")]
        public ResponseResult MissionListById(int id)
        {
            try
            {
                result.Data = _balMission.MissionListByID(id);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("AddMission")]
        public ResponseResult AddMission(Missions mission)
        {
            try
            {
                result.Data = _balMission.AddMission(mission);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpPost]
        [Route("UpdateMission")]
        public ResponseResult UpdateMission(Missions mission)
        {
            try
            {
                result.Data = _balMission.UpdateMission(mission);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpDelete]
        [Route("DeleteMission/{id}")]
        public ResponseResult DeleteMission(int id)
        {
            try
            {
                result.Data = _balMission.DeleteMission(id);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }


        [HttpPost]
        [Route("UploadImage")]
        public  ResponseResult UploadImage([FromForm] List<IFormFile> upload)
        {
            try
            {
                string filePath = "";
                string fullPath = "";
                var files = Request.Form.Files;
                List<string> fileList = new List<string>();
                if (files != null && files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        filePath = Path.Combine("UploadMissionImage", "Mission");
                        string fileRootPath = Path.Combine(_environment.WebRootPath, filePath);

                        if (!Directory.Exists(fileRootPath))
                        {
                            Directory.CreateDirectory(fileRootPath);
                        }

                        string name = Path.GetFileNameWithoutExtension(fileName);
                        string extension = Path.GetExtension(fileName);
                        string fullFileName = name + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                        fullPath = Path.Combine(fileRootPath, fullFileName);
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                             file.CopyToAsync(stream);
                        }
                        fileList.Add(fullPath);
                    }
                }
                result.Data = fileList;
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
            }
            return result;
        }

        [HttpPost]
        [Route("UploadDocumnets")]
        public  ResponseResult UploadDocuments([FromForm] List<IFormFile> upload)
        {
            try
            {
                string filePath = "";
                string fullPath = "";
                var files = Request.Form.Files;
                List<string> fileList = new List<string>();
                if (files != null && files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        filePath = Path.Combine("UploadMissionImage", "Mission");
                        string fileRootPath = Path.Combine(_environment.WebRootPath, filePath);

                        if (!Directory.Exists(fileRootPath))
                        {
                            Directory.CreateDirectory(fileRootPath);
                        }

                        string name = Path.GetFileNameWithoutExtension(fileName);
                        string extension = Path.GetExtension(fileName);
                        string fullFileName = name + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                        fullPath = Path.Combine(fileRootPath, fullFileName);
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                             file.CopyToAsync(stream);
                        }
                        fileList.Add(fullPath);
                    }
                }
                result.Data = fileList;
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
            }
            return result;
        }

        [HttpGet]
        [Route("MissionApplicationApprove/{missionApplicationId}")]
        public ResponseResult MissionApplicationApprove(int missionApplicationId)
        {
            try
            {
                result.Data = _balMission.MissionApplicationApprove(missionApplicationId);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
