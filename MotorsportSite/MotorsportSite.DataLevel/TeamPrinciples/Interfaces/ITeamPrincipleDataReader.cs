using MotorsportSite.DataLevel.TeamPrinciples.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportSite.DataLevel.TeamPrinciples.Interfaces
{
    public interface ITeamPrincipleDataReader
    {
        Task<List<TeamPrinciple>> GetAllTeamPrinciples();
        Task<TeamPrinciple> GetTeamPrincipleById(int id);

    }
}
