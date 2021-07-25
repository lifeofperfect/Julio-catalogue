﻿using Catalogue.Dtos;
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

        /// <summary>
        /// POST /items
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto request)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Price = request.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            _repository.CreateItem(item);

            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
        }

        /// <summary>
        /// Put api/items/{id}
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult UpdateItem(UpdateItemDto request)
        {
            var existingItem = _repository.GetItem(request.Id);

            if (existingItem is null) return NotFound();

            Item updatedItem = existingItem with
            {
                Name = request.Name,
                Price = request.Price
            };

            _repository.UpdateItem(updatedItem);

            return NoContent();
        }

        /// <summary>
        /// DELETE api/items/{id]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult DeleteItem(Guid id)
        {
            var existingItem = _repository.GetItem(id);

            if (existingItem is null) return NotFound();

            _repository.DeleteItem(id);

            return NoContent();
        }
    }
}
