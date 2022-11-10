using BattleShipV3.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BattleShipV3.Data.Enums;

namespace BattleShipV3.Shared.Data.Models
{
    public class Square
    {
        public SquareType squareType { get; set; }
        public Ship? ship { get; set; }

        public Square(SquareType squareType, Ship ship)
        {
            this.squareType = squareType;
            this.ship = ship;
        }

        public void AssignShip(Ship ship)
        {
            this.ship = ship;
            this.squareType = SquareType.SHIP;
        }

        public bool LandMissile()
        {
            if (squareType == SquareType.SHIP)
            {
                squareType = SquareType.DESTROYED;
                return true;
            }

            squareType = SquareType.MISSED;
            return false;
        }
    }
}
