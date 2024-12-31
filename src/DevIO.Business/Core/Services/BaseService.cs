using DevIO.Business.Core.Models;
using FluentValidation;

namespace DevIO.Business.Core.Services
{
    public abstract class BaseService
    {
        protected bool ExecutarValidacao<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validation.Validate(entity);

            return validator.IsValid;
        }
    }
}
