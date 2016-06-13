using System.Collections.Generic;

namespace Price.Evaluators
{
    interface IEvaluator
    {
        double Evaluate(IList<Entities.Product> products);
    }
}
