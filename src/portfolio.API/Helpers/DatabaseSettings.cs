using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace portfolio.API.Helpers
{
    public class DatabaseSettings
    {
        public required string Host { get; set; }
        public int PortNumber { get; set; }
        public required string Database { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}