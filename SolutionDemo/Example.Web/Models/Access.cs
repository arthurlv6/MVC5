using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Web.Models
{
    public sealed class Access
    {
        private static readonly Access instance = new Access();
        private Access()
        {
            Gateway = new Server();
        }
        public static Access Instance
        {
            get
            {
                return instance;
            }
        }
        public Server Gateway { get; private set; }
    }
}
