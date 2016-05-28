using System;
using SolidPrinciplesRefactored.Hardware.Api;
using SolidPrinciplesRefactored.Model;
using SolidPrinciplesRefactored.Utilities;

namespace SolidPrinciplesRefactored.Services
{
    public class PrintService : IPrintService
    {
        readonly HpPrinter printer = new HpPrinter();
        
        public void PrintReceipt(Order order)
        {
            var receipt = new Receipt
            {
                Title = "Receipt for your order placed on " + DateTime.Now,
                Body = "Your order details: \n "
            };
            foreach (var orderItem in order.Items)
            {
                receipt.Body += orderItem.Quantity + " of item " + orderItem.ItemId;
            }

            try
            {
                printer.Print(receipt);
            }
            catch (Exception ex)
            {
                Logger.Error("Problem sending to printer", ex);
            }
        }
    }
}
