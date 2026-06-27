using System;
using System.IO;
using System.Windows.Forms;

namespace Terraria
{
	internal static class Program
	{
		private static void Main(string[] args)
		{
			TempRealtimeLogger.Info("Program.Main", "BEGIN args=[" + string.Join(", ", args) + "]");
			AppDomain.CurrentDomain.UnhandledException += delegate(object sender, UnhandledExceptionEventArgs e)
			{
				TempRealtimeLogger.Error("AppDomain.UnhandledException", e.ExceptionObject as Exception);
			};
			using (Main main = new Main())
			{
				TempRealtimeLogger.Info("Program.Main", "Main constructed");
				try
				{
					for (int i = 0; i < args.Length; i++)
					{
						if (args[i].ToLower() == "-port" || args[i].ToLower() == "-p")
						{
							i++;
							try
							{
								int serverPort = Convert.ToInt32(args[i]);
								Netplay.serverPort = serverPort;
							}
							catch
							{
							}
						}
						if (args[i].ToLower() == "-join" || args[i].ToLower() == "-j")
						{
							i++;
							try
							{
								main.AutoJoin(args[i]);
							}
							catch
							{
							}
						}
						if (args[i].ToLower() == "-pass" || args[i].ToLower() == "-password")
						{
							i++;
							Netplay.password = args[i];
							main.AutoPass();
						}
						if (args[i].ToLower() == "-host")
						{
							main.AutoHost();
						}
						if (args[i].ToLower() == "-loadlib")
						{
							i++;
							string path = args[i];
							main.loadLib(path);
						}
					}
					Steam.Init();
					TempRealtimeLogger.Info("Program.Main", "After Steam.Init SteamInit=" + Steam.SteamInit);
					if (Steam.SteamInit)
					{
						TempRealtimeLogger.Info("Program.Main", "Before main.Run");
						main.Run();
						TempRealtimeLogger.Info("Program.Main", "After main.Run");
					}
					else
					{
						TempRealtimeLogger.Info("Program.Main", "Steam not initialized, showing error");
						MessageBox.Show("Please launch the game from your Steam client.", "Error");
					}
				}
				catch (Exception ex)
				{
					TempRealtimeLogger.Error("Program.Main", ex);
					try
					{
						using (StreamWriter streamWriter = new StreamWriter("client-crashlog.txt", true))
						{
							streamWriter.WriteLine(DateTime.Now);
							streamWriter.WriteLine(ex);
							streamWriter.WriteLine("");
						}
						MessageBox.Show(ex.ToString(), "Terraria: Error");
					}
					catch
					{
					}
				}
			}
			TempRealtimeLogger.Info("Program.Main", "END");
		}
	}
}
