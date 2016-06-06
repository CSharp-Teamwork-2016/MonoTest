namespace MonoTest
{
    public class Character
    {
        public Character(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
        }

        public int Rows { get; }

        public int Columns { get; }
    }
}