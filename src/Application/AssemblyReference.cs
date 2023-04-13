using System.Reflection;

namespace Clean.Architecture.Application
{
    public static class AssemblyReference
    {
        public static Assembly Assembly => typeof(AssemblyReference).Assembly;
    }
}
