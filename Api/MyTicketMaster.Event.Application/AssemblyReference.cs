﻿using System.Reflection;

namespace MyTicketMaster.Event.Application
{
    public static class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
