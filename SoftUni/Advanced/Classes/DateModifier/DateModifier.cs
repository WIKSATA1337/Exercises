using System;

namespace DateModifier
{
    public class DateModifier
    {
        public int Difference(DateTime one, DateTime two)
        {
            var result = one.Date - two.Date;

            if (result.Days < 0)
            {
                return result.Days * -1;
            }
            else
            {
                return result.Days * 1;
            }
        }
    }
}
