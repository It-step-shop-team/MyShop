namespace MyShop.Domain.ListLikeEntities
{
    /// <summary>
    /// Represents the status of an order throughout its lifecycle.
    /// </summary>
    public enum StatusType
    {
        /// <summary>Order has just been created.</summary>
        Created,

        /// <summary>Order is awaiting payment.</summary>
        AwaitingPayment,

        /// <summary>Order has been paid.</summary>
        Paid,

        /// <summary>Order is ready for shipment.</summary>
        AwaitingShipment,

        /// <summary>Order has been shipped.</summary>
        Shipped,

        /// <summary>Order is in transit to the customer.</summary>
        InTransit,

        /// <summary>Order is out for delivery by the courier.</summary>
        OutForDelivery,

        /// <summary>Order has been delivered to the customer.</summary>
        Delivered,

        /// <summary>Order has been completed (optional, after confirmation).</summary>
        Completed,

        /// <summary>Order has been cancelled.</summary>
        Cancelled,

        /// <summary>Order has been returned.</summary>
        Returned,

        /// <summary>Payment for the order has been refunded.</summary>
        Refunded
    }
}
