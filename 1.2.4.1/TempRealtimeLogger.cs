using System;
using System.IO;
using System.Text;
using System.Threading;

internal static class TempRealtimeLogger
{
	private static readonly object _lock = new object();
	private static StreamWriter _writer;
	private static string _path;
	private static long _sequence;
	private static long _updateFrame;
	private static long _drawFrame;
	private static bool _initialized;

	public static string Path
	{
		get
		{
			EnsureInitialized();
			return _path;
		}
	}

	public static void Info(string area, string message)
	{
		Write("INFO", area, message, null);
	}

	public static void Error(string area, Exception exception)
	{
		Write("ERROR", area, exception == null ? "<null exception>" : exception.Message, exception);
	}

	public static long BeginUpdate()
	{
		long frame = Interlocked.Increment(ref _updateFrame);
		Info("Main.Update", "BEGIN updateFrame=" + frame);
		return frame;
	}

	public static void EndUpdate(long frame)
	{
		Info("Main.Update", "END updateFrame=" + frame);
	}

	public static long BeginDraw()
	{
		long frame = Interlocked.Increment(ref _drawFrame);
		Info("Main.Draw", "BEGIN drawFrame=" + frame);
		return frame;
	}

	public static void EndDraw(long frame)
	{
		Info("Main.Draw", "END drawFrame=" + frame);
	}

	private static void Write(string level, string area, string message, Exception exception)
	{
		try
		{
			EnsureInitialized();
			lock (_lock)
			{
				long sequence = ++_sequence;
				_writer.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
				_writer.Write(" | #");
				_writer.Write(sequence.ToString("00000000"));
				_writer.Write(" | T");
				_writer.Write(Thread.CurrentThread.ManagedThreadId);
				_writer.Write(" | ");
				_writer.Write(level);
				_writer.Write(" | ");
				_writer.Write(area ?? "<null area>");
				_writer.Write(" | ");
				_writer.WriteLine(message ?? "<null message>");
				if (exception != null)
				{
					_writer.WriteLine(exception.ToString());
				}
				_writer.Flush();
			}
		}
		catch
		{
		}
	}

	private static void EnsureInitialized()
	{
		if (_initialized)
		{
			return;
		}
		lock (_lock)
		{
			if (_initialized)
			{
				return;
			}
			string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
			string logDirectory = System.IO.Path.Combine(baseDirectory, "TempRealtimeLogs");
			Directory.CreateDirectory(logDirectory);
			_path = System.IO.Path.Combine(logDirectory, "Realtime_" + DateTime.Now.ToString("yyyyMMdd_HHmmss_fff") + ".log");
			FileStream stream = new FileStream(_path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite, 4096, FileOptions.WriteThrough);
			_writer = new StreamWriter(stream, Encoding.UTF8);
			_writer.AutoFlush = true;
			_initialized = true;
			_writer.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " | #00000000 | T" + Thread.CurrentThread.ManagedThreadId + " | INFO | TempRealtimeLogger | START path=" + _path);
			_writer.Flush();
		}
	}
}
