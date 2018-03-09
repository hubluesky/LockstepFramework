using UnityEngine;

namespace LockstepFramework {
    public sealed class FrameManager : Singleton<FrameManager> {
        public event System.Action frameUpdate;
        public event System.Action lateFrameUpdate;
        private const int initialTurnTime = 200;
        private int accumilatedTime;

        public void Update() {
            accumilatedTime = accumilatedTime + (int) (Time.deltaTime * 1000);
            if (accumilatedTime >= initialTurnTime) {
                GameFrameTurn();
                accumilatedTime -= initialTurnTime;
            }
        }

        public void GameFrameTurn() {
            if (frameUpdate != null)
                frameUpdate();

            ActionManager.NotifyAction();

            if (lateFrameUpdate != null)
                lateFrameUpdate();

            FrameTime.UpdateFrame(initialTurnTime);
        }
    }
}