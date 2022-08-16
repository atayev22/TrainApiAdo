using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLog.IServices
{
    public interface IOrderListService: IBaseService<OrderList>
    {
        public DataTable GetJoin(string? sql = null);
    }
}
