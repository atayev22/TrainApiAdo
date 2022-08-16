using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLog.IServices
{
    public interface IBaseService<TEntity>
    {
        public DataTable Get(string table);
        public DataTable Get(int id, string table, string value);
        public void Add(TEntity entity, string table, string value);
        public void Update(TEntity entity, string table, string value);
        public void Delete(int id, string table, string value);
    }
}
