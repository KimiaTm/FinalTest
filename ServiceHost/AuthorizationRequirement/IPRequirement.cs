using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace ServiceHost.AuthorizationRequirement
{
    public class IPRequirement: IAuthorizationRequirement
    {
        public List<string> Whitelist { get; }
        public IPRequirement(ApplicationOptions applicationOptions)
        {
            Whitelist = applicationOptions.WhiteList;
        }
    }
}
