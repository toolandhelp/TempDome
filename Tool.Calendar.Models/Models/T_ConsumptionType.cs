using System;
using System.Collections.Generic;
using System.Text;

namespace Tool.Calendar.Models.Models
{
    public class T_ConsumptionType
    {
        public int ID { get; set; }
        public Guid ConsumptionTypeGuid { get; set; }
        public string ConsumptionTypeName { get; set; }
        public DateTime ConsumptionTypeCreateDate { get; set; }
        public string ConsumptionTypeClass { get; set; }
    }
}
