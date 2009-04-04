namespace StudioSnap
{
    public enum SimpleLogLevel
    {
        Verbose,
        Error
    }

    public interface ISimpleLogger
    {
        void Info(string formatString, params object[] args);
        void Error(string formatString, params object[] args);
    }
}