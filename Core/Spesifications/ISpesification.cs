using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Spesifications
{
    public interface ISpesification<T>
    {
        
        Expression<Func<T, bool>> Criteria { get;}
        List<Expression<Func<T, Object>>> Includes {get;}

        Expression<Func<T, object>> OrderBy { get; }

        Expression<Func<T, object>> OrderByDescending { get; }
    }
}