using DevIO.Business.Core.Models;
using DevIO.Business.Core.Notifications;
using FluentValidation;
using FluentValidation.Results;

namespace DevIO.Business.Core.Services
{
    public abstract class BaseService
    {
        private readonly INotificator _notificator;

        protected BaseService(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        public void Notificar(string message)
        {
            _notificator.Handle(new Notification(message));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validation.Validate(entity);

            if(validator.IsValid) return true;

            Notificar(validator);

            return false;
        }
    }
}
