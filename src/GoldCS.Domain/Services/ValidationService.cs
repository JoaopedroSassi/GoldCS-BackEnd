using FluentValidation;
using FluentValidation.Results;

namespace GoldCS.Domain.Services
{
    public abstract class ValidationService
    {
        private readonly INotificationService _notificationService;

        protected ValidationService(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        protected void AddMessage(string message)
        {
            _notificationService.AddNotification(message);
        }

        protected void ClearMessages()
        {
            _notificationService.ClearNotifications();
        }

        protected async Task<bool> ExecuteValidationsAsync<TValidation, TModel>(TValidation validation, TModel model) where TValidation : AbstractValidator<TModel> where TModel : class
        {
            if (model == null)
            {
                AddMessage("Nenhuma informação preenchida");
                return false;
            }

            ValidationResult validatorResult = await validation.ValidateAsync(model);
            if (validatorResult.IsValid)
            {
                return true;
            }

            foreach (ValidationFailure erro in validatorResult.Errors)
            {
                AddMessage(erro.ErrorMessage);
            }

            return false;
        }
    }
}
