using System;

namespace LockstepFramework {
    public class MultiComponent : Component {
        private Guid _uniqueId = Guid.NewGuid();
        public override Guid uniqueId { get { return _uniqueId; } }
    }
}