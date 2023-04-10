﻿// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountPad.Application.Interfaces.RepositoryInterfaces;
using CountPad.Domain.Models.Products;
using Dapper;
using Npgsql;

namespace CountPad.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {

        public async Task<int> AddAsync(Product product)
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                string sql = @"INSERT INTO Products (Id, Name, Description, Product_Type) 
                                            VALUES (@Id, @Name, @Description, @ProductType)";

                int affectedRows = connection.Execute(sql,
                    new Dictionary<string, object>
                    {
                        { "Id", product.Id },
                        { "Name", product.Name },
                        { "Description", product.Description },
                        { "ProductType", product.ProductType.ToString() }
                    });

                return affectedRows;
            }
        }

        public async Task<int> AddRangeAsync(IEnumerable<Product> entities)
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                string sql = @"INSERT INTO Products (Id, Name, Description, Product_Type) 
                                            VALUES (@Id, @Name, @Description, @ProductType)";
                int affectedRows = connection.Execute(sql, entities);

                return affectedRows;
            }
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                string sql = @"select * from products where id = @Id";

                return await connection
                    .QuerySingleOrDefaultAsync<Product>(sql, new { Id = id });
            }
        }

        public async Task<List<Product>> GetAllAsync()
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                string sql = @"Select * from Products";

                List<Product> allProducts = connection.Query<Product>(sql).ToList();

                return allProducts;
            }
        }

        public async Task<int> UpdateAsync(Product product)
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                string sql = @"Update Products
                                SET name = @Name,
                                product_type = @ProductType,
                                description = @Description
                                WHERE id = @Id";

                int affectedRows = await connection.ExecuteAsync(sql,
                    new
                    {
                        Id = product.Id,
                        Name = product.Name,
                        ProductType = product.ProductType.ToString(),
                        Description = product.Description
                    });

                return affectedRows;
            }
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                string sql = @"Delete from Products WHERE ID=@id";

                int affectedRows = await connection.ExecuteAsync(sql, new { Id = id });

                return affectedRows;
            }
        }
    }
}
