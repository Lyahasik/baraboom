using System.Linq;
using UnityEngine;

namespace Baraboom.Core.Tools.Logging
{
	[CreateAssetMenu(fileName = "LoggingSettings", menuName = "Baraboom/LoggingSettings")]
	public class LoggingSettings : ScriptableObject
	{
		#region facade

		public static LoggingSettings Instance
		{
			get
			{
				if (_instance == null)
					_instance = Resources.Load<LoggingSettings>("Logging");

				return _instance;
			}
		}

		public bool DisplayFrames => _displayFrames;

		public bool ShouldLogEntity(string entity)
		{
			if (!_enabled)
				return false;
			if (_excludedDomains.Any(entity.StartsWith))
				return false;

			return true;
		}

		#endregion

		#region interior

		private static LoggingSettings _instance;

		[SerializeField] private bool _enabled;
		[SerializeField] private bool _displayFrames;
		[SerializeField] private string[] _excludedDomains;

		#endregion
	}
}