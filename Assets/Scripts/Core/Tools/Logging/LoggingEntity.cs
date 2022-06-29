using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Baraboom.Core.Tools.Logging
{
	public class Logger
	{
		#region facade

		public static Logger For<T>()
		{
			return new Logger(typeof(T));
		}

		[StringFormatMethod("format")]
		public void Log(string format, params object[] args)
		{
			if (!_isLogged)
				return;

			Debug.LogFormat($"{Prefix} {format}", args);
		}

		[StringFormatMethod("format")]
		public void LogWarning(string format, params object[] args)
		{
			if (!_isLogged)
				return;

			Debug.LogWarningFormat($"{Prefix} {format}", args);
		}

		[StringFormatMethod("format")]
		public void LogError(string format, params object[] args)
		{
			if (!_isLogged)
				return;

			Debug.LogErrorFormat($"{Prefix} {format}", args);
		}

		#endregion

		#region interior

		private readonly string _hostTypeName;
		private readonly bool _isLogged;

		private string Prefix
		{
			get
			{
				if (LoggingSettings.Instance.DisplayFrames)
					return $"[{Time.frameCount}] [{_hostTypeName}]";

				return $"[{_hostTypeName}]";
			}
		}

		private Logger(Type hostType)
		{
			_hostTypeName = hostType.FullName;
			_isLogged = LoggingSettings.Instance.ShouldLogEntity(_hostTypeName);
		}

		#endregion
	}
}