namespace CalculatorService.Domain.Commands
{
    public abstract class OperationCommand<TParameters, TResult>
    {
        public abstract TResult Compute(TParameters parameters);
    }
}
