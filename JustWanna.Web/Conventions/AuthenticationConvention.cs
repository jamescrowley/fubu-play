using System.Collections.Generic;
using System.Linq;
using FubuMVC.Core.Registration;
using JustWanna.Web.Behaviours;

namespace JustWanna.Web.Conventions
{
    public class AuthenticationConvention : IConfigurationAction
    {
        public void Configure(BehaviorGraph graph)
        {
             graph.Actions()
                .Where(c => !c.HandlerType.Namespace.Contains("Home") 
                                && !c.HandlerType.Namespace.Contains("Login")
                                && !c.HandlerType.Namespace.Contains("Signup"))
                .Each(c => c.WrapWith<AuthenticationBehaviour>());
        }
    }
}