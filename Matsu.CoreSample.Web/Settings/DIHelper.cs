namespace Matsu.CoreSample.Web.Settings
{
    public static class DIHelper
    {
        internal static DependencyInjectionTypes GetServiceInjectionType(string injectionType)
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

        internal static OperationEnvironments GetLoggerInjectionType(string injectionType)
        {
            OperationEnvironments dependency;
            if (injectionType == null || !Enum.TryParse(injectionType, out dependency))
            {
                dependency = OperationEnvironments.Azure;
            }
            else
            {
                dependency = Enum.Parse<OperationEnvironments>(injectionType);
            }
            return dependency;
        }
    }
}
