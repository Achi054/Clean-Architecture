﻿using System.Reflection;

namespace Clean.Architecture.Presentation
{
    public static class AssemblyReference
    {
        public static Assembly Assembly => typeof(AssemblyReference).Assembly;
    }
}
