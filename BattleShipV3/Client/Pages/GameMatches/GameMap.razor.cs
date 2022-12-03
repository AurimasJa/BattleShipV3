using BattleShipV3.Client.DesignPatterns;
using BattleShipV3.Client.DesignPatterns.Bridge;
using BattleShipV3.Client.DesignPatterns.Prototype;
using BattleShipV3.Data.Models;
using BattleShipV3.Shared.Data.Interfacess;
using BattleShipV3.Shared.Data.Models;
using Microsoft.AspNetCore.Components;
using static BattleShipV3.Data.Enums;

namespace BattleShipV3.Client.Pages.GameMatches
{
    partial class GameMap
    {

        [Parameter] public GamePhase gamePhase { get; set; }
        [Parameter] public GamePlayerModel Player { get; set; }
        [Parameter] public EventCallback OnShipPhaseEnded { get; set; }
        [Parameter] public EventCallback<FireMissileEventArgs> OnFireMissile { get; set; }
        [Parameter] public EventCallback<MissileLandEventArgs> OnMissileLanded { get; set; }

        List<bool?[]> HitMap;

        //[Parameter] public BattleShipV3.Models.User User { get; set; }
        //[Parameter] public List< Player { get; set; }


        Ship selectedShip;

        List<Ship> PlacedShips = new List<Ship>();

        ActualMap actualMap;

        bool? IsMyTurn { get; set; } = true;

        int LastFireX = -1;
        int LastFireY = -1;

        protected override async Task OnInitializedAsync()
        {

            HitMap = new List<bool?[]>();
            for (int i = 0; i < 10; i++)
            {
                HitMap.Add(new bool?[10]);
            }

            actualMap = new ActualMap();
        }

        public void OnClickGridPaper(int x, int y, bool isShooting)
        {
            if (gamePhase == GamePhase.LAYOUT && !isShooting)
            {
                PlaceShip(x, y);
            }
            else if (gamePhase == GamePhase.ACTIVE && isShooting && IsMyTurn == true)
            {
                FireMissile(x, y);
            }

            StateHasChanged();
        }

        public void MissileLand(int x, int y)
        {
            bool isHit = this.actualMap.LandMissile(x, y);
            MissileLandEventArgs e = new MissileLandEventArgs()
            {
                IsHit = isHit,
                UserId = Player.User.Id
            };
            OnMissileLanded.InvokeAsync(e);
            IsMyTurn = !isHit;
            StateHasChanged();
        }

        public void FireMissile(int x, int y)
        {
            IsMyTurn = false;
            FireMissileEventArgs args = new FireMissileEventArgs();
            args.X = x;
            args.Y = y;
            args.UserId = Player.User.Id;

            OnFireMissile.InvokeAsync(args);
            LastFireX = x;
            LastFireY = y;
        }

        public void AfterHit(bool isHit)
        {
            HitMap[LastFireX][LastFireY] = isHit;
            IsMyTurn = isHit;
            StateHasChanged();
        }

        public string GetPhase()
        {
            if (gamePhase == GamePhase.LAYOUT)
                return "Ship placement Phase";
            else
                return "Game in progress";
        }

        public void RefreshUI()
        {
            StateHasChanged();
        }

        public void SelectShip(Ship context)
        {
            this.selectedShip = context;
        }

        public void ChangeShipColor(Ship selectedShip, ShipColor color)
        {
            selectedShip.ColorChanger = GetColorChanger(color);
            if (selectedShip.ColorChanger != null)
                selectedShip.ChangeColor();
        }

        public IColorChanger GetColorChanger(ShipColor color)
        {
            switch (color)
            {
                case ShipColor.PURPLE:
                    return new ColorChangerPurple();
                case ShipColor.ORANGE:
                    return new ColorChangerOrange();
            }

            return null;
        }

        public bool IsRotated(Ship? context)
        {
            if (context.Rotation == ShipRotation.VERTICAL)
            {
                context.Rotation = ShipRotation.HORIZONTAL;
                return true;
            }
            else if (context.Rotation == ShipRotation.HORIZONTAL)
            {
                context.Rotation = ShipRotation.VERTICAL;
                return true;
            }
            return false;
        }

