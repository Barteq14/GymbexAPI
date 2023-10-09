using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Dtos;
using Gymbex.Core.ValueObjects;

namespace Gymbex.Application.Security
{
    public interface IAuthenticator
    {
        JwtDto CreateToken(Guid customerId, Role role);
    }
}
