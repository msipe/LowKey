using System;
using LowKey.Core.Source.Runner;

namespace LowKey {
  class Program {
    static void Main(string[] args) {
      if (args.Length != 2) {
        Console.WriteLine("Invalid input.");
        Console.WriteLine("First Argument: Artist Name");
        Console.WriteLine("Second Argument: Listener Cutoff");
        return;
      }

      try {
        Run(args[0], args[1]);
      } catch (Exception err) {
        Console.WriteLine(err.Message);
        Console.WriteLine(err.StackTrace);
      }
    }

    static void Run(string artist, string cutoff) {
      var key = "d603efbd297006bc2578f39e32f507dd";
      var config = new Config(artist, int.Parse(cutoff), key);
      var runner = new AppRunner(config);

      runner.Init();
    }
  }
}
