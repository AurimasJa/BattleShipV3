namespace BattleShipV3.Client.DesignPatterns.Prototype
{
    public class PlaySquare
    {
        public int squareXcoor { get; set; }
        public int squareYcoor { get; set; }
        public string squareAction { get; set; }
        public DateTime squareActionTime { get; set; }

        public PlaySquare(int squareXcoor, int squareYcoor, string squareAction)
        {
            this.squareXcoor = squareXcoor;
            this.squareYcoor = squareYcoor;
            this.squareAction = squareAction;
        }
        public PlaySquare ShallowCopy()
        {
            return (PlaySquare)this.MemberwiseClone();
        }

        public PlaySquare DeepCopy()
        {
            PlaySquare newclone = (PlaySquare)this.MemberwiseClone();
            newclone.squareActionTime = DateTime.Now;
            return newclone;
        }
    }
}
