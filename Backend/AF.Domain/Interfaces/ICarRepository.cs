﻿using AF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Domain.Interfaces
{
    public interface ICarRepository : IRepository<Car>
    {
        Task AddCarToLessorAsync(int lessorId, Car entity);
    }
}
