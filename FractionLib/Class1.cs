namespace FractionLib;
#region Fraction
public readonly struct Fraction
{
    public readonly int Numerator => _numerator;
    public readonly int Denominator => _denominator;
    private readonly int _denominator {  get; }
    private readonly int _numerator { get; }
    public Fraction(int numerator, int denumerator)
    {
        if (denumerator == 0)
            throw new DivideByZeroException();
        if(denumerator < 0)
        {
            numerator = -numerator;
            denumerator = -denumerator;
        }
        _numerator = numerator;
        _denominator = denumerator;
    }
    public static Fraction operator +(Fraction a) => a;
    public static Fraction operator -(Fraction a) => 
        new Fraction(-a._numerator, a._denominator);
    public static Fraction operator +(Fraction a, Fraction b)
        => new Fraction(a._numerator * b._denominator + b._numerator * a._denominator, a._denominator * b._denominator);
    public static Fraction operator -(Fraction a, Fraction b)
        => new Fraction(a._numerator * b._denominator - b._numerator * a._denominator, a._denominator * b._denominator);
    public static Fraction operator *(Fraction a, Fraction b)
        => new Fraction(a._numerator * b._numerator, a._denominator * b._denominator);
    public static Fraction operator /(Fraction a, Fraction b)
        => new Fraction(a._numerator * b._denominator, a._denominator * b._numerator);
}
#endregion