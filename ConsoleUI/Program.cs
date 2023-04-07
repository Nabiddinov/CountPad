﻿using System;
using CountPad.Application.Interfaces.RepositoryInterfaces;
using CountPad.Application.Services;
using CountPad.Domain.Models.Distributors;
using CountPad.Domain.Models.Products;
using CountPad.Infrastructure.Repositories;
using Tynamix.ObjectFiller;
using CountPad.Domain.Models.Packages;
using System.Threading.Tasks;
using CountPad.Application.Interfaces.ServiceInterfaces;

namespace ConsoleUI
{
    public class Program
    {     
        static async Task Main(string[] args)
        {
            
        }

        public static Filler<T> CreateObjectFiller<T>() where T : class
        {
            var filler = new Filler<T>();

            filler.Setup().OnType<DateTime>()
                .Use(new DateTimeRange(DateTime.UnixEpoch).GetValue);

            return filler;
        }
    }
}
