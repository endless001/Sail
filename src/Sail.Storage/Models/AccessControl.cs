using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.Storage.Models
{
    public class AccessControl
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int OpenAuth { get; set; }
        public string BlackList { get; set; }
        public string WhiteList { get; set; }
        public string WhiteHostName { get; set; }
        public int ClientipFlowLimit { get; set; }
        public int ServiceFlowLimit { get; set; }

    }
}
