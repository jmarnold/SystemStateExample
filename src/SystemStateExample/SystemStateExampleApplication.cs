using FubuMVC.Core;
using FubuMVC.StructureMap;
using StructureMap;

namespace SystemStateExample
{
    public class SystemStateExampleApplication : IApplicationSource
    {
        public FubuApplication BuildApplication()
        {
            return FubuApplication
                .For<SystemStateExampleFubuRegistry>()
                .StructureMap(WebBootstrapper.BuildContainer);
        }
    }
}