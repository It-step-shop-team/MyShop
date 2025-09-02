using MyShop.Application.DTOs;
using ErrorOr;

namespace MyShop.Application.Interfaces
{
    /// <summary>
    /// Interface for managing products in the application.
    /// Defines methods for retrieving, creating, updating, and deleting products.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Retrieves a product by its unique identifier.
        /// </summary>
        /// <param name="productId">The unique identifier of the product.</param>
        /// <returns>
        /// A <see cref="PublicProductDto"/> containing product information,
        /// or an error if the product is not found.
        /// </returns>
        Task<ErrorOr<PublicProductDto>> GetProductByIdAsync(Guid productId);

        /// <summary>
        /// Retrieves all products.
        /// </summary>
        /// <returns>
        /// A collection of <see cref="PublicProductDto"/> containing all products,
        /// or an error if there is a problem accessing the data.
        /// </returns>
        Task<ErrorOr<IEnumerable<PublicProductDto>>> GetAllProductsAsync();

        /// <summary>
        /// Creates a new product based on the provided data.
        /// </summary>
        /// <param name="createProductDto">The DTO containing data for the new product.</param>
        /// <returns>
        /// A <see cref="PublicProductDto"/> representing the created product,
        /// or an error if the data is invalid.
        /// </returns>
        Task<ErrorOr<PublicProductDto>> CreateProductAsync(CreateProductDto createProductDto);

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="updateProductDto">The DTO containing updated product data.</param>
        /// <returns>
        /// The updated <see cref="PublicProductDto"/>,
        /// or an error if the product is not found or the data is invalid.
        /// </returns>
        Task<ErrorOr<PublicProductDto>> UpdateProductAsync(UpdateProductDto updateProductDto);

        /// <summary>
        /// Deletes a product by its unique identifier.
        /// </summary>
        /// <param name="productId">The unique identifier of the product.</param>
        /// <returns>
        /// <c>true</c> if the product was successfully deleted; <c>false</c> if the product was not found.
        /// Returns an error if there was a problem during deletion.
        /// </returns>
        Task<ErrorOr<bool>> DeleteProductAsync(Guid productId);
    }
}
