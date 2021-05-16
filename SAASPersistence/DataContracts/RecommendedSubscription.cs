using System;
using System.Collections.Generic;
using System.Text;

namespace SAASPersistence.DataContracts
{
    public class RecommendedSubscription
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal MonthlyPrice { get; set; }
        public decimal YearlyPrice { get; set; }
        public decimal MonthlyPriceWithVat { get; set; }
        public decimal YearlyPriceWithVat { get; set; }
    }
}
