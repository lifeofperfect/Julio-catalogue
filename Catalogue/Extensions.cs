﻿using Catalogue.Dtos;
using Catalogue.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogue
{
    public static class Extensions
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedDate = item.CreatedDate
            };
        }
    }
}
