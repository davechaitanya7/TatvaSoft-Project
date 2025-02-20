﻿using Data_Access_Layer;
using Data_Access_Layer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_logic_Layer
{
    public class BALMission
    {
        private readonly DALMission _dalMission;

        public BALMission(DALMission dalMission)
        {
            _dalMission = dalMission;
        }

        public List<Missions> MissionList()
        {
            return _dalMission.MissionList();
        }
        public List<Missions> MissionListByID(int ID)
        {
            return _dalMission.MissionDetailById(ID);
        }
        public string AddMission(Missions mission)
        {
            return _dalMission.AddMission(mission);
        }
        public string DeleteMission(int id)
        {
            return _dalMission.DeleteMission(id);
        }
        public string UpdateMission(Missions missions)
        {
            return _dalMission.UpdateMission(missions);
        }
        public List<Missions> ClientSideMissionList(int userId)
        {
            return _dalMission.ClientSideMissionList(userId);
        }


        public string ApplyMission(MissionApplication missionApplication)
        {
            return _dalMission.ApplyMission(missionApplication);
        }

        public string MissionApplicationApprove(int id)
        {
            return _dalMission.MissionApplicationApprove(id);
        }
    }
}
