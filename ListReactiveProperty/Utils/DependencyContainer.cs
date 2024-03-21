using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListReactiveProperty.Utils
{
    public class DependencyContainer
    {
        private readonly Dictionary<Type, object> instances = new Dictionary<Type, object>();

        public void RegisterInstance<T>(T instance)
        {
            instances[typeof(T)] = instance;
        }

        public T GetInstance<T>()
        {
            if (instances.TryGetValue(typeof(T), out var instance))
            {
                return (T)instance;
            }
            throw new InvalidOperationException($"No instance registered for type {typeof(T)}");
        }
    }
}
