using AmKart.Common.Types;
using AmKart.Services.Products.Dto;
using System;

namespace AmKart.Services.Products.Queries
{
    public class GetProduct : IQuery<ProductDto>
    {
        public Guid Id { get; set; }
    }
}
