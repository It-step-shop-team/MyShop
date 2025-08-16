using ErrorOr;

namespace MyShop.Application.Common.Errors
{
    public static class ErrorTypes
    {
        public static class Validation
        {
            public static readonly Error InvalidOrderData = Error.Validation(
                code: "Order.InvalidData",
                description: "Invalid order data provided.");

            public static readonly Error InvalidProductData = Error.Validation(
                code: "Product.InvalidData",
                description: "Invalid product data provided.");

            public static readonly Error InvalidUserData = Error.Validation(
                code: "User.InvalidData",
                description: "Invalid user data provided.");
        }

        public static class NotFound
        {
            public static readonly Error OrderNotFound = Error.NotFound(
                code: "Order.NotFound",
                description: "Order not found.");
            
            public static readonly Error OrdersNotFound = Error.NotFound(
                code: "Order.NotFound",
                description: "Orders not found.");

            public static readonly Error ProductNotFound = Error.NotFound(
                code: "Product.NotFound",
                description: "Product not found.");
            
            public static readonly Error ProductsNotFound = Error.NotFound(
                code: "Product.NotFound",
                description: "Product not found.");

            public static readonly Error UserNotFound = Error.NotFound(
                code: "User.NotFound",
                description: "User not found.");
        }

        public static class Conflict
        {
            public static readonly Error CreateOrder = Error.Conflict(
                code: "Order.Create",
                description: "Order create failed.");
            
            public static readonly Error CreateProduct = Error.Conflict(
                code: "Product.Create",
                description: "Product create failed.");
            
            public static readonly Error UpdateOrder = Error.Conflict(
                code: "Order.Update",
                description: "Order update failed.");

            public static readonly Error UpdateProduct = Error.Conflict(
                    code: "Product.Update",
                    description: "Product update failed.");
            
            public static readonly Error DuplicateOrderId = Error.Conflict(
                code: "Order.DuplicateId",
                description: "Order with this ID already exists.");

            public static readonly Error DuplicateProductId = Error.Conflict(
                code: "Product.DuplicateId",
                description: "Product with this ID already exists.");

            public static readonly Error DuplicateUserEmail = Error.Conflict(
                code: "User.DuplicateEmail",
                description: "User with this email already exists.");

        }

        public static class Unauthorized
        {
            public static readonly Error AccessDenied = Error.Unauthorized(
                code: "Auth.AccessDenied",
                description: "Access denied.");
        }
    }
}
