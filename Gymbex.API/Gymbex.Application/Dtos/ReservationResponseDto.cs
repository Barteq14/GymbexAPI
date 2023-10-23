using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Application.Dtos
{
    public sealed class ReservationResponseDto
    {
        public bool IsSuccess { get; set; }
        public string Error { get; set; }
        public string Message { get; set; }
    }
}
