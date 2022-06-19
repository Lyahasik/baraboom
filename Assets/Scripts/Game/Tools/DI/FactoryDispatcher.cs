using System;
using System.Collections.Generic;
using Zenject;

namespace Baraboom.Game.Tools.DI
{
	public class FactoryDispatcher<TBase>
	{
		#region facade

		public TBase Instantiate(Type type)
		{
			if (type == null)
				throw new ArgumentException("Type is null.");

			if (!_factoryByType.TryGetValue(type, out var factory))
				throw new ArgumentException($"Factory for type {type} is not registered.");

			return factory.Create();
		}

		#endregion

		#region extension

		protected void RegisterFactory<TDerived>(IFactory<TBase> factory)
		{
			_factoryByType[typeof(TDerived)] = factory;
		}

		#endregion

		#region interior

		private readonly Dictionary<Type, IFactory<TBase>> _factoryByType = new();

		#endregion
	}
}