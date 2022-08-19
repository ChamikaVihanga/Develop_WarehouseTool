

namespace auth.workspace.Server.Authorization.DataProviders
{
    public class EmpNumberOfYears : IEmpNumberOfYears
    {
        public int GetXP(string Name)
        {
            if (Name == "lkittrainee01")
            {
                return 3;
            }
       
            return 1;
        }
    }
}
