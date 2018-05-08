using System;

namespace NLayerApp.DAL.EF.Exceptions
{
    internal static class ExceptionWrapper
    {
        public static Exception Wrap(Exception exception)
        {
            return new DalEFException(exception.Message, exception);
        }

        public static void WrapCall(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                throw Wrap(ex);
            }
        }

        public static T WrapCall<T>(Func<T> action)
        {
            try
            {
                return action();
            }
            catch (Exception ex)
            {
                throw Wrap(ex);
            }
        }
    }
}
