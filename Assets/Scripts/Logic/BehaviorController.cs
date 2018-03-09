namespace LockstepFramework {
    public class BehaviorController : SingleComponeont {
        public override void Initialized() {
            ActionManager.RegisterActionListener<MovementAction>(OnMovementAction);
        }

        public override void Finalized() {

        }

        private void OnMovementAction(MovementAction action) {

        }
    }
}