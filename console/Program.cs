using ManyConsole;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SchemaZen.console
{
		internal static class Program
		{
				private static int Main(string[] arguments)
				{
						try
						{
								return ConsoleCommandDispatcher.DispatchCommand(GetCommands(), arguments, Console.Out);
						}
						catch (Exception exception)
						{
								Console.WriteLine(exception.Message);
								Console.WriteLine(exception.StackTrace);
								return -1;
						}
						finally
						{
#if DEBUG
								if (Debugger.IsAttached)
								{
										ConsoleQuestion.WaitForKeyPress();
								}
#endif
						}
				}

				private static IEnumerable<ConsoleCommand> GetCommands()
				{
						return new List<ConsoleCommand> { new Script(), new Create(), new Compare() };
				}
		}
}
