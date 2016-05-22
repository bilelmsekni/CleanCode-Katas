using SolidPrinciplesRefactored.Model;
using SolidPrinciplesRefactored.Services;

namespace SolidPrinciplesRefactored
{
    public class Restaurant
    {
        private ICalculatorService calculatorService;
        private IPaymentService paymentService;
        private ICookingService cookingService;
        private IPrintService printService;


        public Restaurant(ICalculatorService calculatorService, IPaymentService paymentService, ICookingService cookingService, IPrintService printService)
        {
            this.calculatorService = calculatorService;
            this.paymentService = paymentService;
            this.cookingService = cookingService;
            this.printService = printService;
        }

        public void ExecuteOrder(Order order, PaymentDetails paymentDetails, bool printReceipt)
        {
            order.TotalAmount = calculatorService.CalculateOrderAmount(order.Items);
            paymentService.Charge(paymentDetails, order.TotalAmount);
            cookingService.Prepare(order);
            if (printReceipt) printService.PrintReceipt(order);
        }        
    }
}
