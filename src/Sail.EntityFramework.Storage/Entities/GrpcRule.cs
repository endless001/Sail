using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.EntityFramework.Storage.Entities
{
    public class GrpcRule
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int Port { get; set; }
        public string HeaderTransform { get; set; }
    }
}
