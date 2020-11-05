using Ardalis.GuardClauses;
using CaWorkshop.Application.Common.Exceptions;

namespace CaWorkshop.Application.Common.Extensions
{
    public static class GuardClauseExtensions
    {
        /// <summary>
        /// Throws an <see cref="NotFoundException" /> if <paramref name="input" /> is null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="guardClause"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <returns><paramref name="input" /> if the value is not null.</returns>
        public static T NotFound<T>(this IGuardClause guardClause, T input, object key)
        {
            if (input is null)
            {
                throw new NotFoundException(typeof(T).Name, key);
            }

            return input;
        }
    }
}
