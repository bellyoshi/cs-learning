using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;
using Reactive.Bindings;

namespace WinFormsApp2
{
    public static class Binder
    {
        static Tuple<object?, string> ResolveLambda<V>(Expression<Func<V>> expression)
        {
            if (expression is not LambdaExpression lambda)
            {
                throw new ArgumentException(nameof(lambda));
            }
            if (lambda.Body is not MemberExpression property)
            {
                throw new ArgumentException(nameof(lambda));
            }
            var parent = property.Expression??throw new ArgumentException(nameof(lambda));
            return new Tuple<object?, string>(Expression.Lambda(parent).Compile().DynamicInvoke(), property.Member.Name);
        }

        public static void Bind<T, U>(Expression<Func<T>> item1, Expression<Func<U>> item2)
        {

            var tuple1 = ResolveLambda(item1);
            var tuple2 = ResolveLambda(item2);
            if (tuple1.Item1 is not Control control)
            {
                throw new Exception(nameof(item1));
            }
            control.DataBindings.Add(new Binding(tuple1.Item2, tuple2.Item1, tuple2.Item2));
        }

        public static void Bind<T>(this Label label, Expression<Func<T>> expression)
        {
            Bind(() => label.Text, expression);
        }

        public static void Bind(this Button button, ReactiveCommand command)
        {
            command.CanExecuteChanged += (sender, args) => button.Enabled = command.CanExecute();
            button.Enabled = command.CanExecute();
            button.Click += (sender, args) => command.Execute();
        }
    }
}
