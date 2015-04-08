using Business.Repositories;
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
                            x.For<IHomeRepository>().Use<HomeRepository>();
                            x.For<IOrderRepository>().Use<OrderRepository>();
                        });
            return ObjectFactory.Container;
        }
    }
}