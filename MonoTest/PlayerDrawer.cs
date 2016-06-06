namespace MonoTest
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class PlayerDrawer : IPlayerDrawer
    {
        private const int MilisecondsPerFrame = 100;
        private readonly int totalFrames;
        private Vector2 position;
        private int currentFrame;
        private int timeSinceLastFrame;
        private int currentRow;
        private bool isMoving;

        public PlayerDrawer(
            Vector2 position,
            EntitySpriteSheet entitySpriteSheet,
            Character player,
            ControllerInputHandler characterInputController)
        {
            this.position = position;
            this.EntitySpriteSheet = entitySpriteSheet;
            this.Player = player;
            this.ControllerInputHandler = characterInputController;
            this.currentFrame = 0;
            this.totalFrames =
                this.EntitySpriteSheet.SpriteSheetRows * this.EntitySpriteSheet.SpriteSheetCols;
            this.currentRow = 0;
            this.isMoving = false;
        }

        public int TopMovementSpriteSheet =>
            this.EntitySpriteSheet.TopMovementSpriteSheet;

        public int BottomMovementSpriteSheet =>
            this.EntitySpriteSheet.BottomMovementSpriteSheet;

        public int LeftMovementSpriteSheet =>
            this.EntitySpriteSheet.LeftMovementSpriteSheet;

        public int RightMovementSpriteSheet =>
            this.EntitySpriteSheet.RightMovementSpriteSheet;

        public EntitySpriteSheet EntitySpriteSheet { get; }

        public Character Player { get; }

        public ControllerInputHandler ControllerInputHandler { get; }

        public void Update(GameTime gameTime)
        {
            this.Move();
            SetTimeUpdate(gameTime);
        }

        private void SetTimeUpdate(GameTime gameTime)
        {
            this.timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (this.timeSinceLastFrame > MilisecondsPerFrame)
            {
                this.timeSinceLastFrame -= MilisecondsPerFrame;
                this.currentFrame++;
                this.timeSinceLastFrame = 0;
                if (currentFrame == totalFrames)
                {
                    currentFrame = 0;
                }
            }
        }

        public void Move()
        {
            if (this.ControllerInputHandler.AddKey())
            {
                switch (this.ControllerInputHandler.LastPressedKey)
                {
                    case (Keys)37:
                        this.currentRow = this.LeftMovementSpriteSheet;
                        this.position.Y--;
                        this.isMoving = true;
                        break;
                    case (Keys)38:
                        this.currentRow = this.TopMovementSpriteSheet;
                        this.position.X--;
                        this.isMoving = true;
                        break;
                    case (Keys)39:
                        this.currentRow = this.RightMovementSpriteSheet;
                        this.position.Y++;
                        this.isMoving = true;
                        break;
                    case (Keys)40:
                        this.currentRow = this.BottomMovementSpriteSheet;
                        this.position.X++;
                        this.isMoving = true;
                        break;
                    default:
                        break;
                }
            }

            if (this.ControllerInputHandler.RemoveLastPressedKey() && !this.ControllerInputHandler.HasAnyLeft())
            {
                this.isMoving = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = this.EntitySpriteSheet.Texture.Width / this.EntitySpriteSheet.SpriteSheetCols;
            int height = this.EntitySpriteSheet.Texture.Height / this.EntitySpriteSheet.SpriteSheetRows;
            int row = currentRow;
            int col = currentFrame % this.EntitySpriteSheet.SpriteSheetCols;
            Rectangle destinationRectangle =
                new Rectangle((int)position.X, (int)position.Y, width, height);
            if (isMoving)
            {                
                spriteBatch
                    .Draw(
                    this.EntitySpriteSheet.Texture,
                    destinationRectangle,
                    this.EntitySpriteSheet.GetRactangleByPosition(currentRow, col),
                    Color.White);
            }
            else
            {
                spriteBatch
                    .Draw(
                    this.EntitySpriteSheet.Texture,
                    destinationRectangle,
                    this.EntitySpriteSheet.GetRactangleByPosition(currentRow, 0),
                    Color.White);
            }
        }
    }
}