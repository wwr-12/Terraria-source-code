using System;
using System.Collections.Generic;
using System.Globalization;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ReLogic.IO;
using ReLogic.OS;
using Terraria.Initializers;
using Terraria.Localization;
using Terraria.Social;
using Terraria.Utilities;

namespace Terraria
{
	public static class Program
	{
		public const bool IsServer = false;

		public static Dictionary<string, string> LaunchParameters = new Dictionary<string, string>();

		private static int ThingsToLoad = 0;

		private static int ThingsLoaded = 0;

		public static bool LoadedEverything = false;

		public static IntPtr JitForcedMethodCache;

		public static float LoadedPercentage
		{
			get
			{
				if (ThingsToLoad == 0)
				{
					return 1f;
				}
				return (float)ThingsLoaded / (float)ThingsToLoad;
			}
		}

		public static void StartForceLoad()
		{
			if (!Main.SkipAssemblyLoad)
			{
				ThreadPool.QueueUserWorkItem(ForceLoadThread);
			}
			else
			{
				LoadedEverything = true;
			}
		}

		public static void ForceLoadThread(object ThreadContext)
		{
			ForceLoadAssembly(Assembly.GetExecutingAssembly(), initializeStaticMembers: true);
			LoadedEverything = true;
		}

		private static void ForceJITOnAssembly(Assembly assembly)
		{
			Type[] types = assembly.GetTypes();
			for (int i = 0; i < types.Length; i++)
			{
				MethodInfo[] methods = types[i].GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (MethodInfo methodInfo in methods)
				{
					if (!methodInfo.IsAbstract && !methodInfo.ContainsGenericParameters && methodInfo.GetMethodBody() != null)
					{
						RuntimeHelpers.PrepareMethod(methodInfo.MethodHandle);
					}
				}
				ThingsLoaded++;
			}
		}

		private static void ForceStaticInitializers(Assembly assembly)
		{
			Type[] types = assembly.GetTypes();
			foreach (Type type in types)
			{
				if (!type.IsGenericType)
				{
					RuntimeHelpers.RunClassConstructor(type.TypeHandle);
				}
			}
		}

		private static void ForceLoadAssembly(Assembly assembly, bool initializeStaticMembers)
		{
			ThingsToLoad = assembly.GetTypes().Length;
			ForceJITOnAssembly(assembly);
			if (initializeStaticMembers)
			{
				ForceStaticInitializers(assembly);
			}
		}

		private static void ForceLoadAssembly(string name, bool initializeStaticMembers)
		{
			Assembly assembly = null;
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			for (int i = 0; i < assemblies.Length; i++)
			{
				if (assemblies[i].GetName().Name.Equals(name))
				{
					assembly = assemblies[i];
					break;
				}
			}
			if (assembly == null)
			{
				assembly = Assembly.Load(name);
			}
			ForceLoadAssembly(assembly, initializeStaticMembers);
		}

		private static void SetupLogging()
		{
			bool num = LaunchParameters.ContainsKey("-logfile");
			string text = "";
			if (num)
			{
				text = LaunchParameters["-logfile"];
				text = ((text != null && !(text.Trim() == "")) ? Path.Combine(text, string.Format("Log_{0}.log", DateTime.Now.ToString("yyyyMMddHHmmssfff"))) : Path.Combine(Main.SavePath, "Logs", string.Format("Log_{0}.log", DateTime.Now.ToString("yyyyMMddHHmmssfff"))));
				ConsoleOutputMirror.ToFile(text);
			}
			if (LaunchParameters.ContainsKey("-logerrors"))
			{
				HookAllExceptions();
			}
		}

