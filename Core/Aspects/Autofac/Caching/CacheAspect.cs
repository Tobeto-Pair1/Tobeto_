using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace Core.Aspects.Autofac.Caching;

/// <summary>
/// CacheAspect
/// </summary>
public class CacheAspect : MethodInterception
{
    private readonly int _duration;
    private readonly ICacheManager _cacheManager;

    public CacheAspect(int duration = 60)
    {
        _duration = duration;
        _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
    }

    public override void Intercept(IInvocation invocation)
    {
        var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
        var arguments = invocation.Arguments;
        var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
        if (_cacheManager.IsAdd(key))
        {
            invocation.ReturnValue = _cacheManager.Get(key);
            return;
        }
        invocation.Proceed();
        _cacheManager.Add(key, invocation.ReturnValue, _duration);
    }


    string BuildKey(object[] args)
    {
        var sb = new StringBuilder();
        foreach (var arg in args)
        {
            var paramValues = arg.GetType().GetProperties()
                .Select(p => p.GetValue(arg)?.ToString() ?? string.Empty);
            sb.Append(string.Join('_', paramValues));
        }

        return sb.ToString();
    }
}
