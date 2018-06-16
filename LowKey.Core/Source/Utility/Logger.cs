using System;
using System.IO;

namespace LowKey.Core.Source.Utility {
  public static class Logger {
    public static void Log(string content) {
      File.AppendAllText("runlog.log", Environment.NewLine + DateTime.Now + Environment.NewLine + content);
    }
  }
}
