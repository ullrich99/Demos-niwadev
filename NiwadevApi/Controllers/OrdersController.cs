using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NiwadevApi.Data;
using NiwadevApi.Logic;
using NiwadevApi.Models;

namespace NiwadevApi.Controllers
{
    [ApiController]
    [Route("Orders")]
    public class OrdersController : Controller
    {
        private readonly NiwadevApiContext _context;
     
        public OrdersController(NiwadevApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("/GetOrders")]
        public IEnumerable<Order> GetOrder()
        {
            try
            {
                return _context.Orders.Include(i=> i.Product).ToList();
            }
            catch(Exception ex) 
            {
                //log
                return Enumerable.Empty<Order>();
            }
        }
        [HttpPost]
        [Route("/CreateOrder")]
        public string CreateNewOrder([FromBody] Order newOrder)
        {
            try
            {
                string validationMessage = OrderLogic.ValidateOrder(_context, newOrder);
                if (validationMessage == "OK")
                {
                    newOrder.Product = _context.Products.FirstOrDefault(w => w.Id == newOrder.ProductID);
                    float price = OrderLogic.CalculatePrice(newOrder);
                    if (price != 0)
                    {
                        newOrder.TotalPrice = price;
                        _context.Orders.Add(newOrder);
                        _context.SaveChanges();
                        return validationMessage;
                    }
                    else
                    {
                        return "Price calculation Error";
                    }
                }
                return validationMessage;
            }
            catch(Exception ex)
            {
                //log
                return "Error";
            }
        }


    }
}
