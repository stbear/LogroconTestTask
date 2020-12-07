using LogroconTestTask.Data.Entities;

namespace LogroconTestTask.Model
{
    public class OrderViewModel
    {
        public int Number { get; set; }
        public string Description { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderViewModel(Order source)
        {
            Number = source.Number;
            Description = source.Description;
            TotalPrice = source.TotalPrice;
        }
    }
}
