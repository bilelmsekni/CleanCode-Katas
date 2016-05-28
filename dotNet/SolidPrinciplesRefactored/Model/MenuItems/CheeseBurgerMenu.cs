using System.Collections.Generic;

namespace SolidPrinciplesRefactored.Model.MenuItems
{
    public class CheeseBurgerMenu : CheeseBurger
    {
        private Drink drink;
        public List<MenuItem> CheeseBurgerMenuItems { get; set; }

        protected override void GetPrerequisites()
        {
            base.GetPrerequisites();
            drink = new Drink();
            CheeseBurgerMenuItems = new List<MenuItem>(2);
        }

        protected override void Prepare()
        {
            base.Prepare();            
            CheeseBurgerMenuItems.Add(drink.SendToService());
        }

        public override MenuItem SendToService()
        {
            GetPrerequisites();
            Prepare();
            CheeseBurgerMenuItems.Add(base.SendToService());
            return this;
        }
    }
}
