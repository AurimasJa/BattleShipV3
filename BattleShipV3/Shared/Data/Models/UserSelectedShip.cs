using BattleShipV3.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipV3.Data.Models
{
    public class UserSelectedShip
    {
        public int Id { get; set; }
        public BattleShipV3.Models.User User { get; set; }
        public Ship Ship { get; set; }
    }
}
