using System;
namespace Core.Utilities.Results
{
    // Temel voidler icin baslangic
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
