using System;
using System.Collections.Generic;

namespace LockstepFramework {
    public static class ActionManager {
        private static Dictionary<Type, object> actionMap = new Dictionary<Type, object>();
        private static Dictionary<Type, ActionListener> actionListenerMap = new Dictionary<Type, ActionListener>();

        public static void AddAction<T>(T action) {
            actionMap.Add(typeof(T), action);
        }

        public static void RegisterActionListener<T>(Action<T> callback) {
            ActionListener listener;
            if (!actionListenerMap.TryGetValue(typeof(T), out listener)) {
                listener = new ActionListener<T>();
                actionListenerMap.Add(typeof(T), listener);
            }
            listener.RegisterActionListener(callback);
        }

        public static void UnregisterActionListener<T>(Action<T> callback) {
            ActionListener listener;
            if (actionListenerMap.TryGetValue(typeof(T), out listener)) {
                listener.UnregisterActionListener(callback);
            }
        }

        public static void NotifyAction() {
            foreach (var entry in actionMap) {
                ActionListener listener;
                if (actionListenerMap.TryGetValue(entry.Key, out listener))
                    listener.NotifyAction(entry.Value);
            }
        }
    }
}