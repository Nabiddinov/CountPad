﻿// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System.Threading.Tasks;
using CountPad.Domain.Models.Orders;

namespace CountPad.Application.Interfaces.ServiceInterfaces
{
    public interface IOrderService
    {
        Task<int> AddOrderAsync(Order order);
    }
}
