namespace StudioSnap
{
    public class NullLogger : ISimpleLogger
    {
        public void Info(string formatString, params object[] args)
        {
        }

        public void Error(string formatString, params object[] args)
        {
        }
    }
}