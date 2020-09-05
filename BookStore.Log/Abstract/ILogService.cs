using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Log.Abstract
{
    public interface ILogService
    {
        void LogInfo(string message);
        void LogInfo(Exception exception, string message);
        void LogError(string message);
        void LogError(Exception exception, string message);
        void LogWarning(string message);
        void LogWarning(Exception exception, string message);

    }
}
