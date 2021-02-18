using FluentValidation;
using FluentValidation.Results;
using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces;
using LEMV.Domain.Notifications;

namespace LEMV.Domain.Services
{
    public abstract class BaseService<T> : IBaseService<T>
        where T : Entity
    {
        private readonly INotificator _notificator;

        public BaseService(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected void Notify(string message)
        {
            _notificator.Handle(new Notification(message));
        }

        protected void Notify(ValidationResult validationResult)
        {
            var errors = validationResult.Errors;

            foreach (var error in errors)
            {
                Notify(error.ErrorMessage);
            }
        }

        protected bool Validate<TEntity>(AbstractValidator<TEntity> validator, TEntity entity)
        {
            var result = validator.Validate(entity);

            if (result.IsValid) return true;

            Notify(result);

            return false;
        }
    }
}
