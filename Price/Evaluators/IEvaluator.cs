using System.Collections.Generic;

namespace Price.Evaluators
{
    interface IEvaluator
    {
        double Evaluate(IList<Model.Product> products);
    }
}
