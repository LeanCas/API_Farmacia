using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Persistence.Context
{
    public class ApplicationDBContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public ApplicationDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("FarmaciaConnection")!;
        }

        public IDbConnection CreateConnection => new SqlConnection(_connectionString);
    }
}
