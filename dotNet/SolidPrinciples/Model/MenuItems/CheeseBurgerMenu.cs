using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.Model.MenuItems
{
    public class CheeseBurgerMenu : MenuItem
    {
        public override void GetPrerequisites()
        {
            //Get Bread
            //Get Ham
            //Get Salad
            //Get Fries
            //Get Drink
        }

        public override void Prepare()
        {
            //Do some magic
        }

        public override void SendToService()
        {
            // Send menu to customer
        }
    }
}
