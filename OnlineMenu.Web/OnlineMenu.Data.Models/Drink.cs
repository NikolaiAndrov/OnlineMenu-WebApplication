namespace OnlineMenu.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Common.EntityValidationConstants.DrinkValidation;

    public class Drink
    {
        public Drink()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public int Milliliters { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        public bool IsAlcoholic { get; set; }

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public int DrinkCategoryId { get; set; }

        [ForeignKey(nameof(DrinkCategoryId))]
        public virtual DrinkCategory DrinkCategory { get; set; } = null!;
    }
}
