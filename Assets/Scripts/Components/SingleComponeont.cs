using System;

namespace LockstepFramework {
    public class SingleComponeont : Component {
        public static readonly Guid instanceUniqueId = Guid.NewGuid();
        public override Guid uniqueId { get { return instanceUniqueId; } }
    }
}