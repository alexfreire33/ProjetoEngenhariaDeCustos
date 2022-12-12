using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace bcquant.Util.Expressions
{
    public static class ExpressionHelper
    {

        #region GenerateWhereExpressions
        /// <summary>
        /// Gera uma expressão de comparação para um metodo Where do lambda
        /// </summary>
        /// <param name="parametros">Dictionary com os parametros da consulta</param>
        /// <returns></returns>
        public static Expression<Func<TEntity, bool>> GenerateWhereExpressions<TEntity>(Dictionary<string, string> parametros)
        {
            Expression<Func<TEntity, bool>> retorno = null;

            foreach (var parametro in parametros.Where(p => p.Value != null))
            {
                //Obtém parametro do lambda
                ParameterExpression parameter = Expression.Parameter(typeof(TEntity), "p");

                //Dados da propriedade da entidade
                PropertyInfo keyProperty;

                //Obtém propriedade de consulta da entidade
                MemberExpression property = GenerateProperty<TEntity>(parametro.Key, parameter, out keyProperty);

                //Obtém a expressão de comparação
                Expression<Func<TEntity, bool>> expressao = GenerateWhereExpression<TEntity>(parametro.Key, parametro.Value, parameter, keyProperty, property);

                //Adciona a expressão gerada na expressão de retorno
                if (retorno == null)
                {
                    retorno = expressao;
                }
                else
                {
                    retorno = And(retorno, expressao);
                }
            }

            return retorno;
        }
        #endregion

        #region GenerateWhereExpression
        /// <summary>
        /// Gera uma expressão de comparação para um metodo Where do lambda
        /// </summary>
        /// <param name="nameProperty">Nome da propriedade da Entity</param>
        /// <param name="valueProperty">Valor da propriedade da Entity</param>
        /// <param name="parameter">Parametro do lambda</param>
        /// <param name="keyProperty">Informações da propriedade</param>
        /// <param name="property">Propriedade de consulta da entidade</param>
        /// <returns></returns>
        public static Expression<Func<TEntity, bool>> GenerateWhereExpression<TEntity>(string nameProperty, string valueProperty, ParameterExpression parameter, PropertyInfo keyProperty, MemberExpression property)
        {
            Expression<Func<TEntity, bool>> expressao;

            if (keyProperty.PropertyType == typeof(string))
            {
                //Se a propriedade for string será verificado se o valor é uma substring com o método Contains
                MethodInfo metodo = typeof(string).GetMethod("Contains", new[] { typeof(string) });

                var valor = Expression.Constant(valueProperty, typeof(string));
                var comparador = Expression.Call(property, metodo, valor);

                expressao = Expression.Lambda<Func<TEntity, bool>>(comparador, parameter);
            }
            else if (keyProperty.PropertyType == typeof(DateTime))
            {
                //Se a propriedade for DateTime será feita uma verificação de Maior ou Menor
                var valor = Expression.Constant(Convert.ToDateTime(valueProperty), typeof(DateTime));

                BinaryExpression comparador;
                if (nameProperty.Contains("max"))
                {
                    comparador = Expression.LessThanOrEqual(property, valor);
                }
                else
                {
                    comparador = Expression.GreaterThanOrEqual(property, valor);
                }

                expressao = Expression.Lambda<Func<TEntity, bool>>(comparador, parameter);
            }
            else
            {
                //Qualquer outro tipo terá uma verificação de igualdade
                var valor = Expression.Constant(valueProperty);
                var comparador = Expression.Equal(property, valor);

                expressao = Expression.Lambda<Func<TEntity, bool>>(comparador, parameter);
            }

            return expressao;
        }
        #endregion

        #region GenerateProperty
        /// <summary>
        /// Gera a expressão de propriedades do lambda
        /// </summary>
        /// <param name="nameProperty">Nome da propriedade da Entity</param>
        /// <param name="parameter">Parametro do lambda</param>
        /// <param name="keyProperty">Informações da propriedade</param>
        /// <returns></returns>
        public static MemberExpression GenerateProperty<TEntity>(string nameProperty, ParameterExpression parameter, out PropertyInfo keyProperty)
        {
            MemberExpression property = null;

            if (nameProperty.Contains("_max") || nameProperty.Contains("_min"))
            {
                //Se for data irá definir a propriedade e seu tipo removendo o sufixo
                keyProperty = typeof(TEntity).GetProperty(nameProperty.Split('_')[0]);
                property = Expression.Property(parameter, keyProperty);
            }
            else if (nameProperty.Contains("."))
            {
                Expression body = parameter;

                //Se for uma entity aninhada irá navegar pelos objetos
                string[] objetos = nameProperty.Split('.');

                TEntity e = Activator.CreateInstance<TEntity>();
                //Obtém o tipo da entidade
                PropertyInfo entityType = e.GetType().GetProperty(objetos[0]);

                foreach (string objeto in objetos)
                {
                    if (objeto == objetos[objetos.Length - 1])
                    {
                        property = Expression.PropertyOrField(body, objeto);
                    }
                    else
                    {
                        if (objeto != objetos[0])
                        {
                            var nestedObject = Activator.CreateInstance(entityType.PropertyType);
                            entityType = nestedObject.GetType().GetProperty(objeto);
                        }

                        body = Expression.PropertyOrField(body, objeto);
                    }
                }

                keyProperty = entityType.PropertyType.GetProperty(objetos[objetos.Length - 1]);
            }
            else
            {
                //Em qualuqer outro caso irá definir a propriedade e seu tipo
                keyProperty = typeof(TEntity).GetProperty(nameProperty);
                property = Expression.Property(parameter, keyProperty);
            }

            return property;
        }
        #endregion

        #region Compose
        /// <summary>
        /// Une duas expressões passando um conector
        /// </summary>
        /// <typeparam name="TEntity">Entity da consulta</typeparam>
        /// <param name="primeira">Primeira expressão</param>
        /// <param name="segunda">Segunda Expressão</param>
        /// <param name="conector">Conector das expressões (And, Or...)</param>
        /// <returns>Expressão</returns>
        public static Expression<TEntity> Compose<TEntity>(this Expression<TEntity> primeira, Expression<TEntity> segunda, Func<Expression, Expression, Expression> conector)
        {
            // Mapeador de Parametros (Parametros da segunda expressão para a primeira)
            var map = primeira.Parameters.Select((f, i) => new { f, s = segunda.Parameters[i] }).ToDictionary(p => p.s, p => p.f);

            // Substitui parametros da segunda expressão pelos da primeira
            var secondBody = ParameterRebinder.ReplaceParameters(map, segunda.Body);

            // Junta as duas expressões
            return Expression.Lambda<TEntity>(conector(primeira.Body, secondBody), primeira.Parameters);
        }
        #endregion

        #region And
        /// <summary>
        /// Une duas expressões com um conector And
        /// </summary>
        /// <typeparam name="TEntity">Entity da consulta</typeparam>
        /// <param name="primeira">Primeira expressão</param>
        /// <param name="segunda">Segunda Expressão</param>
        /// <returns>Expressão</returns>
        public static Expression<Func<TEntity, bool>> And<TEntity>(this Expression<Func<TEntity, bool>> primeira, Expression<Func<TEntity, bool>> segunda)
        {
            return primeira.Compose(segunda, Expression.And);
        }
        #endregion

        #region Or
        /// <summary>
        /// Une duas expressões com um conector Or
        /// </summary>
        /// <typeparam name="TEntity">Entity da consulta</typeparam>
        /// <param name="primeira">Primeira expressão</param>
        /// <param name="segunda">Segunda Expressão</param>
        /// <returns>Expressão</returns>
        public static Expression<Func<TEntity, bool>> Or<TEntity>(this Expression<Func<TEntity, bool>> primeira, Expression<Func<TEntity, bool>> segunda)
        {
            return primeira.Compose(segunda, Expression.Or);
        }
        #endregion





    }
}
