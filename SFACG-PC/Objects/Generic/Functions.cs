using System;
using System.Threading.Tasks;

namespace SFACGPC.Objects.Generic {
    public static class Functions {
        public static T Apply<T>(this T receiver, Action<T> action) {
            action(receiver);
            return receiver;
        }

        public static Task AwaitAsync<T>(this T obj, Func<T, Task<bool>> on, int interval = 0,
                                         TimeSpan timeout = default) {
            var timer = DateTime.Now;
            return Task.Run(async () => {
                while (!await on(obj)) {
                    if (timeout != default && DateTime.Now - timer >= timeout) break;
                    if (interval != 0) await Task.Delay(interval);
                }
            });
        }
    }
}
