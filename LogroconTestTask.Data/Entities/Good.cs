using System.ComponentModel.DataAnnotations;

namespace LogroconTestTask.Data.Entities
{
    public class Good
    {
        [Key]
        public int Number { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
