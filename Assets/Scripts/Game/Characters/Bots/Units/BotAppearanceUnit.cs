using System.Collections;
using Baraboom.Core.Tools;
using Baraboom.Core.UI;
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
				if (this == null)
					return;

				ChangeColor(value ? _colorAggressive : _colorMain);
			}
		}

		#endregion

		#region interior

		private readonly int _emissionColorId = Shader.PropertyToID("_EmissionColor");

		[SerializeField] private Color _colorAggressive;

		private Material _material;
		private Color _colorMain;
		private Coroutine _changeColorCoroutine;

		private void Awake()
		{
			_material = GetComponentInChildren<MeshRenderer>().material;
			_colorMain = _material.GetColor(_emissionColorId);
		}

		private void ChangeColor(Color targetColor)
		{
			if (_changeColorCoroutine != null)
				StopCoroutine(_changeColorCoroutine);

			_changeColorCoroutine = StartCoroutine(ChangeColorRoutine(_material.GetColor(_emissionColorId), targetColor));
		}

		private IEnumerator ChangeColorRoutine(Color start, Color finish)
		{
			yield return Coroutines.Update(
				phase =>
				{
					if (this != null)
						_material.SetColor(_emissionColorId, Color.Lerp(start, finish, phase));
				},
				UIConstants.ShortenedAnimationDuration
			);

			_changeColorCoroutine = null;
		}

		#endregion
	}
}