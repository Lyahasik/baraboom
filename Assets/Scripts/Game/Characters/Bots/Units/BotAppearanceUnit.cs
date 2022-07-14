using Baraboom.Game.Characters.Bots.Protocols;
using UnityEngine;

namespace Baraboom
{
	public class BotAppearanceUnit : MonoBehaviour, IBotAppearance
	{
		#region facade

		bool IBotAppearance.Aggressive
		{
			set
			{
				_material.SetColor(_emissionColorId, value ? _colorAggressive : _colorBase);
			}
		}

		#endregion

		#region interior

		private readonly int _emissionColorId = Shader.PropertyToID("_EmissionColor");

		[SerializeField] private Color _colorAggressive;

		private Material _material;
		private Color _colorBase;

		private void Awake()
		{
			_material = GetComponentInChildren<MeshRenderer>().material;
			_colorBase = _material.GetColor(_emissionColorId);
		}

		#endregion
	}
}