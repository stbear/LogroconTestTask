using System.Collections.Generic;
using System.Linq;
using LogroconTestTask.Data;
using LogroconTestTask.Model;
using Microsoft.AspNetCore.Mvc;

namespace LogroconTestTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        readonly DataContext dataContext;
        public ClientController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet("{id}")]
        public IEnumerable<OrderViewModel> Get(int id)
            => dataContext.Orders.Where(x => x.ClientNumber == id).Select(x => new OrderViewModel(x));
    }
}
