using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Middleware.Middleware
{
    public class SecurityHeaderPolicy
    {
        public IDictionary<string, string> SetHeaders { get; } = new Dictionary<string, string>();

        public ISet<string> RemoveHeaders { get; } = new HashSet<string>();
    }
}
