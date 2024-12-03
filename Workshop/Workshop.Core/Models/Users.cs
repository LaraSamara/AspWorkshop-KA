using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Core.Models
{
    public class Users: IdentityUser<int>
    {
        [ForeignKey(nameof(Goverments))]
        public int Goverments_Id { get; set; }
        [ForeignKey(nameof(Cities))]
        public int Cities_Id { get; set; }
        [ForeignKey(nameof(Zones))]
        public int Zones_Id { get; set; }
        public Goverments Goverments { get; set; }
        public Cities Cities { get; set; }
        public Zones Zones { get; set; }
    }
}
