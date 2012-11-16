using FubuPersistence.StructureMap;
using StructureMap;

namespace SystemStateExample
{
    public class WebBootstrapper
    {
         public static IContainer BuildContainer()
         {
             return new Container(x =>
                                  {
                                      x.Scan(scan =>
                                             {
                                                 scan.AssemblyContainingType<WebBootstrapper>();
                                                 scan.WithDefaultConventions();
                                             });
                                      x.FubuPersistenceInMemory();
                                  });
         }
    }
}