﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Abstractions;
using Gymbex.Application.Dtos;

namespace Gymbex.Application.Queries
{
    public sealed class GetActivities : IQuery<IEnumerable<ActivityDto>>
    {
    }
}
