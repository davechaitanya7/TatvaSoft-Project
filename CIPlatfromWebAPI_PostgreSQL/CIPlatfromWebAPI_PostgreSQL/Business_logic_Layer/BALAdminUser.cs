using Data_Access_Layer;
using Data_Access_Layer.Repository;
using Data_Access_Layer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_logic_Layer
{
    public  class BALAdminUser
    {
        private readonly DALAdminUser _dALAdminUser;

        public BALAdminUser(DALAdminUser dALAdminUser)
        {
            _dALAdminUser = dALAdminUser;
        }

        public async Task<List<UserDetail>> UserDetailListAsync()
        {
            return await _dALAdminUser.GetUserDetailsListAsync() ;
        }

        public async Task<string> DeleteUserAndUserDetailAsync(int userid)
        {
            return await _dALAdminUser.DeleteUserAndUserDetailAsync(userid) ;
        }
        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _dALAdminUser.GetUserById(userId);
        }
        public List<MissionApplication> GetMissionApplicationList()
        {
            return _dALAdminUser.GetMissionApplicationList();
        }
    }
}
