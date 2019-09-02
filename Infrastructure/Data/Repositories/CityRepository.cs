using System.Collections.Generic;
using Domain.DTOs;
using Domain.Interfaces.Data;
using Infrastructure.Data.Context;
using Infrastructure.Data.Entities;

namespace Infrastructure.Data.Repositories
{
    internal class CityRepository : BaseRepository<CityDTO, CityEntity>, ICityRepository
    {
        public CityRepository(WeatherContext dbContext) : base(dbContext)
        {
        }
    }
}