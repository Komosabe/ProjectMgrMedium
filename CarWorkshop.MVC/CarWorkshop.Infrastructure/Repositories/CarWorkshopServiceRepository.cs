﻿using CarWorkshop.Domain.Entities;
using CarWorkshop.Domain.Interfaces.ICarWorkshopServiceRepository;
using CarWorkshop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Repositories
{
    public class CarWorkshopServiceRepository : ICarWorkshopServiceRepository
    {
        private readonly CarWorkshopDbContext _dbContext;

        public CarWorkshopServiceRepository(CarWorkshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(CarWorkshopService service)
        {
            _dbContext.CarWorkshopServices.Add(service);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CarWorkshopService>> GetByWorkshopId(int workshopId)
        {
            return await _dbContext.CarWorkshopServices
                .Where(s => s.CarWorkshopId == workshopId)
                .ToListAsync();
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}






