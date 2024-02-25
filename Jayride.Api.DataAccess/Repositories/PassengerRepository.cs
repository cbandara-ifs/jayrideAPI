using Jayride.Api.DataAccess.Entities;
using Jayride.Api.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jayride.Api.DataAccess.Repositories
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly ApiDbContext _context;

        public PassengerRepository(ApiDbContext context) {
            _context = context;
        }

        public async Task<Passenger> getPassenger()
        {
            Passenger passenger = new Passenger
            {
                Name = "test",
                Phone = "test"
            };

            await Task.Delay(100);

            return passenger;
        }
    }
}
