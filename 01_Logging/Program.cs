using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System;



namespace _01_Logging
{
    class Program
    {
        static void Main(string[] args)
        {
            ///模拟startup实例一个ServiceCollection 
            ServiceCollection services = new ServiceCollection();
            services.AddLogging(
                logBuilder=>
                {
                    logBuilder.AddConsole();
                    logBuilder.AddNLog();
                    logBuilder.SetMinimumLevel(LogLevel.Trace);
                }
                );
            //注册服务
            services.AddScoped<SystemService>();
            //通过服务构建容器，ServiceProvider类型
            using (var sp = services.BuildServiceProvider())
            { ///获取容器中的服务ITestService
                var test2 = sp.GetRequiredService<SystemService>();
                for (int i = 1; i <= 1000; i++)
                {

                    test2.Logging();
                }
              
            }
        }
    }
}
