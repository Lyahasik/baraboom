using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TypeReferences;
using UnityEngine;
using Zenject;
using Logger = Baraboom.Core.Tools.Logging.Logger;

namespace Baraboom.Game.Characters.Bots.Tools.StateMachine
{
	public sealed partial class StateMachine : MonoBehaviour, ITransitionConditionEvaluator
	{
		[SerializeField, Inherits(typeof(StateGraph))] private TypeReference _graphScript;

		[Inject] private IConditionFactory _conditionFactory;
		[Inject] private IStateFactory _stateFactory;

		private Logger _logger;
		private StateGraphData _graphData;
		private IState _current;
		private readonly Dictionary<Type, ICondition> _conditions = new();

		private void Awake()
		{
			_logger = Logger.For<StateMachine>();

			try
			{
				_graphData = ((StateGraph)Activator.CreateInstance(_graphScript.Type)).ExportData();
			}
			catch (Exception exception)
			{
				_logger.LogError("Couldn't load state graph: {0}", exception);
				throw;
			}
		}

		private IEnumerator Start()
		{
			// Wait one frame for other components to initialize.
			yield return null;

			SwitchState(_graphData.InitialState);
		}

		[UsedImplicitly]
		private void Terminate()
		{
			Destroy(this);
		}

		private void OnDestroy()
		{
			_current?.Deinitialize();
			_current = null;
		}

		private void Update()
		{
			UpdateCurrentState();
			if (_current == null)
				return;

			foreach (var (destinationState, condition) in _graphData.GetTransitions(_current.GetType()))
			{
				if (EvaluateCondition(condition))
				{
					SwitchState(destinationState);
					break;
				}
			}
		}
	}
}