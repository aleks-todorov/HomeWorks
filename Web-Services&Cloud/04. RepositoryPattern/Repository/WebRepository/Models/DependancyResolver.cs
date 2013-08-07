using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRepository.Controllers;

namespace WebRepository.Models
{
    public class DependancyResolver : IDependencyResolver
    {

        public IDependencyResolver BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(ValuesController))
            {
                var repo = new InMemmoryRepository();
                return new ValuesController(repo);
            }
            else
            {
                return null;

            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
        }
    }
}