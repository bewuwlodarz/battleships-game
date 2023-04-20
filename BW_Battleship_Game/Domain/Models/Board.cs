using System.Collections.ObjectModel;
using Domain.Helpers;
using Domain.ValueObjects;
using FluentResults;

namespace Domain.Models;

public class Board
{
    public Board(IEnumerable<Coordinate> shotCoordinates, IReadOnlyCollection<Ship> ships)
    {
        ShotCoordinates = shotCoordinates;
        Ships = ships;
    }

    public IReadOnlyCollection<Ship> Ships { get; private set; }
    public IEnumerable<Coordinate> ShotCoordinates { get; set; }


    public static Result<Board> Create()
    {
        var ships = new List<Ship>()
            {Ship.Create(ShipType.Battleship, ShipHelper.CreateShip(ShipCoordinate.Create(10, 1).Value, ShipType.Battleship, ShipDirection.Left).Value).Value};
        var board = new Board(new List<Coordinate>(), ships);
        return Result.Ok(board);
    }
}