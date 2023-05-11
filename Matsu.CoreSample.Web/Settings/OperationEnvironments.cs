namespace Matsu.CoreSample.Web.Settings
{
    public enum OperationEnvironments
    {
        Local,
        Azure
    }

    public static class OperationEnvironmentsExtensions
    {
        public static bool IsAzure(this OperationEnvironments target)
        {
            if (target == OperationEnvironments.Azure)
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
