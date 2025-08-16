namespace MyShop.Domain.BaseEntities;

public enum StatusType
{
    Created,          // заказ только что создан
    AwaitingPayment,  // ожидает оплаты
    Paid,             // оплачен
    AwaitingShipment, // готов к отправке
    Shipped,          // отправлен
    InTransit,        // в пути к клиенту
    OutForDelivery,   // курьер доставляет
    Delivered,        // доставлен клиенту
    Completed,        // заказ завершён (опционально, после подтверждения)
    Cancelled,        // отменён
    Returned,         // возвращён
    Refunded          // деньги возвращены
}