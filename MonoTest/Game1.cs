using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoTest
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private ControllerInputHandler controllerInputHandler;
        private Character player;
        private PlayerDrawer playerDrawer;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
            this.controllerInputHandler =
                new ControllerInputHandler(Keyboard.GetState());
            Vector2 playerPosition = new Vector2(20, 20);
            Texture2D playerTexture = Content.Load<Texture2D>("Enemy\\beatem");
            this.player = new Character(4, 4);
            EntitySpriteSheet ess =
                new EntitySpriteSheet(
                    playerTexture, playerPosition, 4, 4);
            ess.IntializeMovementPositions(3, 0, 1, 2);
            ess.InitializeParticles(new EntitySpriteSheet[]
            {
                new EntitySpriteSheet(ess.Texture, playerPosition, 1, ess.SpriteSheetCols),
                new EntitySpriteSheet(ess.Texture, playerPosition, 1, ess.SpriteSheetCols),
                new EntitySpriteSheet(ess.Texture, playerPosition, 1, ess.SpriteSheetCols),
                new EntitySpriteSheet(ess.Texture, playerPosition, 1, ess.SpriteSheetCols)
            });

            this.playerDrawer = new PlayerDrawer(playerPosition, ess, this.player, this.controllerInputHandler);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            this.controllerInputHandler =
                new ControllerInputHandler(Keyboard.GetState());
            this.playerDrawer.Update(gameTime);

            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            this.spriteBatch.Begin();
            this.playerDrawer.Draw(this.spriteBatch);
            this.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}