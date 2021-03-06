using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Common.JwtHelpers
{
    public class JwtConfigure
    {
        public const string AppKey = "JwtConfigure";

        public string Key { get; set; }

        public string IssUser { get; set; }

        public string Audience { get; set; }

        public int Expires { get; set; }

    }
}
