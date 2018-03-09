namespace LockstepFramework {
    public class CharacterManager : Singleton<CharacterManager> {
        public Entity CreateCharacter() {
            Entity entity = new Entity();
            entity.CreateComponent<PositionComponent>();
            return entity;
        }
    }
}