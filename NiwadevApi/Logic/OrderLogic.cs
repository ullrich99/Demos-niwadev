using Microsoft.EntityFrameworkCore;
using NiwadevApi.Data;
using NiwadevApi.Models;

namespace NiwadevApi.Logic
{
    public static class OrderLogic
    {
        public static bool ProductExists(NiwadevApiContext context, int productID)
        {
            try
            {
                return context.Products.Any(a => a.Id == productID);
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public static bool ValidateOrder(NiwadevApiContext context, Order orderToValidate)
        {
            try
            {
                if (orderToValidate == null)
                {
                    return false;
                }
                if (!ProductExists(context, orderToValidate.ProductID))
                    return false;
                if (!InputLogic.CheckName(orderToValidate.CustomerName)) 
                return false;
                if (!InputLogic.CheckZipCode(orderToValidate.CustomerZipCode))
                    return false;
                if(!InputLogic.CheckPlace(orderToValidate.CustomerZipCode))
                    return false;
                if(!InputLogic.CheckAddress(orderToValidate.CustomerAddress))
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
        public static float CalculatePrice(Order order)
        {
            try
            {
                if(order != null && order.Product != null)
                {
                    float consumtionPerMonth = order.Consumption /12;
                    float consumtionPrice = consumtionPerMonth * order.Product.PricePerKwh;
                    float totalPricePerMonth = consumtionPrice + order.Product.BasePrice;
                    return totalPricePerMonth;
                }
                return 0;
            }
            catch (Exception ex) 
            {
                return 0;
            }
        }
        
    }
}
