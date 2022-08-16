using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.IRepositories
{
    public interface IRepository
    {
        
    }

    public interface IRepository<TEntity>: IRepository
    {
        public DataTable Get(string table);
        public DataTable GetJoin(string sql);
        public DataTable Get(int id,string table,string value);
        public void Add(TEntity entity, string table, string value);
        public void Update(TEntity entity, string table, string value);
        public void Delete(int id, string table, string value);
    }

}
