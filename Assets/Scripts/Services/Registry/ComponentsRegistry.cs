using System.Collections.Generic;
using UnityEngine;

namespace Services.Registry
{
    public class ComponentsRegistry
    {
        private readonly Dictionary<int, Component> _registryMap = new Dictionary<int, Component>();

        public void Register(Collider2D collider, Component component)
        {
            var key = collider.GetInstanceID();
            _registryMap.Add(key, component);
        }

        public void Remove(Collider2D collider)
        {
            var key = collider.GetInstanceID();
            _registryMap.Remove(key);
        }

        public bool TryGetComponent<T>(Collider2D collider, out T component) where T : Component
        {
            var key = collider.GetInstanceID();
            if (_registryMap.TryGetValue(key, out var value))
            {
                component = (T)value;
                return component != null;
            }

            component = null;
            return false;
        }
    }
}