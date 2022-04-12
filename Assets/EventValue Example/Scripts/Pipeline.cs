using EventValue_Example.Scripts.Interfaces;
using EventValue_Example.Scripts.Util;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EventValue_Example.Scripts
{
    public class Pipeline : MonoBehaviour
    {
        private ILoseScreen _loseScreen;
        private ICounter _counter;
        private IPlayer _player;

        private void Awake()
        {
            _loseScreen = this.FindOrException<ILoseScreen>();
            _counter = this.FindOrException<ICounter>();
            _player = this.FindOrException<IPlayer>();
        }

        private void Start()
        {
            _counter.Value = 0;
            _player.JumpCount.ValueChanged += JumpCountOnValueChanged;
            _player.OutOfScreen += PlayerOnOutOfScreen;
            _loseScreen.RestartRequest += LoseScreenOnRestartRequest;
        }

        private void OnDestroy()
        {
            if (_player != null)
            {
                _player.JumpCount.ValueChanged -= JumpCountOnValueChanged;
                _player.OutOfScreen -= PlayerOnOutOfScreen;
            }

            if (_loseScreen != null)
                _loseScreen.RestartRequest -= LoseScreenOnRestartRequest;
        }

        private void PlayerOnOutOfScreen()
        {
            _player.Freeze();
            _loseScreen.Show();
        }

        private void LoseScreenOnRestartRequest() => SceneManager.LoadScene(0);

        private void JumpCountOnValueChanged(int obj) => _counter.Value = obj;
    }
}