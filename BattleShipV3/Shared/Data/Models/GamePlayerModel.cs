using BattleShipV3.Data.Models;
using BattleShipV3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipV3.Shared.Data.Models
{
    public class GamePlayerModel
    {
        public User User { get; set; }
        public IEnumerable<Ship> Ships { get; set; }
    }
}
