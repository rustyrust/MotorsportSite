using MotorsportSite.DataLevel.TeamPrinciples.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportSite.DataLevel.TeamPrinciples.Interfaces
{
    public interface ITeamPrincipleDataWriter
    {
        Task<int> AddATeamPrinciple(TeamPrinciple teamPrinciple);
        Task UpdateTeamPrincipleLeaveDate(int id, DateTime deletedDate);

    }
}
