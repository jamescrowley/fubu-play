using Cassette.Configuration;
using Cassette.Scripts;
using Cassette.Stylesheets;

namespace JustWanna.Web.Infrastructure
{
    /// <summary>
    /// Configures the Cassette asset modules for the web application.
    /// </summary>
    public class ConfigureCassette : ICassetteConfiguration
    {
        public void Configure(BundleCollection bundles, CassetteSettings settings)
        {
            bundles.AddPerSubDirectory<StylesheetBundle>("~/content/styles");//
            bundles.AddPerSubDirectory<ScriptBundle>("~/scripts");
        }
    }
}