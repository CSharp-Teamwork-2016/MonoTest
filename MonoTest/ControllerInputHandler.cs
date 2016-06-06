namespace MonoTest
{
    using Microsoft.Xna.Framework.Input;

    public class ControllerInputHandler : InputHandler, ICharacterController
    {
        private Keys previousKey;
        private Keys getCurrentKey;
        private int addedKeyCount;

        public ControllerInputHandler(KeyboardState keyboardState)
            : base(keyboardState)
        {
            this.getCurrentKey = default(Keys);
            this.previousKey = default(Keys);
            this.addedKeyCount = 0;
        }

        public Keys LastPressedKey
        {
            get
            {
                return this.getCurrentKey;
            }

            private set
            {
                this.getCurrentKey = value;
            }
        }

        public bool AddKey()
        {
            Keys lastPressedKey = this.GetLastKeyDown();
            if (this.KeyboardState.GetPressedKeys().Length > 0 &&
                this.ValidateKey(lastPressedKey))
            {
                if (this.addedKeyCount == 0)
                {
                    this.LastPressedKey = lastPressedKey;
                }
                else
                {
                    this.previousKey = this.LastPressedKey;
                    this.LastPressedKey = lastPressedKey;
                }
            }
            else
            {
                return false;
            }

            this.addedKeyCount++;
            return true;
        }

        public bool RemoveLastPressedKey()
        {
            Keys lastPressedKey = this.GetLastKeyUp();
            if (this.addedKeyCount < 1)
            {
                return false;
            }

            if (this.previousKey.Equals(lastPressedKey))
            {
                this.LastPressedKey = this.previousKey;
                this.previousKey = default(Keys);
            }
            else if (this.getCurrentKey.Equals(lastPressedKey))
            {
                if (!this.previousKey.Equals(default(Keys)))
                {
                    this.LastPressedKey = this.previousKey;
                    this.previousKey = default(Keys);
                }
                else
                {
                    this.LastPressedKey = default(Keys);
                }
            }

            this.addedKeyCount--;
            return true;
        }

        public override bool ValidateKey(Keys key)
        {
            if (key.Equals((Keys)37) ||
                key.Equals((Keys)38) ||
                key.Equals((Keys)39) ||
                key.Equals((Keys)40))
            {
                return true;
            }

            return false;
        }

        public override Keys GetLastKeyDown()
        {
            if (this.KeyboardState.IsKeyDown((Keys)37))
            {
                return Keys.Left;
            }

            if (this.KeyboardState.IsKeyDown((Keys)38))
            {
                return Keys.Up;
            }

            if (this.KeyboardState.IsKeyDown((Keys)39))
            {
                return Keys.Right;
            }

            if (this.KeyboardState.IsKeyDown((Keys)40))
            {
                return Keys.Down;
            }

            return default(Keys);
        }

        public override Keys GetLastKeyUp()
        {
            if (this.KeyboardState.IsKeyUp((Keys)37))
            {
                return Keys.Left;
            }

            if (this.KeyboardState.IsKeyUp((Keys)38))
            {
                return Keys.Up;
            }

            if (this.KeyboardState.IsKeyUp((Keys)39))
            {
                return Keys.Right;
            }

            if (this.KeyboardState.IsKeyUp((Keys)40))
            {
                return Keys.Down;
            }

            return default(Keys);
        }

        public bool HasAnyLeft()
        {
            if (this.getCurrentKey.Equals(default(Keys)) && this.previousKey.Equals(default(Keys)))
            {
                return false;
            }

            return true;
        }
    }
}