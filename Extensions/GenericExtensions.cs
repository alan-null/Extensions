using System;

namespace Extensions
{
    public static class GenericExtensions
    {
        public static TOut SafeGet<TOut, TIn>(this TIn obj, Func<TIn, TOut> func)
        {
            if (obj != null)
            {
                try
                {
                    return func(obj);
                }
                catch
                {
                    // ignored
                }
            }
            return default(TOut);
        }
    }
}
