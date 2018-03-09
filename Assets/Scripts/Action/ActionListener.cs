using System;
using System.Collections.Generic;

namespace LockstepFramework {
    internal abstract class ActionListener {
        public abstract void RegisterActionListener(object action);
        public abstract void UnregisterActionListener(object action);
        public abstract void NotifyAction(object value);
    }

    internal class ActionListener<T> : ActionListener {
        private List<Action<T>> actionList = new List<Action<T>>();

        public override void RegisterActionListener(object callback) {
            actionList.Add(callback as Action<T>);
        }

        public override void UnregisterActionListener(object callback) {
            actionList.Remove(callback as Action<T>);
        }

        public override void NotifyAction(object value) {
            NotifyAction((T) value);
        }

        private void NotifyAction(T value) {
            foreach (Action<T> listener in actionList)
                listener(value);
        }
    }
}