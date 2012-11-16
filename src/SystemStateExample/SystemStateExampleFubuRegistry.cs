using SystemStateExample.Account;
using SystemStateExample.Lists;
using FubuMVC.Core;
using FubuMVC.Core.UI;

namespace SystemStateExample
{
    public class SystemStateExampleFubuRegistry : FubuRegistry
    {
        public SystemStateExampleFubuRegistry()
        {
            Actions.IncludeClassesSuffixedWithEndpoint();

            Import<HtmlConventionRegistry>(x => x.Editors.Add(new ListValueElementPolicy()));

            Routes
                .RootAtAssemblyNamespace()
                .HomeIs<RegistrationEndpoint>(x => x.get_register(null));
        }
    }
}