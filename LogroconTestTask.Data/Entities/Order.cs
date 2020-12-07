using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogroconTestTask.Data.Entities
{
    public class Order
    {
        [Key]
        public int Number { get; set; }
        public decimal TotalPrice { get; set; }
        public string Description { get; set; }
        public int ClientNumber { get; set; }
        [ForeignKey("ClientNumber")]
        public virtual Client Client { get; set; }
        public virtual ICollection<OrderPosition> Positions { get; set; }
    }
}
