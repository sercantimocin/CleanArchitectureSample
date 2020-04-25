using System;
using System.Threading.Tasks;

namespace Infrastucture.Persistance
{
    public class Disposable
    {
        public static TResult Using<TDisposable, TResult>(Func<TDisposable> factory, Func<TDisposable, TResult> map) where TDisposable : IDisposable
        {
            using (var disposable = factory())
            {
                return map(disposable);
            }
        }
        public static async Task<TResult> UsingAsync<TDisposable, TResult>(Func<TDisposable> factory, Func<TDisposable, Task<TResult>> map) where TDisposable : IDisposable
        {
            using (var disposable = factory())
            {
                return await map(disposable);
            }
        }
    }
}
