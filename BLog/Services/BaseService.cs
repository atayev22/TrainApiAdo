using BLog.IServices;
using Repo.IRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLog.Services
{
    public class BaseService<TEntiry> : IBaseService<TEntiry>
    {
        public IRepository<TEntiry> repo;

        public BaseService(IRepository<TEntiry> repo)
        {
            this.repo = repo;
        }

        public virtual void Add(TEntiry entity, string table, string value)
        {
            repo.Add(entity, table, value);
        }

        public virtual void Delete(int id, string table, string value)
        {
            repo.Delete(id, table, value);
        }

        public virtual DataTable Get(string table)
        {
            return repo.Get(table);
        }

        public virtual DataTable Get(int id, string table, string value)
        {
            return repo.Get(id, table, value);
        }

        public virtual void Update(TEntiry entity, string table, string value)
        {
             repo.Update(entity, table, value);
        }
    }
}
