namespace Xunit
{
    /// <summary>
    /// Provides extension methods for the <see cref="AssumeFluent{T}" /> class.
    /// </summary>
    public static partial class AssumeFluentExtensions
    {
        public static AssumeFluent<T> Assume<T>(this T actual)
            => new AssumeFluent<T>(actual);
    }
}