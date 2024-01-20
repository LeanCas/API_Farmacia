﻿using Dapper;
using Farmacia.Application.Interface.Interfaces;
using Farmacia.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly ApplicationDBContext _dbContext;

        public GenericRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync(string storeProcedure)
        {
            using var connection = _dbContext.CreateConnection;

            return await connection.QueryAsync<T>(storeProcedure, commandType: CommandType.StoredProcedure);
        }

        public async Task<T> GetByIdAsync(string storeProcedure, object parameter)
        {
            using var connection = _dbContext.CreateConnection;
            var objParam = new DynamicParameters(parameter);
            return await connection.QuerySingleOrDefaultAsync<T>(storeProcedure, param: objParam, commandType: CommandType.StoredProcedure);
        }
        
        public async Task<bool> ExecAsync(string storeProcedure, object parameter)
        {
            using var connection = _dbContext.CreateConnection;
            var objParam = new DynamicParameters(parameter);
            var recordAffected = await connection
                .ExecuteAsync(storeProcedure, param: objParam, commandType: CommandType.StoredProcedure);
            return recordAffected > 0;
        }
    }
}
