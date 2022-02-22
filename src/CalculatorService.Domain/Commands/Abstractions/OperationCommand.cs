namespace CalculatorService.Domain.Commands.Abstractions
{
    /// <summary>
    ///     
    /// </summary>
    /// <typeparam name="TParameters"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public abstract class OperationCommand<TParameters, TResult>
    {
        public abstract TResult Compute(TParameters parameters);
    }
}
