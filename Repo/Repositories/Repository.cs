using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Repo.IRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Repositories
{
    public class Repository: IRepository
    {

    }

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public void Add(TEntity entity, string table, string value)
        {
            string sql = $@"INSERT INTO [{table}]" + value;
            DbContext.Execute(sql);
        }

        public void Delete(int id, string table, string value)
        {
            string sql = $@"DELETE [{table}] " + value;
            DbContext.Execute(sql);
        }

        

        public DataTable Get(string table)
        {
            string sql = $@"SELECT * FROM [{table}] ";
            return DbContext.Execute(sql);
        }

        public DataTable GetJoin(string sql)
        {
            return DbContext.Execute(sql);
        }

        public DataTable Get(int id,string table,string value)
        {
            string sql = $@"SELECT * FROM [{table}] " + value;
            return DbContext.Execute(sql);
                            
        }

        public void Update(TEntity entity, string table, string value)
        {
            string sql = $@"UPDATE {table} " + value;
            DbContext.Execute(sql);
        }
    }
}
