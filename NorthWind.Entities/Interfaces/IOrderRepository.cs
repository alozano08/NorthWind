﻿using NorthWind.Entities.POCOEntities;
using NorthWind.Entities.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entities.Interfaces
{
    public interface IOrderRepository
    {
        void Crate(Order order);
        IEnumerable<Order> GetOrderByEspecification(Specification<Order> specification);
    }
}