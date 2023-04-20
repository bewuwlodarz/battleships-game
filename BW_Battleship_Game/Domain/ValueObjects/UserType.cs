namespace Domain.ValueObjects;

public record UserType(string Value)
{
    public const string Human = nameof(Human);
    public const string Computer = nameof(Computer);

    public static implicit operator string(UserType userType)
        => userType.Value;

    public static implicit operator UserType(string value)
        => new(value);
}