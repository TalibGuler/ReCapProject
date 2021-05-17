using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Utilities.Business
{
    public static class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            return logics.FirstOrDefault(logic => !logic.Success);
        }
    }
}
