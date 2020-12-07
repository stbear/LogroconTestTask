using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LogroconTestTask.Data.Entities
{
    public class Client
    {
        [Key]
        public int Number { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool VIP { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
