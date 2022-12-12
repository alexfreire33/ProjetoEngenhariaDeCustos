using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace bcquant.Util.Expressions
{
    public class ParameterRebinder : ExpressionVisitor
    {

        #region Variaveis
        private readonly Dictionary<ParameterExpression, ParameterExpression> map;
        #endregion

        #region Construtor
        public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }
        #endregion

        #region ReplaceParameters
        /// <summary>
        /// Substitui parametros de expressões
        /// </summary>
        /// <param name="map">Map dos parametros</param>
        /// <param name="expressao">Expressão que irá receber os parametros</param>
        /// <returns>Expressão</returns>
        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression expressao)
        {
            return new ParameterRebinder(map).Visit(expressao);
        }
        #endregion

        #region VisitParameter
        protected override Expression VisitParameter(ParameterExpression parametros)
        {
            ParameterExpression replacement;
            if (map.TryGetValue(parametros, out replacement))
            {
                parametros = replacement;
            }
            return base.VisitParameter(parametros);
        }
        #endregion

    }
}
