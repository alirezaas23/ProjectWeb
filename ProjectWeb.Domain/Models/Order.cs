using System.Collections.Generic;
using ProjectWeb.Domain.Models.Account;
using ProjectWeb.Domain.Models.Common;

namespace ProjectWeb.Domain.Models
{
    public class Order : BaseEntity
    {
        #region Properties

        public long UserId { get; set; }
        public string OrderDateTime { get; set; }
        public int Sum { get; set; }
        public int ShouldPaySum { get; set; }
        public int LeftSum { get; set; }
        public bool IsFinally { get; set; }
        public bool FinalyPay { get; set; }

        #endregion

        #region Relations

        public ICollection<OrderDetail> OrderDetails { get; set; }

        public User User { get; set; }

        #endregion
    }
}
