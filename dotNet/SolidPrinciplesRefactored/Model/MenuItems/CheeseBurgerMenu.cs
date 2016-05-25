namespace SolidPrinciplesRefactored.Model.MenuItems
{
    public class CheeseBurgerMenu : CheeseBurger
    {
        public override void GetPrerequisites()
        {
            base.GetPrerequisites();
            var drink = new Drink();
            //Get Drink
        }
    }
}
