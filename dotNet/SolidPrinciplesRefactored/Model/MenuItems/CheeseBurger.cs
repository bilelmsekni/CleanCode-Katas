using System.Collections.Generic;

namespace SolidPrinciplesRefactored.Model.MenuItems
{
    public class CheeseBurger : MenuItem
    {
        private readonly List<string> ingredients = new List<string>();

        protected virtual void GetPrerequisites()
        {
            ingredients.Add("Bread");
            ingredients.Add("Ham");
            ingredients.Add("Salad");
            ingredients.Add("Fries");            
        }

        protected virtual void Prepare()
        {
            TransformToBurger(ingredients);
        }

        private void TransformToBurger(List<string> ingredientsList)
        {
            //Do some magic
        }

        public override MenuItem SendToService()
        {
            GetPrerequisites();
            Prepare();
            return base.SendToService();
        }
    }
}
