using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Matsu.CoreSample.Web.Settings
{
    public enum DependencyInjectionTypes
    {
        Stub,
        Production
    }

    public static class DependencyInjectionTypesExtensions
    {
        public static bool IsProduction(this DependencyInjectionTypes target)
        {
            if (target == DependencyInjectionTypes.Production)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
