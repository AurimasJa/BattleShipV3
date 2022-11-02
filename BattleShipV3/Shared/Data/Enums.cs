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
        public enum ShipColor
        {
            BLACK, BLUE, GREEN, YELLOW, PURPLE, WHITE, RED, ORANGE
        }

        public enum UserEvent
        {
            LOGIN, LOGOFF
        }

        public enum GamePhase
        {
            LAYOUT, ACTIVE, ENDED
        }

        public enum SquareType
        {
            SHIP, DESTROYED, NONE, MISSED
        }

        public enum ShipRotation
        {
            HORIZONTAL, VERTICAL   
        }
    }
}
