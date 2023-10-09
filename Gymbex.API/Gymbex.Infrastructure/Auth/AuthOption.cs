using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Infrastructure.Auth
{
    public sealed class AuthOption
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SigningKey { get; set; } //bezpieczny prywatny klucz który sobie generujemy sami 
        public TimeSpan? Expiry { get; set; } //czas życia tokena
    }
}
