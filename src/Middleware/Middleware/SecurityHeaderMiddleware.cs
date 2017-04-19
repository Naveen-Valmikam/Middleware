using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Middleware.Middleware
{
    public class SecurityHeaderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly SecurityHeaderPolicy _policy;

        public SecurityHeaderMiddleware(RequestDelegate next, SecurityHeaderPolicy policy)
        {
            _next = next;
            _policy = policy;
        }

        public async Task Invoke(HttpContext context)
        {
            IHeaderDictionary headers = context.Response.Headers; // Read all the existing headers from the context

            foreach (var header in _policy.SetHeaders)
            {
                headers[header.Key] = header.Value; // Append to the existing list of headers
            }

            foreach (var header in _policy.RemoveHeaders)
            {
                headers.Remove(header); // Remvoe the headers mentioned in the list
            }

            await _next(context);
        }
    }
}
