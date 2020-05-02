﻿using ODA.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ODA.Server.Services
{
    public interface IRestaurantService
    {
        void Add(Restaurant restaurant);
        Task AddAsync(Restaurant restaurant);
        IEnumerable<Restaurant> GetAll();
        Task<IEnumerable<Restaurant>> GetAllAsync();
        Restaurant Get(int Id);
        Task<Restaurant> GetAsync(int Id);
        void Update(Restaurant restaurant);
        Task UpdateAsync(Restaurant restaurant);
        void Remove(int Id);
        Task RemoveAsync(int Id);
        void Remove(Restaurant restaurant);
        Task RemoveAsync(Restaurant restaurant);
    }
}