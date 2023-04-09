﻿// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CountPad.Domain.Models.Products;

namespace CountPad.Application.Interfaces.ServiceInterfaces
{
    public interface IProductService
    {
        Task<int> AddProductAsync(Product product);
        Task<int> AddRangeAsync(IEnumerable<Product> products);
        Task<Product> GetByIdAsync(Guid id);
        Task<List<Product>> GetAllProducts();
        Task<int> UpdateAsync(Product product);
        Task<int> DeleteProductAsync(Guid id);
    }
}

