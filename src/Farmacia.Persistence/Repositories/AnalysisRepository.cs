using Dapper;
using Farmacia.Application.Interface;
using Farmacia.Domain.Entities;
using Farmacia.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Persistence.Repositories
{
    public class AnalysisRepository : IAnalysisRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public AnalysisRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        

        public async Task<IEnumerable<Analysis>> ListAnalysis()
        {
            using var connection = _dbContext.CreateConnection;

            var query = "uspAnalysisList";

            var analysis = await connection.QueryAsync<Analysis>(query, commandType: System.Data.CommandType.StoredProcedure);

            return analysis;
        }
        
        public async Task<Analysis> AnalysisPorID(int analysisId)
        {
            using var connection = _dbContext.CreateConnection;

            var query = "uspAnalysisById";

            var parameters = new DynamicParameters();
            parameters.Add("AnalysisId", analysisId);

            var analysis = await connection
                .QuerySingleOrDefaultAsync<Analysis>(query,param: parameters, commandType: CommandType.StoredProcedure);

            return analysis;

        }

        public async Task<bool> AnalysisRegister(Analysis analysis)
        {
            using var connection = _dbContext.CreateConnection;

            var query = "uspAnalysisRegister";

            var parameters = new DynamicParameters();
            parameters.Add("Name", analysis.Name);
            parameters.Add("State", 1);
            parameters.Add("AuditCreateDate", DateTime.Now);

            var recordsAffected = await connection
                .ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);

            return recordsAffected > 0;

        }

        public async Task<bool> AnalysisEdit(Analysis analysis)
        {
            using var connection = _dbContext.CreateConnection;

            var query = "uspAnalysisEdit";

            var parameters = new DynamicParameters();
            parameters.Add("AnalysisId", analysis.AnalysisId);
            parameters.Add("Name", analysis.Name);

            var recordsAffected = await connection
                .ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);

            return recordsAffected > 0;
        }

        public async Task<bool> AnalysisDelete(int analysisId)
        {
            using var connection = _dbContext.CreateConnection;

            var query = "uspAnalysisDelete";

            var parameters = new DynamicParameters();
            parameters.Add("AnalysisId", analysisId);

            var recordsAffected = await connection
                .ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);

            return recordsAffected > 0;
        }
    }
}
