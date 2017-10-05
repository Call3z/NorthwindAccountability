using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindAccountability.Data.Models
{
    public class Party
    {
        public Guid Id { get; set; }
        public PartyInformation PartyInformation { get; set; }
        public Guid PartyInformationId { get; set; }
        public List<Accountability> CommisionerAccountabilities { get; set; }
        public List<Accountability> ResponsibleAccountabilities { get; set; }
    }
}
