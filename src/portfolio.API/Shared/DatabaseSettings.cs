using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace portfolio.API.Shared
{
    public class DatabaseSettings
    {
        public required string Host { get; set; }
        public int Port { get; set; }
        public required string Database { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}