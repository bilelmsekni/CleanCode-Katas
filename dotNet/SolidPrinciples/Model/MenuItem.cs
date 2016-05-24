using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.Model
{
    public class MenuItem
    {
        public virtual void GetPrerequisites()
        {
            //Getting Stuff
        }

        public virtual void Prepare()
        {
            //Preparing
        }

        public virtual void SendToService()
        {
            //Send to service
        }
    }
}
