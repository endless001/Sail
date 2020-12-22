using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.Storage.Models
{
    public class Tenant
    {
        public int Id { get; set; }
        public int AppId { get; set; }
        public string Name { get; set; }
        public string Secret { get; set; }
        public string WhiteIps { get; set; }
        public int Qpd { get; set; }
        public int Qps { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public int IsDelete { get; set; }
    }
}
