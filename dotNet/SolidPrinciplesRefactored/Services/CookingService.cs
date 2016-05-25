using System.Collections.Generic;
using SolidPrinciplesRefactored.Model;
using SolidPrinciplesRefactored.Model.MenuItems;

namespace SolidPrinciplesRefactored.Services
{
    public class CookingService : ICookingService
    {
        private readonly Dictionary<string, MenuItem> restaurantMenu = new Dictionary<string, MenuItem>
        {
            { Constants.Drink, new Drink()},
            { Constants.CheeseBurger, new CheeseBurger()},
            { Constants.CheeseBurgerMenu, new CheeseBurgerMenu()}
        };

        public void Prepare(Order order)
        {
            foreach (var orderItem in order.Items)
            {
                var menuItem = restaurantMenu[orderItem.ItemId];
                if (menuItem is CheeseBurgerMenu || menuItem is CheeseBurger)
                {
                    for (int i = 0; i < orderItem.Quantity; i++)
                    {
                        menuItem.GetPrerequisites();
                        menuItem.Prepare();
                        menuItem.SendToService();
                    }
                }
                else if (menuItem is Drink)
                {
                    menuItem.SendToService();
                }
            }            
        }
    }
}
