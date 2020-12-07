using System.Collections.Generic;
using System.Linq;
using LogroconTestTask.Data;
using LogroconTestTask.Data.Entities;
using LogroconTestTask.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogroconTestTask.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        readonly DataContext dataContext;
        public OrderController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpPut]
        public IActionResult Put(NewOrderModel model)
        {
            if (!dataContext.Clients.Any(x => x.Number == model.ClientNumber))
                return BadRequest("Invalid client id");
            var order = new Order { ClientNumber = model.ClientNumber, Description = model.Description };
            dataContext.Add(order);
            dataContext.SaveChanges();
            return Ok(order.Number);
        }
        [HttpGet("{id}")]
        public IEnumerable<OrderPositionViewModel> Get(int id)
            => dataContext.OrderPositions.Include(x => x.Good).Where(x => x.OrderNumber == id).Select(x => new OrderPositionViewModel(x));

        [HttpPost]
        public IActionResult Post(OrderPositionEditModel model)
        {
            if (model.Quantity > 9999)
                return BadRequest("Too large quantity");
            var found = dataContext.OrderPositions.FirstOrDefault(x => x.OrderNumber == model.OrderNumber && x.GoodNumber == model.GoodNumber);
            if (found != null)
            {
                if (model.Quantity > 0)
                {
                    found.Quantity = model.Quantity;
                    found.Price = dataContext.Goods.First(x => x.Number == model.GoodNumber).Price;
                }
                else
                {
                    dataContext.OrderPositions.Remove(found);
                }
            }
            else if (model.Quantity > 0)
            {
                var good = dataContext.Goods.FirstOrDefault(x => x.Number == model.GoodNumber);
                if (good == null)
                    return BadRequest("Invalid good id");
                dataContext.OrderPositions.Add(new OrderPosition
                {
                    GoodNumber = model.GoodNumber,
                    OrderNumber = model.OrderNumber,
                    Quantity = model.Quantity,
                    Price = good.Price
                });
            }
            var order = dataContext.Orders.Include(x => x.Client).Include(x => x.Positions).FirstOrDefault(x => x.Number == model.OrderNumber);
            if (order != null)
            {
                var sum = order.Positions.Sum(x => x.Price * x.Quantity);
                if (order.Client.VIP)
                {
                    var discount = dataContext.Orders.Count(x => x.ClientNumber == order.ClientNumber && x.Number < order.Number);
                    if (discount > 50)
                        discount = 50;
                    sum = sum * (100 - discount) / 100m;
                }
                order.TotalPrice = sum;
                dataContext.SaveChanges();
            }
            return Ok();
        }
    }
}
