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
    public class OrderListService: BaseService<OrderList>, IOrderListService
    {
        public OrderListService(IRepository<OrderList> repo): base(repo)
        {

        }

        public override void Add(OrderList entity, string table, string value)
        {
            value = $@"(TRN_ORDERNOTE,TRN_ORDERSTATUS,USERID) 
                        VALUES('{entity.TRN_ORDERNOTE}',{entity.TRN_ORDERSTATUS},{entity.USERID})";
            base.Add(entity, table, value);
        }

        public override void Delete(int id, string table, string value)
        {
            value = $@"WHERE TRN_ORDERID={id}";
            base.Delete(id, table, value);
        }

        public override DataTable Get(string table)
        {
            return base.Get(table);
        }

        public override DataTable Get(int id, string table, string value)
        {
            value = $@"WHERE TRN_ORDERID={id}";
            return base.Get(id, table, value);
        }

        public DataTable GetJoin(string sql)
        {
            sql = $@"SELECT TRN_ORDERID,TRN_ORDERNOTE,TRN_ORDERSTATUS,U.NAME,U.SURNAME,U.PASSWORD,U.STATUS FROM TBL_ORDERLIST AS P
                        INNER JOIN TBL_USERLIST AS U
                        ON(P.USERID=U.USERID)";
            return repo.GetJoin(sql);
        }

        public override void Update(OrderList entity, string table, string value)
        {
            value = $@"SET TRN_ORDERNOTE='{entity.TRN_ORDERNOTE}',TRN_ORDERSTATUS='{entity.TRN_ORDERSTATUS}',USERID={entity.USERID}
                       WHERE TRN_ORDERID={entity.TRN_ORDERID}";
            base.Update(entity, table, value);
        }
    }
}
