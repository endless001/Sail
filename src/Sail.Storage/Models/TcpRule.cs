using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.Storage.Models
{
    public class TcpRule
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int Port { get; set; }

    }
}
