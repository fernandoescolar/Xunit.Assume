using System;
using Xunit.Sdk;

namespace Xunit
{
    public static class Assume
    {
        public static void That(bool condition, string message = null)
        {
            if (!condition)
            {
                Reject(message);
            }
        }

        public static void That(Func<bool> condition, string message = null)
        {
            That(condition(), message);
        }

        public static void NotNull<T>(T obj, string message = null)
        {
            That(obj != null, message);
        }

        public static void NotNull<T>(Func<T> getter, string message = null)
        {
            That(getter() != null, message);
        }

        public static void True(bool condition, string message = null)
        {
            That(condition, message);
        }

        public static void True(Func<bool> condition, string message = null)
        {
            That(condition, message);
        }

        public static void False(bool condition, string message = null)
        {
            That(!condition, message);
        }

        public static void False(Func<bool> condition, string message = null)
        {
            False(condition(), message);
        }

        public static void NotEmpty(string str, string message = null)
        {
            That(!string.IsNullOrEmpty(str), message);
        }

        public static void NotEmpty(Func<string> getter, string message = null)
        {
            NotEmpty(getter(), message);
        }

        public static void Empty(string str, string message = null)
        {
            That(string.IsNullOrEmpty(str), message);
        }

        public static void Empty(Func<string> getter, string message = null)
        {
            Empty(getter(), message);
        }

        public static void Equals<T>(T expected, T target, string message = null)
        {
            That(expected.Equals(target), message);
        }

        public static void NotEquals<T>(T expected, T target, string message = null)
        {
            That(!expected.Equals(target), message);
        }

        public static void Reject(string message = null)
        {
            throw new AssumeException(message ?? "Assume rule not fulfilled");
        }
    }
}
