using UnityEngine;

namespace Baraboom.Game.Tools.Logging
{
	public interface ILoggingSettings
	{
		// TODO Inject
		public static ILoggingSettings Instance
		{
			get
			{
				return Resources.Load<LoggingSettings>("LoggingSettings");
			}
		}

		bool ShouldLogEntity(string entity);
	}
}