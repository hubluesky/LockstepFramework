namespace LockstepFramework {
	public abstract class Component {
		public abstract System.Guid uniqueId { get; }
		public Entity entity { get; internal set; }
		public virtual void Initialized() { }
		public virtual void Finalized() { }
	}
}