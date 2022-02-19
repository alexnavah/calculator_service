namespace CalculatorService.Domain.Commands.Abstractions
{
    public abstract class OperationCommand<TParameters, TResult>
    {
        public abstract TResult Compute(TParameters parameters);
    }
}
