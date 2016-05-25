namespace SolidPrinciplesRefactored.Model.MenuItems
{
    public class CheeseBurger : MenuItem
    {
        public virtual void GetPrerequisites()
        {
            //Get Bread
            //Get Ham
            //Get Salad
            //Get Fries       
        }

        public virtual void Prepare()
        {
            //Do some magic
        }

        public override void SendToService()
        {
            GetPrerequisites();
            Prepare();
            // Send menu to customer
        }
    }
}
