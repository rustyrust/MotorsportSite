using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MotorsportSite.DataLevel.Services.Interfaces
{
    public interface IConnectionProvider
    {
        SqlConnection Get();
    }
}
