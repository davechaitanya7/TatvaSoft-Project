using Business_logic_Layer;
using Data_Access_Layer;
using Data_Access_Layer.Repository.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {       
        private readonly BALLogin _balLogin;
        private readonly BALAdminUser _bALAdminUser;
        ResponseResult result = new ResponseResult();
        public LoginController(BALLogin balLogin,BALAdminUser bALAdminUser)
        {           
            _balLogin = balLogin;
            _bALAdminUser = bALAdminUser;
        }
            

        [HttpPost]
        [Route("LoginUser")]
        public ResponseResult LoginUser(User user)
        {
            try
            {                                
                result.Data = _balLogin.LoginUser1(user);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
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
        //        return StatusCode(500, ex.Message);
        //    }
        //}


        [HttpGet("UserDetailList")]
        public async Task<IActionResult> GetUserDetailList()
        {
            try
            {
                var userDetailList = await _bALAdminUser.UserDetailListAsync();
                return Ok(new ResponseResult { Data = userDetailList, Result = ResponseStatus.Success });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Error, Message = ex.Message });
            }
        }


        [HttpPost]
        [Route("CreateUser")]
        public ResponseResult CreateUser(User user)
        {
            try
            {
                result.Data = _balLogin.RegisterUser(user);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Success;
                result.Message = ex.Message;
            }
            return result;
        }


        [HttpDelete("DeleteUserAndUserDetail/{userId}")]
        public async Task<IActionResult> DeleteUserAndUserDetail(int userId)
        {
            try
            {
                var result = await _bALAdminUser.DeleteUserAndUserDetailAsync(userId);
                return Ok(new ResponseResult { Data = result, Result = ResponseStatus.Success });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Error, Message = ex.Message });
            }
        }


        [HttpGet("GetUserById/{userId}")]
        public async Task<IActionResult> GetUserDetailsById(int userId)
        {
            try
            {
                var result = await _bALAdminUser.GetUserByIdAsync(userId);
                return Ok(new ResponseResult { Data = result, Result = ResponseStatus.Success });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Error, Message = ex.Message });
            }
        }
        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUserDetails(User user)
        {
            try
            {
                var result = _balLogin.UpdateUserAsync(user);
                return Ok(new ResponseResult { Data= result, Result = ResponseStatus.Success });
            }
            catch(Exception ex) 
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Error, Message = ex.Message });
            }
        }
    }
}
