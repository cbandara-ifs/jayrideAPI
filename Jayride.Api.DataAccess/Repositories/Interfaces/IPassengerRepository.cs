using Jayride.Api.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jayride.Api.DataAccess.Repositories.Interfaces
{
    public interface IPassengerRepository
    {
        public Task<Passenger> getPassenger();
    }
}
