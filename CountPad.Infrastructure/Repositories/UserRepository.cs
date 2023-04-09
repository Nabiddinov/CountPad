﻿// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using CountPad.Application.Interfaces.RepositoryInterfaces;
using CountPad.Domain.Models.Users;
using Dapper;
using Npgsql;

namespace CountPad.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public async Task<int> AddAsync(User user)
        {
            using (NpgsqlConnection connection = CreateConnection())
            {
                string sql = @"INSERT INTO users (id, name, phone, user_status, password) 
                                            VALUES (@Id, @Name, @Phone, @Status,@Password)";

                int affectedRows = await connection.ExecuteAsync(sql,
                   new Dictionary<string, object>
                   {
                       { "Id", user.Id },
                       { "Name", user.Name },
                       { "Phone", user.Phone },
                       {"Password",user.Password},
                       { "Status", user.Status.ToString()}
                   });

                return affectedRows;
            }
        }
    }
}