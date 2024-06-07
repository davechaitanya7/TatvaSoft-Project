using Business_logic_Layer;
using Data_Access_Layer.Repository.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Common : ControllerBase
    {

        private readonly BALCommon _bALCommon;

        public Common(BALCommon bALCommon)
        {
            _bALCommon = bALCommon;
        }

        [HttpGet]
        [Route("GetMissionTheme")]
        public async Task<IActionResult> GetMissionTheme()
        {
            try
            {
                var MissionThemeList = await _bALCommon.GetMissionTheme();
                return Ok(new ResponseResult { Data = MissionThemeList, Result = ResponseStatus.Success });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Error, Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetMissionSkill")]
        public async Task<IActionResult> GetMissionSkill()
        {
            try
            {
                var MissionThemeList = await _bALCommon.GetMissionSkill();
                return Ok(new ResponseResult { Data = MissionThemeList, Result = ResponseStatus.Success });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Error, Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("CountryList")]
        public async Task<IActionResult> CountryList()
        {
            try
            {
                var MissionThemeList = await _bALCommon.CountryList();
                return Ok(new ResponseResult { Data = MissionThemeList, Result = ResponseStatus.Success });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Error, Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("CityList/{CountryId}")]
        public async Task<IActionResult> CityList(int CountryId)
        {
            try
            {
                var MissionThemeList = await _bALCommon.CityList(CountryId);
                return Ok(new ResponseResult { Data = MissionThemeList, Result = ResponseStatus.Success });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Error, Message = ex.Message });
            }
        }
    }
}
