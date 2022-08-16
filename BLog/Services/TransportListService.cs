using BLog.IServices;
using DataAccess.Entities;
using Repo.IRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLog.Services
{
    public class TransportListService : BaseService<TransportList>, ITransportListService
    {
        public TransportListService(IRepository<TransportList> repo) : base(repo)
        {
        }

        public override void Add(TransportList entity, string table, string value)
        {         
            value = $@" (TRN_PREFIX, TRN_NO, TRN_OWNER, TRN_TRTYPE, TRN_TRCAT, TRN_TYPE, TRN_FULLEMPTY, TRN_COUNT, TRN_PLATOWNER, TRN_PLATTYPE, 
                                TRN_PLATCOUNT, TRN_STATUS, TRN_ORDID)  
                       VALUES('{entity.TRN_PREFIX}','{entity.TRN_NO}','{entity.TRN_OWNER}','{entity.TRN_TRTYPE}',
                              '{entity.TRN_TRCAT}','{entity.TRN_TYPE}','{entity.TRN_FULLEMPTY}','{entity.TRN_COUNT}','{entity.TRN_PLATOWNER}',
                              '{entity.TRN_PLATTYPE}','{entity.TRN_PLATCOUNT}','{entity.TRN_STATUS}','{entity.TRN_ORDID}')";
            base.Add(entity, table, value);
        }

        public override DataTable Get(string table)
        {
            return base.Get(table);
        }

        public override DataTable Get(int id, string table, string value)
        {
            value = $@" WHERE TRN_ID={id}";
            return base.Get(id, table, value);
        }

        public override void Update(TransportList entity, string table, string value)
        {
            value = $@"SET TRN_PREFIX='{entity.TRN_PREFIX}', TRN_NO={entity.TRN_NO}, TRN_OWNER={entity.TRN_OWNER}, TRN_TRTYPE={entity.TRN_TRTYPE},
                                       TRN_TRCAT={entity.TRN_TRCAT}, TRN_TYPE={entity.TRN_TYPE}, TRN_FULLEMPTY={entity.TRN_FULLEMPTY}, 
                                        TRN_COUNT={entity.TRN_COUNT}, TRN_PLATOWNER={entity.TRN_PLATOWNER}, TRN_PLATTYPE={entity.TRN_PLATTYPE}, 
                                         TRN_PLATCOUNT={entity.TRN_COUNT}, TRN_STATUS={entity.TRN_STATUS}, TRN_ORDID={entity.TRN_ORDID}
                        WHERE TRN_ID={entity.TRN_ID}";
            base.Update(entity, table, value);
        }

        public override void Delete(int id, string table, string value)
        {
            value = $@"WHERE TRN_ID={id}";
            base.Delete(id, table, value);
        }
    }
}
