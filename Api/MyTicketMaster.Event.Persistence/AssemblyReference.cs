using System.Reflection;

namespace MyTicketMaster.Event.Persistence
{
    public static class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
