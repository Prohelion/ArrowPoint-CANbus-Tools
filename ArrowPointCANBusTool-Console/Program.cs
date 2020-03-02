using ArrowPointCANBusTool.Services;
using System;

namespace ArrowPointCANBusTool_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CanRecordReplayDebugService rbs = CanRecordReplayDebugService.NewInstance;
        }
    }
}