		private static void HookAllExceptions()
		{
			bool useMiniDumps = LaunchParameters.ContainsKey("-minidump");
			bool useFullDumps = LaunchParameters.ContainsKey("-fulldump");
			Console.WriteLine("Error Logging Enabled.");
			CrashDump.Options dumpOptions = CrashDump.Options.WithFullMemory;
			if (useFullDumps)
			{
				Console.WriteLine("Full Dump logs enabled.");
			}
			AppDomain.CurrentDomain.FirstChanceException += delegate(object sender, FirstChanceExceptionEventArgs exceptionArgs)
			{
				string arg = exceptionArgs.Exception.ToString();
				Console.Write(string.Concat("================\r\n" + $"{DateTime.Now}: First-Chance Exception\r\nCulture: {Thread.CurrentThread.CurrentCulture.Name}\r\nException: {arg}\r\n", "================\r\n\r\n"));
				if (useMiniDumps)
				{
					CrashDump.WriteException(CrashDump.Options.WithIndirectlyReferencedMemory, Path.Combine(Main.SavePath, "Dumps"));
				}
			};
			AppDomain.CurrentDomain.UnhandledException += delegate(object sender, UnhandledExceptionEventArgs exceptionArgs)
			{
				string arg = exceptionArgs.ExceptionObject.ToString();
				Console.Write(string.Concat("================\r\n" + $"{DateTime.Now}: Unhandled Exception\r\nCulture: {Thread.CurrentThread.CurrentCulture.Name}\r\nException: {arg}\r\n", "================\r\n"));
				if (useFullDumps)
				{
					CrashDump.WriteException(dumpOptions, Path.Combine(Main.SavePath, "Dumps"));
				}
			};
		}

		private static void InitializeConsoleOutput()
		{
			if (Debugger.IsAttached)
			{
				return;
			}
			try
			{
				Console.OutputEncoding = Encoding.UTF8;
				if (Platform.IsWindows)
				{
					Console.InputEncoding = Encoding.Unicode;
				}
				else
				{
					Console.InputEncoding = Encoding.UTF8;
				}
			}
			catch
			{
			}
		}

		public static void LaunchGame(string[] args, bool monoArgs = false)
		{
			if (monoArgs)
			{
				args = Utils.ConvertMonoArgsToDotNet(args);
			}
			if (Platform.IsOSX)
			{
				Main.OnEngineLoad += delegate
				{
					Main.instance.IsMouseVisible = false;
				};
			}
			LaunchParameters = Utils.ParseArguements(args);
			ThreadPool.SetMinThreads(8, 8);
			GameCulture startupCulture = GetSystemDefaultCulture();
		LanguageManager.Instance.SetLanguage(startupCulture);
			SetupLogging();
			using (Main main = new Main())
			{
				try
				{
					InitializeConsoleOutput();
					Lang.InitializeLegacyLocalization();
					SocialAPI.Initialize();
					LaunchInitializer.LoadParameters(main);
					Main.OnEnginePreload += StartForceLoad;
					main.Run();
				}
				catch (Exception e)
				{
					DisplayException(e);
				}
			}
		}

		private static void DisplayException(Exception e)
		{
			try
			{
				using (StreamWriter streamWriter = new StreamWriter("client-crashlog.txt", append: true))
				{
					streamWriter.WriteLine(DateTime.Now);
					streamWriter.WriteLine(e);
					streamWriter.WriteLine("");
				}
				MessageBox.Show(e.ToString(), "Terraria: Error");
			}
			catch
			{
			}
		}

		private static GameCulture GetSystemDefaultCulture()
		{
			string name = CultureInfo.CurrentUICulture.Name;
			if (name.StartsWith("zh"))
				return GameCulture.Chinese;
			if (name.StartsWith("de"))
				return GameCulture.German;
			if (name.StartsWith("it"))
				return GameCulture.Italian;
			if (name.StartsWith("fr"))
				return GameCulture.French;
			if (name.StartsWith("es"))
				return GameCulture.Spanish;
			if (name.StartsWith("ru"))
				return GameCulture.Russian;
			if (name.StartsWith("pt"))
				return GameCulture.Portuguese;
			if (name.StartsWith("pl"))
				return GameCulture.Polish;
			return GameCulture.English;
		}
	}
}
