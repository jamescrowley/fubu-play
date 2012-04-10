using FubuMVC.Core;
using FubuMVC.Core.Behaviors;
using FubuMVC.Core.Runtime;
using FubuMVC.Core.Security;
using FubuMVC.Core.Urls;
using JustWanna.Web.Actions.Account;

namespace JustWanna.Web.Behaviours
{
    public class AuthenticationBehaviour : BasicBehavior
    {
        private readonly ISecurityContext _securityContext;
        private readonly IUrlRegistry _urlRegistry;
        private readonly IOutputWriter _outputWriter;

        public AuthenticationBehaviour(ISecurityContext securityContext, IUrlRegistry urlRegistry, IOutputWriter outputWriter)
            : base(PartialBehavior.Ignored)
        {
            _securityContext = securityContext;
            _urlRegistry = urlRegistry;
            _outputWriter = outputWriter;
        }

        protected override DoNext performInvoke()
        {
            if (_securityContext.IsAuthenticated())
            {
                return DoNext.Continue;
            }

            var url = _urlRegistry.UrlFor(new LoginRequest());
            _outputWriter.RedirectToUrl(url);
            return DoNext.Stop;
        }
    }
}