using System;
using System.IO;
using System.Linq;
using StudioSnap.Infrastructure;

namespace StudioSnap
{
    class Program
    {
        public static ISimpleLogger Log { get; set; }

        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    WriteInfoMessage();
                    return;
                }
                var logLevel = args.Any(a => a == "-v") ? SimpleLogLevel.Verbose : SimpleLogLevel.Error;
                Log = new SimpleLogger(logLevel);

                var fileToAdd = Path.GetFullPath(args[0]);
                var projectFileIncluder = new ProjectFileIncluder {Log = Log};
                projectFileIncluder.IncludeFile(fileToAdd);
            }
            catch (Exception e)
            {
                Log.Error("Fatal error: {0}\n{1}", e.Message, e.StackTrace);
            }
        }

        private static void WriteInfoMessage()
        {
            Console.WriteLine(@"Includes a file in a project in a running instance of Visual Studio");
            Console.WriteLine(@"");
            Console.WriteLine(@"Usage:");
            Console.WriteLine(@"  studiosnap file [-v]");
            Console.WriteLine(@"");
            Console.WriteLine(@"  -v Verbose");
            Console.WriteLine(@"");
            Console.WriteLine(@"Example:  ");
            Console.WriteLine(@"  studiosnap src\StudioSnap\NewClass.cs");
        }
    }
}
