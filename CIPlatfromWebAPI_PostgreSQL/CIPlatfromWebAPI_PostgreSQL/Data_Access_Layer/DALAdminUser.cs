using Data_Access_Layer.Migrations;
using Data_Access_Layer.Repository;
using Data_Access_Layer.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User = Data_Access_Layer.Repository.Entities.User;

namespace Data_Access_Layer
{
    public class DALAdminUser
    {
        public readonly AppDbContext _cIdDbContext;

        public DALAdminUser(AppDbContext appDbContext)
        {
            _cIdDbContext = appDbContext;
        }

        public async Task<List<UserDetail>> GetUserDetailsListAsync()
        {
            var userDetails = await (from u in _cIdDbContext.User
                                     join ud in _cIdDbContext.UserDetail on u.Id equals ud.UserId into userDeatilGroup
                                     from userDetail in userDeatilGroup.DefaultIfEmpty()
                                     where !u.IsDeleted && u.UserType == "user" && !userDetail.IsDeleted
                                     select new UserDetail
                                     {
                                         Id = u.Id,
                                         FirstName = u.FirstName,
                                         LastName = u.LastName,
                                         PhoneNumber = u.PhoneNumber,
                                         EmailAddress = u.EmailAddress,
                                         UserType = u.UserType,
                                         UserId = userDetail.Id,
                                         Name = userDetail.Name,
                                         Surname = userDetail.Surname,
                                         EmployeeId = userDetail.EmployeeId,
                                         Department = userDetail.Department,
                                         Title = userDetail.Title,
                                         Manager = userDetail.Manager,
                                         WhyIVolunteer = userDetail.WhyIVolunteer,
                                         CountryId = userDetail.CountryId,
                                         CityId = userDetail.CityId,
                                         Avilability = userDetail.Avilability,
                                         LinkdInUrl = userDetail.LinkdInUrl,
                                         MySkills = userDetail.MySkills,
                                         UserImage = userDetail.UserImage,
                                         Status = userDetail.Status,
                                     }).ToListAsync();
            return userDetails;
        }
        public async Task<string> DeleteUserAndUserDetailAsync(int userId)
        {
            try { 
             string result = "";
             using (var transaction = await _cIdDbContext.Database.BeginTransactionAsync())
             {
                try
                {
                    var userDetail = await _cIdDbContext.UserDetail.FirstOrDefaultAsync(x => x.UserId == userId);
                    if (userDetail != null)
                    {
                        userDetail.IsDeleted = true;
                    }
                    var user = await _cIdDbContext.User.FirstOrDefaultAsync(x => x.Id == userId);
                    if (user != null)
                    {
                        user.IsDeleted = true;
                    }

                    await _cIdDbContext.SaveChangesAsync();

                    await transaction.CommitAsync();

                    result = "Delete User Successfully.";
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw ex;
                }
             }
               return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<User> GetUserById(int userid)
        {
            return await _cIdDbContext.User.Where(x => !x.IsDeleted && x.Id == userid).FirstOrDefaultAsync();
        }
        public List<MissionApplication> GetMissionApplicationList()
        {
            return _cIdDbContext.MissionApplication.Where(ma => !ma.IsDeleted).ToList();
        }
    }
}
