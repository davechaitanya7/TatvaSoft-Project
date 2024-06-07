using Data_Access_Layer.Common;
using Data_Access_Layer.Repository;
using Data_Access_Layer.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class DALCommon
    {
        private readonly AppDbContext _appDbContext;

        public DALCommon(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<DropDown>> MissionThemeList()
        {
            var MissionTheme = await (from Mt in _appDbContext.MissionThemes
                                      //join M in _appDbContext.Missions on Mt.Id.ToString() equals M.MissionThemeId into MissionDetailGroup
                                      //from MissionThemeGroup in MissionDetailGroup
                                      //where MissionThemeGroup.IsDeleted == false
                                      select new DropDown
                                      {
                                          Value = Mt.Id,
                                          Text =  Mt.ThemeName
                                      }).ToListAsync();
                               
            return MissionTheme;
        }

        public async Task<List<DropDown>> MissionSkillList()
        {
            var MissionTheme = await (from Ms in _appDbContext.MissionSkills
                                      //join M in _appDbContext.Missions on Ms.id.ToString() equals M.MissionSkillId into MissionDetailGroup1
                                      //from MissionSkillGroup in MissionDetailGroup1
                                      //where MissionSkillGroup.IsDeleted == false
                                      select new DropDown
                                      {
                                          Value = Ms.id,
                                          Text = Ms.SkillName
                                      }).ToListAsync();

            return MissionTheme;
        }

        public async Task<List<DropDown>> CountryList()
        {
            var CountryList = await (from cl in _appDbContext.Country
                                     select new DropDown
                                     {
                                         Value = cl.Id,
                                         Text = cl.CountryName
                                     }).ToListAsync();
            return CountryList;
        }

        public async Task<List<DropDown>> CityList(int countryId)
        {
            var CountryList = await (from cl in _appDbContext.City
                                     where cl.CountryId == countryId
                                     select new DropDown
                                     {
                                         Value = cl.Id,
                                         Text = cl.CityName
                                     }).ToListAsync();
            return CountryList;
        }
    }
}
