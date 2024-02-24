using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsWebClientMudBlazor.Authentication
{
    public sealed class AutorizeToken
    {
        public int? Id { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? Username { get; init; }
        public string? Token { get; set; }
    }
}
