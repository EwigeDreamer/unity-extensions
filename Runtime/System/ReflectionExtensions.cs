using System;
using System.Reflection;

namespace ED.Extensions.System
{
    public static class ReflectionExtensions
    {
        public static void InvokeNonPublicMethod(this object instance, string methodName, params object[] parameters)
        {
            if (instance == null) throw new ArgumentNullException(nameof(instance));
            var flags = BindingFlags.NonPublic | BindingFlags.Instance;
            var type = instance.GetType();
            while (type != null)
            {
                var methodInfo = type.GetMethod(methodName, flags);
                if (methodInfo == null)
                {
                    type = type.BaseType;
                    continue;
                }
                methodInfo.Invoke(instance, parameters);
                return;
            }
            throw new ArgumentOutOfRangeException(nameof(methodName));
        }

        public static TResult InvokeNonPublicMethodWithResult<TResult>(this object instance, string methodName, params object[] parameters)
        {
            if (instance == null) throw new ArgumentNullException(nameof(instance));
            var flags = BindingFlags.NonPublic | BindingFlags.Instance;
            var type = instance.GetType();
            while (type != null)
            {
                var methodInfo = type.GetMethod(methodName, flags);
                if (methodInfo == null)
                {
                    type = type.BaseType;
                    continue;
                }
                var methodResult = methodInfo.Invoke(instance, parameters);
                if (methodResult is TResult result) return result;
                throw new InvalidCastException($"{nameof(methodResult)} type mismatch: expected {typeof(TResult).Name}, actual {methodResult.GetType()}");
            }
            throw new ArgumentOutOfRangeException(nameof(methodName));
        }
        
        public static void InvokeNonPublicStaticMethod(Type staticType, string methodName, params object[] parameters)
        {
            if (staticType == null) throw new ArgumentNullException(nameof(staticType));
            var flags = BindingFlags.NonPublic | BindingFlags.Static;
            var methodInfo = staticType.GetMethod(methodName, flags);
            if (methodInfo == null) throw new ArgumentOutOfRangeException(nameof(methodName));
            methodInfo.Invoke(null, parameters);
        }

        public static TResult InvokeNonPublicStaticMethodWithResult<TResult>(Type staticType, string methodName, params object[] parameters)
        {
            if (staticType == null) throw new ArgumentNullException(nameof(staticType));
            var flags = BindingFlags.NonPublic | BindingFlags.Static;
            var methodInfo = staticType.GetMethod(methodName, flags);
            if (methodInfo == null) throw new ArgumentOutOfRangeException(nameof(methodName));
            var methodResult = methodInfo.Invoke(null, parameters);
            if (methodResult is TResult result) return result;
            throw new InvalidCastException($"{nameof(methodResult)} type mismatch: expected {typeof(TResult).Name}, actual {methodResult.GetType()}");
        }
    }
}