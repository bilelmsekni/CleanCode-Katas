using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.Model.MenuItems
{
    public class CheeseBurger : MenuItem
    {
        public override void GetPrerequisites()
        {
            //Get Bread
            //Get Ham
            //Get Salad
            //Get Fries
        }

        public override void Prepare()
        {
            //Do some magic
        }

        public override void SendToService()
        {
            //Send Burger to client
        }
    }
}
