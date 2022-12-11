using System;

namespace Exam.DeliveriesManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DeliveriesManager dm = new DeliveriesManager();
            var result = dm.GetDeliverersOrderedByCountOfPackagesThenByName();
        }
    }
}
