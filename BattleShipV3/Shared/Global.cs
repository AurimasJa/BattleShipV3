using BattleShipV3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipV3.Shared
{
    public static class Global
    {
        public static User CurrentUser { get; set; }
        public static Listing CurrentListing { get; set; }
    }
}
