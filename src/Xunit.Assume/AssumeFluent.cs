namespace Xunit
{
    /// <summary>
    /// Provides the actual implementation for the Assume methods in fluent way.
    /// </summary>
    public class AssumeFluent<T>
    {
        internal AssumeFluent(T innerObject)
        {
            InnerObject = innerObject;
        }

        internal T InnerObject { get; }
    }
}
