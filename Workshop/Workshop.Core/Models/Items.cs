using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Core.Models
{
    public class Items
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        [ForeignKey(nameof(MainGroups))]
        public int MainGroups_Id { get; set; }
        [ForeignKey(nameof(SubGroupsA))]
        public int SubGroupsA_Id { get; set; }
        [ForeignKey(nameof(SubGroupsB))]
        public int SubGroupsB_Id { get; set; }  
        public MainGroups MainGroups { get; set; }
        public SubGroupsA SubGroupsA { get; set; }
        public SubGroupsB SubGroupsB { get; set; }
    }
}
