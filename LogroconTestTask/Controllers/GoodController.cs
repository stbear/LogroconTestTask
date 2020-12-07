using System.Collections.Generic;
using System.Linq;
using LogroconTestTask.Data;
using LogroconTestTask.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LogroconTestTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GoodController : ControllerBase
    {
        readonly DataContext dataContext;
        public GoodController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        /// <summary>
        /// Получение списка товаров
        /// </summary>
        [HttpGet]
        public IEnumerable<Good> Get()
            => dataContext.Goods.ToArray();
    }
}
