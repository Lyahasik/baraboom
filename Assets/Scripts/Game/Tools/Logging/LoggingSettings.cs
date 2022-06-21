using System.Linq;
using UnityEngine;

namespace Baraboom.Game.Tools.Logging
{
	[CreateAssetMenu(fileName = "LoggingSettings", menuName = "Baraboom/LoggingSettings", order = 1)]
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
		[SerializeField] private string[] _excludedDomains;

		#endregion
	}
}