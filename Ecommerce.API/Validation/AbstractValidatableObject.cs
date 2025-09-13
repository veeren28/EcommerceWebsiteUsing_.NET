using System.ComponentModel.DataAnnotations;

namespace Ecommerce.API.Validation
{
    public abstract class AbstractValidatableObject : IValidatableObject
    {
        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            CancellationTokenSource source = new CancellationTokenSource();

            var task = ValidateAsync(validationContext, source.Token);

            Task.WaitAll(task);

            return task.Result;
        }

        public virtual Task<IEnumerable<ValidationResult>> ValidateAsync(ValidationContext validationContext, CancellationToken cancellation)
        {
            return Task.FromResult((IEnumerable<ValidationResult>)new List<ValidationResult>());
        }

    }
}
// this code will convert IValidatableObject method to an async method. now this can be  used on our Async db for custom validations