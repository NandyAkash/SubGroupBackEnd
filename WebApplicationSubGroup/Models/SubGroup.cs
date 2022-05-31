using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationSubGroup.Models
{
    public class SubGroup
    {
        
        public string SubGroupID { get; set; }
        public string SubGroupName { get; set; }
        public string GroupId { get; set; }
        public string MakeBy { get; set; }
        public string MakeDate { get; set; }
        public string InsertTime { get; set; }
        public string UpdateBy { get; set; }
        public string UpdateDate { get; set; }
        public string UpdateTime { get; set; }
    }
}
