using Data_Access_Layer.Repository;
using Data_Access_Layer.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class DALMissionSkill
    {
        private readonly AppDbContext _CIdDbContext;

        public DALMissionSkill(AppDbContext cIdDbContext)
        {
            _CIdDbContext = cIdDbContext;
        }

        public async Task<List<MissionSkill>> GetMissionSkillsAsync()
        {
            return await _CIdDbContext.MissionSkills.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<MissionSkill> GetMissionSkillByIdAsync(int id)
        {
            return await _CIdDbContext.MissionSkills.Where(x => !x.IsDeleted && x.id == id).FirstOrDefaultAsync();
        }


        public async Task<string> AddMissionSkillAsync(MissionSkill missionSkill)
        {
            try
            {
                _CIdDbContext.MissionSkills.Add(missionSkill);
                await _CIdDbContext.SaveChangesAsync();
                return "Save Skill Successfully.";
            }
            catch (Exception ex)
            {
                throw ex /*new Exception("Error in adding skill.", ex)*/;
            }
        }

        public async Task<string> UpdateMissionSkillAsync(MissionSkill missionSkill)
        {
            try
            {
                var missionskillU = await _CIdDbContext.MissionSkills.Where(x => x.id == missionSkill.id).FirstOrDefaultAsync();
                if (missionskillU != null)
                {
                    missionskillU.SkillName = missionSkill.SkillName;
                    missionskillU.status = missionSkill.status;
                    await _CIdDbContext.SaveChangesAsync();
                    return "Update Skill Sucessfully";
                }
                else
                {
                    throw new Exception("Mission Skill is Not Exits");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error is Updateing Skill");
            }
        }

        public async Task<string> DeleteMissionSkillAsync(int Id)
        {
            try
            {
                var missionskillU = await _CIdDbContext.MissionSkills.Where(x => x.id == Id).FirstOrDefaultAsync();
                if (missionskillU != null)
                {
                    missionskillU.IsDeleted = true;
                    await _CIdDbContext.SaveChangesAsync();
                    return "Delete Skill Sucessfully";
                }
                else
                {
                    throw new Exception("Mission Skill is Not Exits");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error is Delete Skill");
            }
        }
    }
}
