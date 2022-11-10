using BattleShipV3.Client.DesignPatterns.Prototype;
using BattleShipV3.Data.Models;
using BattleShipV3.Shared.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipV3.Shared.Data.Interfacess
{
    public interface IActualMap
    {
        public List<PlaySquare> playSquaresDeep { get; set; }
        public List<PlaySquare> playSquaresShallow { get; set; }
        //public Square[,] playField { get; set; }
        public List<Square[]> playField { get; set; }
        public PlaySquare oneplaySquare { get; set; }
        bool LandMissile(int x, int y);
        bool IsShipPlaced(Ship ship, int x, int y);
        Square GetSquare(int x, int y);
        bool IsAllowedToPlace(Ship ship, int x, int y);
        void AssignShip(Ship ship, int x, int y);
        void PrototypeCopies(int x, int y, string actionName);
    }
}
