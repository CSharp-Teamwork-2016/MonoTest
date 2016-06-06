namespace MonoTest
{
    using System.Collections.Generic;

    public class CharacterInputHandler
    {
        private readonly IInputHandler[] inputHandler;

        public CharacterInputHandler(IList<IInputHandler> handlers)
        {
            this.inputHandler = new InputHandler[handlers.Count];
            this.InitializeHandlers(handlers);
        }

        public ControllerInputHandler CharacterController =>
            this.inputHandler[0] as ControllerInputHandler;

        private void InitializeHandlers(IList<IInputHandler> handlers)
        {
            for (int i = 0; i < this.inputHandler.Length; i++)
            {
                this.inputHandler[i] = handlers[i];
            }
        }
    }
}