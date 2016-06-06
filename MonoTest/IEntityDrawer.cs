namespace MonoTest
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public interface IEntityDrawer
    {
        EntitySpriteSheet EntitySpriteSheet { get; }

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch);
    }
}