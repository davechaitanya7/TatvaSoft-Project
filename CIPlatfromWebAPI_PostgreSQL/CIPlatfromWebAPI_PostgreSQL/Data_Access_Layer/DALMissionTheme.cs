using Data_Access_Layer.Repository.Entities;
using Data_Access_Layer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer
{
    public class DALMissionTheme
    {
        private readonly AppDbContext _CIdDbContext;

        public DALMissionTheme(AppDbContext cIdDbContext)
        {
            _CIdDbContext = cIdDbContext;
        }

        public async Task<List<MissionTheme>> GetMissionThemeAsync()
        {
            return await _CIdDbContext.MissionThemes.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<MissionTheme> GetMissionThemeByIdAsync(int id)
        {
            return await _CIdDbContext.MissionThemes.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();
        }


        public async Task<string> AddMissionThemeAsync(MissionTheme missionTheme)
        {
            try
            {
                _CIdDbContext.MissionThemes.Add(missionTheme);
                await _CIdDbContext.SaveChangesAsync();
                return "Save Theme Successfully.";
            }
            catch (Exception ex)
            {
                throw ex /*new Exception("Error in adding skill.", ex)*/;
            }
        }

        public async Task<string> UpdateMissionThemeAsync(MissionTheme missionTheme)
        {
            try
            {
                var missionThemeU = await _CIdDbContext.MissionThemes.Where(x => x.Id == missionTheme.Id).FirstOrDefaultAsync();
                if (missionThemeU != null)
                {
                    missionThemeU.ThemeName = missionTheme.ThemeName;
                    missionThemeU.Status = missionTheme.Status;
                    await _CIdDbContext.SaveChangesAsync();
                    return "Update Theme Sucessfully";
                }
                else
                {
                    throw new Exception("Mission Theme is Not Exits");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error is Updateing Skill");
            }
        }

        public async Task<string> DeleteMissionThemeAsync(int Id)
        {
            try
            {
                var missionThemeU = await _CIdDbContext.MissionThemes.Where(x => x.Id == Id).FirstOrDefaultAsync();
                if (missionThemeU != null)
                {
                    missionThemeU.IsDeleted = true;
                    await _CIdDbContext.SaveChangesAsync();
                    return "Delete Theme Sucessfully";
                }
                else
                {
                    throw new Exception("Mission Theme is Not Exits");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error is Delete Skill");
            }
        }
    }
}
