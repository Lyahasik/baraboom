using System;
using Baraboom.Game.Tools.DiscreteWorld;
using JetBrains.Annotations;
using UnityEngine;

namespace Baraboom.Game.Level.Items
{
    [RequireComponent(typeof(DiscreteCollider))]
    public sealed class Item : MonoBehaviour
    {
        [SerializeField] private float _speedRotation;
        
        private IEffect _effect;

        private void Awake()
        {
            _effect = GetComponent<IEffect>();
        }

        private void Start()
        {
            transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
        }

        private void Update()
        {
            transform.Rotate(Vector3.up, _speedRotation * Time.deltaTime);
        }

        [UsedImplicitly]
        private void OnDiscreteCollision(DiscreteCollider other)
        {
            var recipient = other.GetComponent<IEffectRecipient>();
            if (recipient != null)
            {
                _effect.TryApply(recipient);
                Destroy(gameObject);
            }
        }
    }
}
