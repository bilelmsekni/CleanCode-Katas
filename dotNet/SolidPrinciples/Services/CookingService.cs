using System.Collections.Generic;
using SolidPrinciples.Model;
using SolidPrinciples.Model.MenuItems;

namespace SolidPrinciples.Services
{
    public class CookingService
    {
        private readonly Dictionary<string, MenuItem> restaurantMenu = new Dictionary<string, MenuItem>
        {
            { Constants.Drink, new Drink()},
            { Constants.CheeseBurger, new CheeseBurger()},
            { Constants.CheeseBurgerMenu, new CheeseBurgerMenu()}
        };

        public void Prepare(string itemId, int quantity)
        {
            var menuItem = restaurantMenu[itemId];
            if (menuItem is CheeseBurgerMenu || menuItem is CheeseBurger)
            {
                for (int i = 0; i < quantity; i++)
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