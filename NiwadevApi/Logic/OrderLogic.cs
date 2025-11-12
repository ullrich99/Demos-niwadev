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
        public static string ValidateOrder(NiwadevApiContext context, Order orderToValidate)
        {
            try
            {
                if (orderToValidate == null)
                {
                    return "Missing Order";
                }
                
                if (!InputLogic.CheckName(orderToValidate.CustomerName)) 
                return "Name not compliant";
                if (!InputLogic.CheckZipCode(orderToValidate.CustomerZipCode))
                    return "Zipcode not compliant";
                if(!InputLogic.CheckPlace(orderToValidate.CustomerCity))
                    return "Cityname not compliant";
                if(!InputLogic.CheckAddress(orderToValidate.CustomerAddress))
                    return "Street not compliant";
                if (!ProductExists(context, orderToValidate.ProductID))
                    return "Product doesnt exist";
                return "OK";
            }
            catch (Exception ex)
            {
                return "Error";
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
