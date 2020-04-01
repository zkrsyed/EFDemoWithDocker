using System;
using System.Collections.Generic;

namespace dbdemo.Models
{
    public partial class Clans
    {
        public Clans()
        {
            Ninjas = new HashSet<Ninjas>();
        }

        public int Id { get; set; }
        public string ClanName { get; set; }

        public virtual ICollection<Ninjas> Ninjas { get; set; }
    }
}
