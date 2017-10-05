using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindAccountability.Data.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Accountability SupplierAccountability { get; set; }
        public Guid SupplierAccountabilityId { get; set; }
        public Accountability ShipperAccountability { get; set; }
        public Guid ShipperaccountabilityId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
