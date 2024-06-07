using Data_Access_Layer;
using Data_Access_Layer.Common;
using Data_Access_Layer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_logic_Layer
{
    public class BALCommon
    {
        private readonly DALCommon _dALCommon;

        public BALCommon(DALCommon dALCommon)
        {
            _dALCommon = dALCommon;
        }

        public async Task<List<DropDown>> GetMissionTheme()
        {
            return await _dALCommon.MissionThemeList();
        }
        public async Task<List<DropDown>> GetMissionSkill()
        {
            return await _dALCommon.MissionSkillList();
        }

        public async Task<List<DropDown>> CountryList()
        {
            return await _dALCommon.CountryList();
        }

        public async Task<List<DropDown>> CityList(int id)
        {
            return await _dALCommon.CityList(id);
        }
    }
}
