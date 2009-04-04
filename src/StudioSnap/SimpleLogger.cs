using System;

namespace StudioSnap
{
    public class SimpleLogger : ISimpleLogger
    {
        private readonly SimpleLogLevel _logLevel;

        public SimpleLogger(SimpleLogLevel logLevel)
        {
            _logLevel = logLevel;
        }

        public void Info(string formatString, params object[] args)
        {
            if (_logLevel == SimpleLogLevel.Verbose)
                Console.WriteLine(formatString, args);
        }

        public void Error(string formatString, params object[] args)
        {
            Console.WriteLine(formatString, args);
        }
    }
}