        public void PlaceShip(int x, int y)
        {
            if (selectedShip is null)
                return;

            if (selectedShip.Rotation == ShipRotation.HORIZONTAL && selectedShip.Length + x > 10)
                return;

            if (selectedShip.Rotation == ShipRotation.VERTICAL && selectedShip.Length + y > 10)
                return;

            if (actualMap.IsShipPlaced(selectedShip, x, y))
            {
                PlacedShips.Add(selectedShip);
                selectedShip = null;
            }

            StateHasChanged();

            if (PlacedShips.Count >= 4)
                OnShipPhaseEnded.InvokeAsync();
        }

        public string ColorEnumToHex(Ship context)
        {
            if (context.Color == ShipColor.WHITE)
            {
                return "background:#BDBDBD";
            }
            else if (context.Color == ShipColor.BLUE)
            {
                return "background:#1565C0";
            }
            else if (context.Color == ShipColor.GREEN)
            {
                return "background:#7CB342";
            }
            else if (context.Color == ShipColor.ORANGE)
            {
                return "background:#FF9800";
            }
            else if (context.Color == ShipColor.PURPLE)
            {
                return "background:#7B1FA2";
            }
            return "XD";
        }

        public class FireMissileEventArgs
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int UserId { get; set; }
        }

        public class MissileLandEventArgs
        {
            public bool IsHit { get; set; }
            public int UserId { get; set; }
        }

        class ActualMap : IActualMap
        {
            public List<PlaySquare> playSquaresDeep { get; set; } = new List<PlaySquare>();
            public List<PlaySquare> playSquaresShallow { get; set; } = new List<PlaySquare>();
            //public Square[,] playField { get; set; }
            public List<Square[]> playField { get; set; }
            public PlaySquare oneplaySquare { get; set; }

            public ActualMap()
            {
                playField = new List<Square[]>();
                for (var i = 0; i < 11; i++)
                {
                    playField.Add(new Square[11]);

                    for (var j = 0; j < 11; j++)
                    {
                        playField[i][j] = new Square(SquareType.NONE, null);
                    }
                }
            }

            public bool LandMissile(int x, int y)
            {
                return playField[x][y].LandMissile();
            }

            public bool IsShipPlaced(Ship ship, int x, int y)
            {
                if (IsAllowedToPlace(ship, x, y))
                {
                    for (var i = 0; i < ship.Length; i++)
                    {
                        if (ship.Rotation == ShipRotation.HORIZONTAL)
                        {
                            playField[x + i][y].AssignShip(ship);
                        }
                        else
                        {
                            playField[x][y + i].AssignShip(ship);
                        }
                    }
                    return true;
                }
                return false;
            }

            public Square GetSquare(int x, int y)
            {
                return this.playField[x][y];
            }

            public bool IsAllowedToPlace(Ship ship, int x, int y)
            {

                //PlaySquare playSquare = new PlaySquare(0,0,"Nieko..");
                for (var i = 0; i < ship.Length; i++)
                {

                    if (ship.Rotation == ShipRotation.HORIZONTAL)
                    {
                        if (playField[x + i][y].squareType == SquareType.SHIP)
                        {
                            //playSquare = new PlaySquare(x+i,y,"H - Negalimas");

                            PrototypeCopies(x + i, y, "H - Negalimas");/*, 1, false*/
                            return false;
                        }
                        //playSquare = new PlaySquare(x+i,y,"H - Galimas");

                        PrototypeCopies(x + i, y, "H - Galimas");/*, 1, false*/
                    }
                    if (ship.Rotation == ShipRotation.VERTICAL)
                    {
                        if (playField[x][y + i].squareType == SquareType.SHIP)
                        {

                            PrototypeCopies(x + i, y, "V - Negalimas");/*, 2, false*/
                            return false;
                        }
                        //playSquare = new PlaySquare(x+i,y,"V - Galimas");
                        PrototypeCopies(x + i, y, "V - Galimas");
                    }

                }
                return true;
            }

            public void AssignShip(Ship ship, int x, int y)
            {
                playField[x][y].AssignShip(ship);
            }
            public void PrototypeCopies(int x, int y, string actionName)/*,int rotation, bool possible*/
            {
                PlaySquare playSquare = new PlaySquare(x, y, actionName);
                playSquaresDeep.Add(playSquare.DeepCopy());
                playSquaresShallow.Add(playSquare.ShallowCopy());
            }
        }

    }
}
