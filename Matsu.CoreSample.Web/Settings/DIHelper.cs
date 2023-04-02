namespace Matsu.CoreSample.Web.Settings
{
    public static class DIHelper
    {
        internal static DependencyInjectionTypes GetInjectionType(string injectionType)
        {
            DependencyInjectionTypes dependency;
            if (injectionType == null || !Enum.TryParse(injectionType, out dependency))
            {
                dependency = DependencyInjectionTypes.Production;
            }
            else
            {
                dependency = Enum.Parse<DependencyInjectionTypes>(injectionType);
            }
            return dependency;
        }
    }
}
