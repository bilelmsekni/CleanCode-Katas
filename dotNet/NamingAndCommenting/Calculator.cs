namespace NamingAndCommenting
{    
    public class Calculator
    {
        /// <summary>
        /// Calculate
        /// </summary>
        /// <param name="nb"></param>
        /// <param name="p"></param>
        /// <returns>discount</returns>
        public double Calc(int nb, double p)
        {
            //No discount below 3 articles
            if (nb < 3)
            {
                return 0;
            }
            //Below 10, 3 for 2
            if (nb < 11)
            {
                var t = nb / 3;                
                return t * p;
            }
            //50 percent off for rest
            return nb * p / 2;
        }
    }
}
