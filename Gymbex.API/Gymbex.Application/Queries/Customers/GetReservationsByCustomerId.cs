﻿using Gymbex.Application.Abstractions;
using Gymbex.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Application.Queries.Customers
{
    public class GetReservationsByCustomerId : IQuery<List<ReservationDto>>
    {
        public Guid CustomerId { get; set; }
    }
}
