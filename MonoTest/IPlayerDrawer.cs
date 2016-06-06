namespace MonoTest
{
    public interface IPlayerDrawer : IEntityDrawer
    {
        Character Player { get; }

        ControllerInputHandler ControllerInputHandler { get; }
    }
}