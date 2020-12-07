using LogroconTestTask.Data.Entities;

namespace LogroconTestTask.Model
{
    public class OrderPositionViewModel
    {
        public string GoodName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public OrderPositionViewModel(OrderPosition source)
        {
            GoodName = source.Good.Name;
            Quantity = source.Quantity;
            Price = source.Price;
        }
    }
}
