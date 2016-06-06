namespace MonoTest
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class EntitySpriteSheet
    {
        private Vector2 position;
        private readonly IList<EntitySpriteSheet> entityParts;
        private readonly IList<Rectangle[]> particles;

        public EntitySpriteSheet(Texture2D texture, Vector2 position, int rows, int columns)
        {
            this.Texture = texture;
            this.position = position;
            this.SpriteSheetRows = rows;
            this.SpriteSheetCols = columns;
            this.entityParts = new List<EntitySpriteSheet>();
            this.particles = new List<Rectangle[]>();
        }

        public int TopMovementSpriteSheet { get; private set; }

        public int BottomMovementSpriteSheet { get; private set; }

        public int LeftMovementSpriteSheet { get; private set; }

        public int RightMovementSpriteSheet { get; private set; }

        public Texture2D Texture { get; private set; }

        public int SpriteSheetRows { get; private set; }

        public int SpriteSheetCols { get; private set; }

        public Rectangle GetRactangleByPosition(int row, int col)
        {
            return this.particles[row][col];
        }

        public void IntializeMovementPositions(
            int topMovementSpriteSheet,
            int bottomMovementSpriteSheet,
            int leftMovementSpriteSheet,
            int rightMovementSpriteSheet)
        {
            this.TopMovementSpriteSheet = topMovementSpriteSheet;
            this.BottomMovementSpriteSheet = bottomMovementSpriteSheet;
            this.LeftMovementSpriteSheet = leftMovementSpriteSheet;
            this.RightMovementSpriteSheet = rightMovementSpriteSheet;
        }

        public void InitializeParticles(params EntitySpriteSheet[] entitySpriteSheet)
        {
            int partCounts = entitySpriteSheet.Length;
            for (int i = 0; i < partCounts; i++)
            {
                this.particles.Add(new Rectangle[this.SpriteSheetCols]);
            }

            for (int i = 0; i < this.particles.Count; i++)
            {
                for (int currentRow = 0; currentRow < this.particles[i].Length; currentRow++)
                {
                    int width = this.Texture.Width / this.SpriteSheetCols;
                    int height = this.Texture.Height / this.SpriteSheetRows;
                    for (int col = 0; col < this.SpriteSheetCols; col++)
                    {
                        this.particles[currentRow][col] =
                            new Rectangle(width * col, height * currentRow, width, height);
                    }
                }
            }
        }

        public Vector2 GetPosition()
        {
            return this.position;
        }
    }
}