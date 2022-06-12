using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Baraboom.Game.Tools.Logging
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

			Debug.LogFormat($"[{_hostTypeName}] {format}", args);
		}

		[StringFormatMethod("format")]
		public void LogWarning(string format, params object[] args)
		{
			if (!_isLogged)
				return;

			Debug.LogWarningFormat($"[{_hostTypeName}] {format}", args);
		}

		[StringFormatMethod("format")]
		public void LogError(string format, params object[] args)
		{
			if (!_isLogged)
				return;

			Debug.LogErrorFormat($"[{_hostTypeName}] {format}", args);
		}

		#endregion

		#region interior

		private readonly string _hostTypeName;
		private readonly bool _isLogged;

		private Logger(Type hostType)
		{
			_hostTypeName = hostType.FullName;
			_isLogged = ILoggingSettings.Instance.ShouldLogEntity(_hostTypeName);
		}

		#endregion
	}
}