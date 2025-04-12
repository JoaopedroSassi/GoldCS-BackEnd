namespace GoldCS.Domain.Services
{
    public interface IBaseValidationService<TReturn, TParameters>
    {
        Task<TReturn> Process(TParameters parameters);
    }
    public abstract class BaseValidationService<TReturn, TParameters> : ValidationService, IBaseValidationService<TReturn, TParameters>
    {
        protected BaseValidationService(INotificationService notificationService) : base(notificationService) { }

        public abstract Task<TReturn> Process(TParameters parameters);
    }
}
