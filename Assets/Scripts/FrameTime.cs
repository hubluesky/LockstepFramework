namespace LockstepFramework {
    public sealed class FrameTime {
        public static int frameCount { get; internal set; }
        public static int deltaTime { get; internal set; }
        public static int time { get; internal set; }

        internal static void UpdateFrame(int deltaTime) {
            FrameTime.frameCount++;
            FrameTime.deltaTime = deltaTime;
            FrameTime.time += deltaTime;
        }
    }
}