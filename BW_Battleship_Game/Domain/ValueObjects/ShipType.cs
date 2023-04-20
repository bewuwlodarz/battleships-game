namespace Domain.ValueObjects;

public record ShipType(string Value, int Slots)
{
    public const string Battleship = nameof(Battleship);
    public const string Destroyers = nameof(Destroyers);
    public const int MaxBattleshipSlots = 5;
    public const int MaxDestroyersSlots = 4;

    public static implicit operator string(ShipType userType)
        => userType.Value;

    public static implicit operator ShipType(string value)
    {
        switch (value)
        {
            case Battleship:
            return new(value, MaxBattleshipSlots);
            case Destroyers: return new(value, MaxDestroyersSlots);
                default:
                    return new(value, 0);
        }
    }
}