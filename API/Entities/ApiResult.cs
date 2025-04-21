using System.Collections;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API.Entities;

/// <summary>A result from the API, which will return either <typeparamref name="T"/> or a <see cref="ProblemHttpResult"/>.</summary>
/// <typeparam name="T">The type of result to return.</typeparam>
public sealed class ApiResult<T> : IResult, INestedHttpResult
{
    /// <summary>Gets the <see cref="IResult"/> returned by the endpoint <see langword="delegate"/>.</summary>
    public IResult Result { get; }

    private ApiResult(IResult activeResult)
    {
        Result = activeResult;
    }

    /// <inheritdoc/>
    public Task ExecuteAsync(HttpContext httpContext)
    {
        ArgumentNullException.ThrowIfNull(httpContext);
        ArgumentNullException.ThrowIfNull(Result);

        return Result.ExecuteAsync(httpContext);
    }

    /// <summary>Gets an <see cref="IResult"/> based on the validity of the <paramref name="result"/>.</summary>
    /// <param name="result">The result to return as an API result.</param>
    public static implicit operator ApiResult<T>(T? result) => ResultIsValid(result)
        ? new(TypedResults.Ok(result))
        : new(TypedResults.Problem(typeof(T).Name, null, StatusCodes.Status404NotFound));

    private static bool ResultIsValid(T? result)
    {
        if (result == null)
        {
            return false;
        }

        if (result is ICollection results)
        {
            return results.Count > 0;
        }

        return true;
    }
}
