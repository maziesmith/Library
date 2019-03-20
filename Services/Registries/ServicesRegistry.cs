using DAL.Repositories;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Registries
{
   public class ServicesRegistry:Registry
    {
        public ServicesRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });
            For(typeof(IRepository<>)).Use(typeof(Repository<>));
        }
    }
}
