using System;
using EventValue_Example.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace EventValue_Example.Scripts.UI
{
    [RequireComponent(typeof(Canvas))]
    public class LoseScreen : MonoBehaviour, ILoseScreen
    {
        public event Action RestartRequest;
        
        [SerializeField] private bool hideOnStart = true;
        [SerializeField] private Button restartButton;

        private Canvas _canvas;
        
        private void Awake()
        {
            _canvas= GetComponent<Canvas>();
            restartButton.onClick.AddListener(() => RestartRequest?.Invoke());
        }

        private void Start() => _canvas.enabled = !hideOnStart;

        public void Show() => _canvas.enabled = true;
    }
}