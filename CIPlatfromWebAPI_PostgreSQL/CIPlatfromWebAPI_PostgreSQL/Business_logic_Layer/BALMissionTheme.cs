﻿using Data_Access_Layer;
using Data_Access_Layer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_logic_Layer
{
    public class BALMissionTheme
    {
        private readonly DALMissionTheme _dALMissionTheme;

        public BALMissionTheme(DALMissionTheme dALMissionTheme)
        {
            _dALMissionTheme = dALMissionTheme;
        }

        public async Task<List<MissionTheme>> GetMissionThemeListAsync()
        {
            return await _dALMissionTheme.GetMissionThemeAsync();
        }
        public async Task<MissionTheme> GetMissionThemeByIdAsync(int id)
        {
            return await _dALMissionTheme.GetMissionThemeByIdAsync(id);
        }
        public async Task<string> AddMissionThemeAsync(MissionTheme missionTheme)
        {
            return await _dALMissionTheme.AddMissionThemeAsync(missionTheme);
        }
        public async Task<string> UpdateMissionSkillAsync(MissionTheme missionTheme)
        {
            return await _dALMissionTheme.UpdateMissionThemeAsync(missionTheme);
        }
        public async Task<string> DeleteMissionThemeAsync(int id)
        {
            return await _dALMissionTheme.DeleteMissionThemeAsync(id);
        }
    }
}
