using Ecommerce.API.Validation;
using Ecommerce.API.View_Model.Create;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.API.View_Model.Get
{
    public class ProductViewModel:AbstractValidatableObject
    {
        [Required]
        public int Id { get; set; }
       
        [Required]
        [MinLength(5), MaxLength(1000)]
        public string Name { get; set; }
        [Required]
        [MinLength(100), MaxLength(8000)]
        public string Descriptions { get; set; }
        [Range(5, 9000)]
        public int Price { get; set; }
        public DateTime AvailableSince { get; set; }
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
        //public List<ProductImagesViewModel> ProductImagesViewModels { get; set; }

    }
}
