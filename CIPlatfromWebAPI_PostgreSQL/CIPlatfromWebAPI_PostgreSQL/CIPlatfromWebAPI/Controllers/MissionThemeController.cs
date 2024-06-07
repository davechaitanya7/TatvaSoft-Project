using Business_logic_Layer;
using Data_Access_Layer.Repository.Entities;
using Data_Access_Layer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Data_Access_Layer;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionThemeController : ControllerBase
    {
        private readonly BALMissionTheme _bALMissionTheme;

        public MissionThemeController(BALMissionTheme bALMissionTheme)
        {
            _bALMissionTheme = bALMissionTheme;
        }

        [HttpGet]
        [Route("GetMissionThemeList")]
        public async Task<ActionResult<ResponseResult>> GetMissionThemeList()
        {
            try
            {
                var result = await _bALMissionTheme.GetMissionThemeListAsync();
                return Ok(new ResponseResult { Data = result, Result = ResponseStatus.Success });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Error, Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("GetMissionThemeById/{id}")]
        public async Task<ActionResult<ResponseResult>> GetMissionThemeById(int id)
        {
            try
            {
                var result = await _bALMissionTheme.GetMissionThemeByIdAsync(id);
                return Ok(new ResponseResult { Data = result, Result = ResponseStatus.Success });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Error, Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("AddMissionTheme")]
        public async Task<ActionResult<ResponseResult>> AddMissionTheme(MissionTheme missionTheme)
        {
            try
            {
                var result = await _bALMissionTheme.AddMissionThemeAsync(missionTheme);
                return Ok(new ResponseResult { Data = result, Result = ResponseStatus.Success });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Error, Message = ex.Message });
            }
        }
        [HttpPost]
        [Route("UpdateMissionTheme")]
        public async Task<ActionResult<ResponseResult>> UpdateMissionTheme(MissionTheme missionTheme)
        {
            try
            {
                var result = await _bALMissionTheme.UpdateMissionSkillAsync(missionTheme);
                return Ok(new ResponseResult { Data = result, Result = ResponseStatus.Success });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Error, Message = ex.Message });
            }
        }
        [HttpDelete]
        [Route("DeleteMissionTheme/{id}")]
        public async Task<ActionResult<ResponseResult>> DeleteMissionTheme(int id)
        {
            try
            {
                var result = await _bALMissionTheme.DeleteMissionThemeAsync(id);
                return Ok(new ResponseResult { Data = result, Result = ResponseStatus.Success });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Error, Message = ex.Message });
            }
        }
    }
}
