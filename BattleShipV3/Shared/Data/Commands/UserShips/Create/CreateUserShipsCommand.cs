﻿using BattleShipV3.Data.Models;
using BattleShipV3;
using BattleShipV3.Shared;
using BattleShipV3.Shared.Data;
using BattleShipV3.Models;

namespace BattleShipV3.Shared.Data.Commands.UserShips.Create;

public record CreateUserShipsCommand(Models.User User, BattleShipV3.Data.Models.Ship Ship);