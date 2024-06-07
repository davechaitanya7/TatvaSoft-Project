using Data_Access_Layer;
using Data_Access_Layer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_logic_Layer
{
    public class BALMissionSkill
    {
        private readonly DALMissionSkill _dALMissionSkill;

        public BALMissionSkill(DALMissionSkill dALMissionSkill)
        {
            _dALMissionSkill = dALMissionSkill;
        }

        public async Task<List<MissionSkill>> GetMissionSkillListAsync()
        {
            return await _dALMissionSkill.GetMissionSkillsAsync();
        }
        public async Task<MissionSkill> GetMissionSkillByIdAsync(int id)
        {
            return await _dALMissionSkill.GetMissionSkillByIdAsync(id);
        }
        public async Task<string> AddMissionSkillAsync(MissionSkill missionSkill)
        {
            return await _dALMissionSkill.AddMissionSkillAsync(missionSkill);
        }
        public async Task<string> UpdateMissionSkillAsync(MissionSkill missionSkill)
        {
            return await _dALMissionSkill.UpdateMissionSkillAsync(missionSkill);
        }
        public async Task<string> DeleteMissionSkillAsync(int id)
        {
            return await _dALMissionSkill.DeleteMissionSkillAsync(id);
        }
    }
}
