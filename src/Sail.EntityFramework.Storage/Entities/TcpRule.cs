using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.EntityFramework.Storage.Entities
{
    public class TcpRule
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int Port { get; set; }
    }
}
