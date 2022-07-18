using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baraboom.Game.Characters
{
    public abstract class CharacterEffects : MonoBehaviour
    {
        [SerializeField] private float _durationElectricity;
        
        private Coroutine _coroutineElectricity;
        private MeshRenderer _meshRenderer;
        private Material[] _materials;
        private Material _materialElectricity;

        private void Start()
        {
            _meshRenderer = GetComponentInChildren<MeshRenderer>();
            _materials = _meshRenderer.materials;
            _materialElectricity = _materials[1];

            _materials[1] = null;
            _meshRenderer.materials = _materials;
        }

        public void ActivateElectricityShader()
        {
            if (_coroutineElectricity != null)
                StopCoroutine(_coroutineElectricity);
			
            _coroutineElectricity = StartCoroutine(EnableElectricity());
        }

        private IEnumerator EnableElectricity()
        {
            _materials[1] = _materialElectricity;
            _meshRenderer.materials = _materials;
			
            yield return new WaitForSeconds(_durationElectricity);

            _materials[1] = null;
            _meshRenderer.materials = _materials;

            _coroutineElectricity = null;
        }
    }
}
