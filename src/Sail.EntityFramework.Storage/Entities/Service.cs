using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.EntityFramework.Storage.Entities
{
   public class Service
    {
        public int Id { get; set; }
        public int LoadType { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDesc { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public int IsDelete { get; set; }
    }
}
