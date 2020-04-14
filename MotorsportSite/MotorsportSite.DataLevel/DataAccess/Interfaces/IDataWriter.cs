using MotorsportSite.DataLevel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportSite.DataLevel.DataAccess.Interfaces
{
    public interface IDataWriter
    {
        Task<int> CreateTeam(Team team);

        Task UpdateTeamLeaveDate(int id, DateTime deletedDate);

    }
}
