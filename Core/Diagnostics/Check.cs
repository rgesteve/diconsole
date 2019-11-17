using System;

namespace diconsole.Core // Microsoft.Python.Core
{
    public static class Check
    {
        public static void ArgumentNotNull(string argumentName, object argument)
        {
            if (argument is null) {
                throw new ArgumentNullException(argumentName);
            }
        }

        public static void InvalidOperation(Func<bool> predicate, string message = null)
        {
            if (!predicate()) {
                throw new InvalidOperationException(message?? string.Empty);
            }
        }
    }
}