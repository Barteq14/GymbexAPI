using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Dtos;

namespace Gymbex.Application.Security
{
    public interface ITokenStorage
    {
        void Set(JwtDto accessToken);
        JwtDto GetJwt();
    }
}
