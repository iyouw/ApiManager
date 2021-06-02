﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiManager.Infra.Dal.Abstraction
{
    public interface IDbContext
    {
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object param);
        Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param);
        Task<T> QuerySingleOrDefaultAsync<T>(string sql, object param);

        Task<IEnumerable<T>> GetListAsync<T>() where T : class;
        Task<T> GetByIdAsync<T,TKey>(TKey id) where T : class;

        void AddCommand(Func<IDbConnection, IDbTransaction, Task> command);
        void AddCommands(IEnumerable<Func<IDbConnection, IDbTransaction, Task>> commands);
        Task<int> SaveChangeAsync();
    }
}