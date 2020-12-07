using System.ComponentModel.DataAnnotations.Schema;

namespace LogroconTestTask.Data.Entities
{
    public class OrderPosition
    {
        public int OrderNumber { get; set; }
        public int GoodNumber { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("OrderNumber")]
        public virtual Order Order { get; set; }
        [ForeignKey("GoodNumber")]
        public virtual Good Good { get; set; }
    }
}
