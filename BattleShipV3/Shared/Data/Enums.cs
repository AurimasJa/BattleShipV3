namespace BattleShipV3.Data
{
    public class Enums
    {
        public enum GameState
        {
            ACTIVE, ENDED, ABORTED
        }

        public enum TurnType
        {
            SHOOTMISSILE, PLACESHIP
        }

        public enum MissileType
        {
            SIMPLE, AOE
        }

        public enum ToastLevel
        {
            Info, Success, Warning, Error
        }
    }
}
