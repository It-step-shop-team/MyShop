using ErrorOr;

namespace MyShop.Application.Common.Errors
{
    /// <summary>
    /// Provides a centralized collection of common error definitions
    /// used across the application. 
    /// Errors are grouped into categories (Validation, NotFound, Conflict, Unauthorized).
    /// </summary>
    public static class ErrorTypes
    {
        /// <summary>
        /// Contains errors related to invalid or incorrect data.
        /// </summary>
        public static class Validation
        {
            /// <summary>
            /// Error returned when order data is invalid.
            /// </summary>
            public static readonly Error InvalidOrderData = Error.Validation(
                code: "Order.InvalidData",
                description: "Invalid order data provided.");

            /// <summary>
            /// Error returned when product data is invalid.
            /// </summary>
            public static readonly Error InvalidProductData = Error.Validation(
                code: "Product.InvalidData",
                description: "Invalid product data provided.");

            /// <summary>
            /// Error returned when user data is invalid.
            /// </summary>
            public static readonly Error InvalidUserData = Error.Validation(
                code: "User.InvalidData",
                description: "Invalid user data provided.");
        }

        /// <summary>
        /// Contains errors related to missing entities in the system.
        /// </summary>
        public static class NotFound
        {
            /// <summary>
            /// Error returned when an order with the given criteria cannot be found.
            /// </summary>
            public static readonly Error OrderNotFound = Error.NotFound(
                code: "Order.NotFound",
                description: "Order not found.");

            /// <summary>
            /// Error returned when no orders match the search criteria.
            /// </summary>
            public static readonly Error OrdersNotFound = Error.NotFound(
                code: "Order.NotFound",
                description: "Orders not found.");

            /// <summary>
            /// Error returned when a product with the given criteria cannot be found.
            /// </summary>
            public static readonly Error ProductNotFound = Error.NotFound(
                code: "Product.NotFound",
                description: "Product not found.");

            /// <summary>
            /// Error returned when no products match the search criteria.
            /// </summary>
            public static readonly Error ProductsNotFound = Error.NotFound(
                code: "Product.NotFound",
                description: "Products not found.");

            /// <summary>
            /// Error returned when a user with the given criteria cannot be found.
            /// </summary>
            public static readonly Error UserNotFound = Error.NotFound(
                code: "User.NotFound",
                description: "User not found.");
        }

        /// <summary>
        /// Contains errors related to conflicts, such as duplicates or failed operations.
        /// </summary>
        public static class Conflict
        {
            /// <summary>
            /// Error returned when an order creation operation fails.
            /// </summary>
            public static readonly Error CreateOrder = Error.Conflict(
                code: "Order.Create",
                description: "Order create failed.");

            /// <summary>
            /// Error returned when a product creation operation fails.
            /// </summary>
            public static readonly Error CreateProduct = Error.Conflict(
                code: "Product.Create",
                description: "Product create failed.");

            /// <summary>
            /// Error returned when an order update operation fails.
            /// </summary>
            public static readonly Error UpdateOrder = Error.Conflict(
                code: "Order.Update",
                description: "Order update failed.");

            /// <summary>
            /// Error returned when a product update operation fails.
            /// </summary>
            public static readonly Error UpdateProduct = Error.Conflict(
                    code: "Product.Update",
                    description: "Product update failed.");

            /// <summary>
            /// Error returned when trying to create an order with an ID that already exists.
            /// </summary>
            public static readonly Error DuplicateOrderId = Error.Conflict(
                code: "Order.DuplicateId",
                description: "Order with this ID already exists.");

            /// <summary>
            /// Error returned when trying to create a product with an ID that already exists.
            /// </summary>
            public static readonly Error DuplicateProductId = Error.Conflict(
                code: "Product.DuplicateId",
                description: "Product with this ID already exists.");

            /// <summary>
            /// Error returned when trying to create a user with an email that already exists.
            /// </summary>
            public static readonly Error DuplicateUserEmail = Error.Conflict(
                code: "User.DuplicateEmail",
                description: "User with this email already exists.");
        }

        /// <summary>
        /// Contains errors related to unauthorized access.
        /// </summary>
        public static class Unauthorized
        {
            /// <summary>
            /// Error returned when access to a resource is denied due to insufficient permissions.
            /// </summary>
            public static readonly Error AccessDenied = Error.Unauthorized(
                code: "Auth.AccessDenied",
                description: "Access denied.");
        }
    }
}
