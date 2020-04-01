using System;
using System.Collections.Generic;

namespace dbdemo.Models
{
    public partial class NinjaEquipments
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public int? NinjaId { get; set; }

        public virtual Ninjas Ninja { get; set; }
    }
}
