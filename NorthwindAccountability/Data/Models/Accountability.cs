using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindAccountability.Data.Models
{
    public class Accountability
    {
        public Guid Id { get; set; }
        public Party Commissioner { get; set; }
        public Guid CommissionerId { get; set; }
        public Party Responsible { get; set; }
        public Guid ResponsibleId { get; set; }
        public AccountabilityType AccountabilityType { get; set; }
        public Guid AccountabilityTypeId { get; set; }
    }
}
