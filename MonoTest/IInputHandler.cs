namespace MonoTest
{
    using Microsoft.Xna.Framework.Input;

    public interface IInputHandler
    {
        KeyboardState KeyboardState { get; }

        bool ValidateKey(Keys key);

        Keys GetLastKeyDown();

        Keys GetLastKeyUp();
    }
}