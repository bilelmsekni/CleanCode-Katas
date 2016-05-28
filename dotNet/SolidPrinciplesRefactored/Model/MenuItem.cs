namespace SolidPrinciplesRefactored.Model
{
    public class MenuItem
    {
        public virtual MenuItem SendToService()
        {
            return this;
        }
    }
}
