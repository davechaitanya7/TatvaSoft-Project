using Business_logic_Layer;
using Data_Access_Layer.Repository.Entities;
using Data_Access_Layer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminUserController : ControllerBase
    {
        private readonly BALAdminUser _bALAdminUser;
        ResponseResult result = new ResponseResult();

        public AdminUserController(BALAdminUser bALAdminUser)
        {
            _bALAdminUser = bALAdminUser;
        }

        //[HttpGet("UserDetailList")]
        //public async Task<IActionResult> GetUserDetailList()
        //{
        //    try
        //    { 
        //        var userDetailList = await _bALAdminUser.UserDetailListAsync();
        //        return Ok(userDetailList);
        //    }
        //    catch (Exception ex) 
        //    { 
        //       return StatusCode(500, ex.Message);
        //    }
        //}

        [HttpGet]
        [Route("UserDetailList")]
        public ResponseResult UserDetailList()
        {
            try
            {
                result.Data = _bALAdminUser.UserDetailListAsync();
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Success;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpGet]
        [Route("MissionApplicationList")]
        public ResponseResult MissionApplicationList()
        {
            try
            {
                result.Data = _bALAdminUser.GetMissionApplicationList();
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Result = ResponseStatus.Error;
            }
            return result;
        }
    }
}
