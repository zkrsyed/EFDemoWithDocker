using System;
using System.Collections.Generic;

namespace dbdemo.Models
{
    public partial class Ninjas
    {
        public Ninjas()
        {
            NinjaEquipments = new HashSet<NinjaEquipments>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? ServedInOniwaban { get; set; }
        public int? ClanId { get; set; }

        public virtual Clans Clan { get; set; }
        public virtual ICollection<NinjaEquipments> NinjaEquipments { get; set; }
    }
}
