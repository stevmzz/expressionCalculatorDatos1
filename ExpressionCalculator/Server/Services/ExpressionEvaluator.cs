using ExpressionCalculator.Server.Models;

namespace ExpressionCalculator.Server.Services
{
    public class ExpressionEvaluator
    {
        private readonly ExpressionTree _expressionTree;

        public ExpressionEvaluator()
        {
            _expressionTree = new ExpressionTree();
        }
    }
}