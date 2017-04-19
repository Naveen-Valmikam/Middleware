using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Middleware.Middleware
{
    public class SecurityHeadersBuilder
    {
        private readonly SecurityHeaderPolicy _policy = new SecurityHeaderPolicy();

        public SecurityHeadersBuilder AddFrameOptionsDeny()
        {
            _policy.SetHeaders["X-Frame-Options"] = "Deny";
            return this;
        }

        public SecurityHeadersBuilder AddDefaultHeaders()
        {
            AddFrameOptionsDeny();
            return this;
        }

        public SecurityHeadersBuilder AddCustomHeader(string header, string value)
        {
            _policy.SetHeaders[header] = value;
            return this;
        }

        public SecurityHeadersBuilder RemoveHeader(string header)
        {
            _policy.RemoveHeaders.Add(header);
            return this;
        }

        public SecurityHeaderPolicy Build()
        {
            return _policy;
        }
    }
}
