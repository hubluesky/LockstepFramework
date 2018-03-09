using System;
using System.Collections.Generic;
using UnityEngine;

namespace LockstepFramework {
    public class Entity {
        protected Dictionary<Guid, Component> componentMap = new Dictionary<Guid, Component>();
        protected Dictionary<Type, List<Component>> componentTypeMap = new Dictionary<Type, List<Component>>();

        ~Entity() {
            RemoveAllCompents();
        }

        public T GetComponent<T>() where T : Component {
            List<Component> list;
            if (componentTypeMap.TryGetValue(typeof(T), out list) && list.Count > 0)
                return list[0] as T;
            return default(T);
        }

        public IEnumerator<Component> GetComponents<T>() where T : Component {
            List<Component> list;
            if (componentTypeMap.TryGetValue(typeof(T), out list))
                return list.GetEnumerator();
            return null; // return empty iterator
        }

        public bool AddComponent(Component component) {
            if (componentMap.ContainsKey(component.uniqueId)) {
                Debug.LogWarningFormat("Add Component failed! Has same key {1} {2}", component.GetType(), component.uniqueId);
                return false;
            }

            componentMap.Add(component.uniqueId, component);
            component.entity = this;
            component.Initialized();

            List<Component> list;
            if (!componentTypeMap.TryGetValue(component.GetType(), out list)) {
                list = new List<Component>();
                list.Add(component);
                componentTypeMap.Add(component.GetType(), list);
            }
            return true;
        }

        public T AddOrCreateComponent<T>() where T : Component, new() {
            T component = GetComponent<T>();
            if (component == null) {
                component = new T();
                AddComponent(component);
            }
            return component;
        }

        public T CreateComponent<T>() where T : Component, new() {
            T component = new T();
            if (!AddComponent(component))
                return null;
            return component;
        }

        public bool RemoveCompnent(Component component) {
            if (!componentMap.Remove(component.uniqueId))
                return false;

            List<Component> list;
            if (componentTypeMap.TryGetValue(component.GetType(), out list))
                list.Remove(component);

            component.Finalized();
            component.entity = null;
            return true;
        }

        public bool RemoveCompnents<T>() {
            List<Component> list;
            if (componentTypeMap.TryGetValue(typeof(T), out list)) {
                RemoveCompnents(list);
                return true;
            }
            return false;
        }

        public void RemoveAllCompents() {
            foreach (var entry in componentTypeMap)
                RemoveCompnents(entry.Value);
            componentTypeMap.Clear();
        }

        protected void RemoveCompnents(List<Component> list) {
            foreach (Component component in list) {
                componentMap.Remove(component.uniqueId);
                component.Finalized();
                component.entity = null;
            }
            list.Clear();
        }
    }
}