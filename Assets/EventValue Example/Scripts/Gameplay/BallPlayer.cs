using System;
using EventValue_Example.Scripts.Interfaces;
using NickKhalow.Util;
using UnityEngine;

namespace EventValue_Example.Scripts.Gameplay
{
    [RequireComponent(typeof(Rigidbody))]
    public class BallPlayer : MonoBehaviour, IPlayer
    {
        public event Action OutOfScreen;

        [SerializeField] private float jumpPower;

        private EventValue<int> _jumpCount;
        private Rigidbody _rigidbody;

        private bool _beenVisible;

        public IReadOnlyEventValue<int> JumpCount => _jumpCount;

        public void Freeze()
        {
            _rigidbody.isKinematic = true;
            enabled = false;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _jumpCount = 0;
        }

        private void Update()
        {
            if (Input.anyKeyDown)
            {
                _rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
                _jumpCount.Value++;
            }
        }

        private void OnBecameVisible()
        {
#if UNITY_EDITOR
            Debug.Log("Visible!");
#endif
            _beenVisible = true;
        }

        private void OnBecameInvisible()
        {
            if (_beenVisible)
            {
#if UNITY_EDITOR
                Debug.Log("Invisible!");
#endif
                OutOfScreen?.Invoke();
            }
        }
    }
}