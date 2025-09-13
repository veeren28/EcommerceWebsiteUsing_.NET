using Ecommerce.API.View_Model.Get;
using Ecommerce.core;
using Ecommerce.service;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.API.View_Model.Create
{
    public class CreateProduct : ProductViewModel
    {
        public override async Task<IEnumerable<ValidationResult>> ValidateAsync(ValidationContext validationContext, CancellationToken cancellationToken)
        {
            var errors = new List<ValidationResult>();

            var categoryValidation = validationContext.GetService<ICategoryService>();
            var productValidation = validationContext.GetService<IProductService>();

            var isProductNameExists = productValidation.IsProductNameExsist(Name);

            if (await isProductNameExists)
            {
                errors.Add(new ValidationResult($"Product with {Name} already exists", new[] { nameof(Name) }));
            }

            if (await categoryValidation.IsExistCategoryId(CategoryId))
            {
                errors.Add(new ValidationResult($"Product with that {CategoryId} exists"));

            }
            if (Price < 5)
            {
                errors.Add(new ValidationResult($"Price must be greater than 4"));
            }
            return errors;


        }
    }
}
