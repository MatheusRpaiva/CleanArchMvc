using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name","Product Description",9.99m,99,"product image");
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExecptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m, 99, "product image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExecptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 9.99m, 99, "product image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 charecters");
        }

        [Fact]
        public void CreateProduct_MissingNameValue_DomainExecptionRequiredName()
        {
            Action action = () => new Product(1, "", "Product Description", 9.99m, 99, "product image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }
        [Fact]
        public void CreateProduct_WithNullNameValue_DomainExecptionInvalidName()
        {
            Action action = () => new Product(1, null, "Product Description", 9.99m, 99, "product image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value) 
        {
            Action action = () => new Product(1, "Pro", "Product Description", 9.99m, value, "product image");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value");
        }
    }
}
