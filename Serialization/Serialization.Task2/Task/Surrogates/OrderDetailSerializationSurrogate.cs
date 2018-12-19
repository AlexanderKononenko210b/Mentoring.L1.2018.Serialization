using System.Runtime.Serialization;
using Task.DB;
using Task.SerializationContexts;

namespace Task.Surrogates
{
    /// <summary> 
    /// Represents a <see cref="OrderDetailSerializationSurrogate"/> class.
    /// </summary>
    public class OrderDetailSerializationSurrogate : ISerializationSurrogate
    {
        ///<inheritdoc/>
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            var orderDetail = obj as Order_Detail;
            var serializationContext = context.Context as SerializationContext;

            if (serializationContext != null && serializationContext.TypeToSerialize == typeof(Order_Detail))
            {
                serializationContext.ObjectContext.LoadProperty(orderDetail, o => o.Order);
                serializationContext.ObjectContext.LoadProperty(orderDetail, o => o.Product);
            }

            info.AddValue(nameof(orderDetail.OrderID), orderDetail?.OrderID);
            info.AddValue(nameof(orderDetail.ProductID), orderDetail?.ProductID);
            info.AddValue(nameof(orderDetail.UnitPrice), orderDetail?.UnitPrice);
            info.AddValue(nameof(orderDetail.Quantity), orderDetail?.Quantity);
            info.AddValue(nameof(orderDetail.Discount), orderDetail?.Discount);
            info.AddValue(nameof(orderDetail.Order), orderDetail?.Order);
            info.AddValue(nameof(orderDetail.Product), orderDetail?.Product);
        }

        ///<inheritdoc/>
        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            var orderDetail = obj as Order_Detail;

            if (orderDetail != null)
            {
                orderDetail.OrderID = info.GetInt32(nameof(orderDetail.OrderID));
                orderDetail.ProductID = info.GetInt32(nameof(orderDetail.ProductID));
                orderDetail.UnitPrice = info.GetDecimal(nameof(orderDetail.UnitPrice));
                orderDetail.Quantity = info.GetInt16(nameof(orderDetail.Quantity));
                orderDetail.Discount = info.GetSingle(nameof(orderDetail.Discount));
                orderDetail.Order = info.GetValue(nameof(orderDetail.Order), typeof(Order)) as Order;
                orderDetail.Product = info.GetValue(nameof(orderDetail.Product), typeof(Product)) as Product;
            }

            return orderDetail;
        }
    }
}
