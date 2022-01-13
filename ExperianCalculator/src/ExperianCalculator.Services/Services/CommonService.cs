namespace ExperianCalculator.Services
{
    using ExperianCalculator.Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CommonService : ICommonService
    {
        public string JoinDenominationsToString(List<string> denominations)
        {
            return String.Join(Environment.NewLine, denominations.GroupBy(x => x).Select(x => String.Format("{0}x{1}", x.Count(), x.Key)));
        }
    }
}
