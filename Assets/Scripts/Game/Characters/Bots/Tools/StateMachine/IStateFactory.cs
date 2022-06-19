using System;

namespace Baraboom.Game.Characters.Bots.Tools.StateMachine
{
	public interface IStateFactory
	{
		IState Instantiate(Type type);
	}

	public interface IStateFactory<out T> : IStateFactory where T : IState
	{
		IState IStateFactory.Instantiate(Type type)
		{
			return Instantiate(type);
		}

		new T Instantiate(Type type);
	}
}