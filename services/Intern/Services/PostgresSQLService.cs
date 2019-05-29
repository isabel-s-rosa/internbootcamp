using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Intern.Domains;
using Intern.Models;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Intern.Services
{
    public class PostgresSQLService : IDatabaseService
    {
        private readonly string m_connectionString;
        public PostgresSQLService(IConfiguration configuration)
        {
            m_connectionString = configuration.GetValue<string>("ConnectionString");
        }
        public async Task<IEnumerable<Image>> GetAllImagesAsync()
        {
            using (var conn = new NpgsqlConnection(m_connectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<Image>(
                "intern.images_get_all",
                null,
                commandType: CommandType.StoredProcedure);
            }
        }
    }
}
