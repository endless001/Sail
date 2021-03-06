﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sail.EntityFramework.Storage.Entities
{
   public class HttpRule
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int RuleType { get; set; }
        public string Rule { get; set; }
        public int NeedHttps { get; set; }
        public int NeedWebsocket { get; set; }
        public int NeedStripUri { get; set; }
        public string UrlRewrite { get; set; }
        public string HeaderTransform { get; set; }

    }
}
