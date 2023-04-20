namespace Domain.ValueObjects;

public record ShipDirection(string Value)
{
    public const string Right = nameof(Right);
    public const string Left = nameof(Left);public const string Up = nameof(Up);public const string Down = nameof(Down);
    public static implicit operator string(ShipDirection userType)
        => userType.Value;

    public static implicit operator ShipDirection(string value)
    {
        return new(value);
    }
}