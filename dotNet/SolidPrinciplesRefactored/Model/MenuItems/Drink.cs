using System;

namespace SolidPrinciplesRefactored.Model.MenuItems
{
    public class Drink : MenuItem
    {
        public override void GetPrerequisites()
        {
            throw new NotImplementedException();
        }

        public override void Prepare()
        {
            throw new NotImplementedException();
        }

        public override void SendToService()
        {
            //Sending a new coca-cola to client.
        }
    }
}
