namespace Backend.Patterns;

public abstract record Maybe<T>;

public sealed record Some<T>(T Value) : Maybe<T>
{
    public static Maybe<T> None() => new None<T>();
}

public sealed record None<T>() : Maybe<T>;

// Ниже выделенная строка (вероятно, попытка использования):
// public record Some<T>(T Value) : Maybe<T>;
