using Microsoft.Extensions.Configuration;
using MotorsportSite.DataLevel.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MotorsportSite.DataLevel.Services
{
    public class ConnectionProvider : IConnectionProvider
    {
        private readonly IConfiguration _configuration;

        public ConnectionProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection Get()
        {
            var conn = _configuration.GetConnectionString("SiteDB");

            return new SqlConnection(conn);
        }
    }
}
