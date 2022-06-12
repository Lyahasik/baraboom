using System.Linq;
using UnityEngine;

namespace Baraboom.Game.Tools.Logging
{
	[CreateAssetMenu(fileName = "LoggingSettings", menuName = "Baraboom/LoggingSettings", order = 1)]
	public class LoggingSettings : ScriptableObject, ILoggingSettings
	{
		#region facade

		bool ILoggingSettings.ShouldLogEntity(string entity)
		{
			if (!_enabled)
				return false;
			if (_excludedDomains.Any(entity.StartsWith))
				return false;

			return true;
		}

		#endregion

		#region interior

		[SerializeField] private bool _enabled;
		[SerializeField] private string[] _excludedDomains;

		#endregion
	}
}