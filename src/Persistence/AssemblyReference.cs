using System.Reflection;

namespace Clean.Architecture.Persistence
{
    public static class AssemblyReference
    {
        public static Assembly Assembly => typeof(AssemblyReference).Assembly;
    }
}
