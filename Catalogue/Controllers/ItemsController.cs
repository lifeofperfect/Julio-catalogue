using Catalogue.Dtos;
using Catalogue.Entities;
using Catalogue.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogue.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ITemsRepository _repository;
        public ItemsController(ITemsRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        ///  GET /api/items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = _repository.GetItems().Select(item => item.AsDto());
            return items;
        }

        /// <summary>
        /// GET /items/id from query
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = _repository.GetItem(id);

            if (item is null) return NotFound();

            return item.AsDto();
        }
    }
}
