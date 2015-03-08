using Business.SubBusinessAccess;
using StructureMap;
using StructureMap.Graph;

namespace WebSite {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
                            x.For<ISponsor>().Use<Sponsor>();
                            
                        });
            return ObjectFactory.Container;
        }
    }
}