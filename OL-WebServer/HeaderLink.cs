using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTeszt2
{
    public class HeaderLink
    {
        public HeaderLink(string _name, string _link)
        {
            Name = _name;
            Link = _link;
        }
        public string Name { get; set; }
        public string Link { get; set; }
    }
}
