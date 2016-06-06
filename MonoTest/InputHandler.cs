namespace MonoTest
{
    using Microsoft.Xna.Framework.Input;

    public abstract class InputHandler : IInputHandler
    {
        protected InputHandler(KeyboardState keyboardState)
        {
            this.KeyboardState = keyboardState;
        }

        public KeyboardState KeyboardState { get; protected set; }

        public abstract bool ValidateKey(Keys key);

        public abstract Keys GetLastKeyDown();

        public abstract Keys GetLastKeyUp();
    }
}