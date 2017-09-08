using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Reflection;
using System.Linq.Expressions;
using System.Configuration;

namespace ADMIN2.Controls
{
    public static class ExpressionBuilder 
    {
        private static MethodInfo containsMethod = typeof(string).GetMethod("Contains");
        private static MethodInfo indexOfMethod = typeof(string).GetMethod("IndexOf", new[] { typeof(string), typeof(StringComparison) });
        private static MethodInfo startsWithMethod =
        typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) });
        private static MethodInfo endsWithMethod =
        typeof(string).GetMethod("EndsWith", new Type[] { typeof(string) });


        private static System.Linq.Expressions.Expression CreateLike<T>(ParameterExpression param,
            PropertyInfo prop,
            string value,
            StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            var propertyAccess = System.Linq.Expressions.Expression.MakeMemberAccess(param, prop);

            var indexOf = System.Linq.Expressions.Expression.Call(propertyAccess, "IndexOf", null,
                System.Linq.Expressions.Expression.Constant(value, typeof(string)),
                System.Linq.Expressions.Expression.Constant(comparison));
            
            var like = System.Linq.Expressions.Expression.GreaterThanOrEqual(indexOf, System.Linq.Expressions.Expression.Constant(0));
            return like;
            
        }

        public static Expression<Func<T, bool>> GetExpression<T>(IList<Filter> filters)
        {
            if (filters.Count == 0)
                return null;

            ParameterExpression param = System.Linq.Expressions.Expression.Parameter(typeof(T), "t");
            Type propertyType = null;
            System.Linq.Expressions.Expression exp = null;

            if (filters.Count == 1)
            {
                try
                {
                    //if()
                    propertyType = typeof(T).GetProperty(filters[0].PropertyName).PropertyType;
                    //propertyType= typeof(T).GetProperty(string).PropertyType;
                }
                catch (Exception ex)
                {
                    string errmsg = ex.Message;
                }
                //return CreateLike<T>(param, typeof(T).GetProperty(filters[0].PropertyName), filters[0].Value.ToString(), StringComparison.OrdinalIgnoreCase);
                exp = GetExpression<T>(param, filters[0], propertyType);
            }
            else if (filters.Count == 2)
                exp = GetExpression<T>(param, filters[0], filters[1], propertyType);
            else
            {
                while (filters.Count > 0)
                {
                    var f1 = filters[0];
                    var f2 = filters[1];

                    if (exp == null)
                        exp = GetExpression<T>(param, filters[0], filters[1], propertyType);
                    else
                        exp = System.Linq.Expressions.Expression.AndAlso(exp, GetExpression<T>(param, filters[0], filters[1], propertyType));

                    filters.Remove(f1);
                    filters.Remove(f2);

                    if (filters.Count == 1)
                    {
                        exp = System.Linq.Expressions.Expression.AndAlso(exp, GetExpression<T>(param, filters[0], propertyType));
                        filters.RemoveAt(0);
                    }
                }
            }

            return System.Linq.Expressions.Expression.Lambda<Func<T, bool>>(exp, param);
        }

        private static System.Linq.Expressions.Expression GetExpression<T>(ParameterExpression param, Filter filter, Type propertyType)
        {
            MemberExpression member = System.Linq.Expressions.Expression.Property(param, filter.PropertyName);

            ConstantExpression constant = null;

            switch (filter.Operation)
            {
                case Op.Equals:
                    constant = System.Linq.Expressions.Expression.Constant(Convert.ChangeType(filter.Value, propertyType), propertyType);
                    return System.Linq.Expressions.Expression.Equal(member, constant);

                case Op.GreaterThan:
                    return System.Linq.Expressions.Expression.GreaterThan(member, constant);

                case Op.GreaterThanOrEqual:
                    return System.Linq.Expressions.Expression.GreaterThanOrEqual(member, constant);

                case Op.LessThan:
                    return System.Linq.Expressions.Expression.LessThan(member, constant);

                case Op.LessThanOrEqual:
                    return System.Linq.Expressions.Expression.LessThanOrEqual(member, constant);

                case Op.Contains:
                    if (propertyType.Equals(typeof(int)) || propertyType.Equals(typeof(decimal)) || propertyType.Equals(typeof(double)) || propertyType.Equals(typeof(DateTime)))
                    {
                        if (filter.Value.ToString() == DateTime.MinValue.ToString())
                        {
                            constant = System.Linq.Expressions.Expression.Constant(Convert.ChangeType(filter.Value, propertyType), propertyType);
                            return System.Linq.Expressions.Expression.GreaterThanOrEqual(member, constant);
                        }
                        else if (filter.Value.ToString() != string.Empty)
                        {
                                constant = System.Linq.Expressions.Expression.Constant(Convert.ChangeType(filter.Value, propertyType), propertyType);
                                return System.Linq.Expressions.Expression.Equal(member, constant);
                        }
                        else
                        {
                            constant = System.Linq.Expressions.Expression.Constant(Convert.ChangeType(0, propertyType), propertyType);
                            return System.Linq.Expressions.Expression.GreaterThanOrEqual(member, constant);
                        }
                    }
                    else
                    {
                        return CreateLike<T>(param, typeof(T).GetProperty(filter.PropertyName), filter.Value.ToString(), StringComparison.OrdinalIgnoreCase);
                    }
                case Op.StartsWith:
                    return System.Linq.Expressions.Expression.Call(member, startsWithMethod, constant);

                case Op.EndsWith:
                    return System.Linq.Expressions.Expression.Call(member, endsWithMethod, constant);
            }

            return null;
        }

        private static BinaryExpression GetExpression<T>
        (ParameterExpression param, Filter filter1, Filter filter2, Type propertyType)
        {
            System.Linq.Expressions.Expression bin1 = GetExpression<T>(param, filter1, propertyType);
            System.Linq.Expressions.Expression bin2 = GetExpression<T>(param, filter2, propertyType);

            return System.Linq.Expressions.Expression.AndAlso(bin1, bin2);
        }
    }

    public class Filter
    {
        public string PropertyName { get; set; }
        public Op Operation { get; set; }
        public object Value { get; set; }
    }

    //public class ComboFilter
    //{
    //    public string PropertyName { get; set; }
    //    public string PropertyValue { get; set; }
    //    public object Collection { get; set; }
    //}

    public class Columna
    {
        private int _size = 70;
        private bool _sort = true;

        public string Name { get; set; }
        public string Binding { get; set; }
        public bool Resize { get; set; }

        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public bool Sort
        {
            get { return _sort; }
            set { _sort = value; }
        }
    }

    public enum Op
    {
        Equals,
        GreaterThan,
        LessThan,
        GreaterThanOrEqual,
        LessThanOrEqual,
        Contains,
        StartsWith,
        EndsWith
    }
}
