using FubuMVC.Core;
using FubuMVC.Razor;
using JustWanna.Web.Actions.Home;
using JustWanna.Web.Actions.Profile;

namespace JustWanna.Web.Infrastructure
{
    public class FubuMvcRegistry : FubuRegistry
    {
        public FubuMvcRegistry()
        {
            // This line turns on the basic diagnostics and request tracing
            IncludeDiagnostics(true);

            // All public methods from concrete classes ending in "Controller"
            // in this assembly are assumed to be action methods
            Actions.IncludeTypesNamed(x => x.EndsWith("Action"));

            Routes
                .IgnoreNamespaceText("JustWanna.Web.Actions")
                .IgnoreControllerNamesEntirely()
                .IgnoreClassSuffix("Action")
                .IgnoreMethodsNamed("Execute")
                .IgnoreMethodSuffix("Post")
                .IgnoreMethodSuffix("Get")
                .IgnoreMethodSuffix("Delete")
                .IgnoreMethodSuffix("Put")
                .ConstrainToHttpMethod(action => action.Method.Name.Equals("Post"), "POST")
                .ConstrainToHttpMethod(action => action.Method.Name.Equals("Put"), "PUT")
                .ConstrainToHttpMethod(action => action.Method.Name.Equals("Get"), "GET")
                .ConstrainToHttpMethod(action => action.Method.Name.Equals("Delete"), "DELETE")
                .ForInputTypesOf<IRequestBySlug>(x => x.RouteInputFor(request => request.Slug));
            
            Routes.HomeIs<HomeAction>(x => x.Get(null));

            Import<RazorEngineRegistry>();
            // Match views to action methods by matching
            // on model type, view name, and namespace
            Views.TryToAttachWithDefaultConventions()
                .RegisterActionLessViews(token => typeof (IPartialModel).IsAssignableFrom(token.ViewModelType), chain => chain.IsPartialOnly = true);
            //.RegisterActionLessViews(t => t.Name.StartsWith("_"));

            //ApplyConvention<AuthenticationConvention>();
        }
    }
    public interface IPartialModel
    {
    }
}