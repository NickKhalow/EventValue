using System;
using EventValue_Example.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace EventValue_Example.Scripts.UI
{
    [RequireComponent(typeof(Text))]
    public class Counter : MonoBehaviour, ICounter
    {
        private int _value;
        private Text _text;

        private void Awake() => _text = GetComponent<Text>();

        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                _text.text = value.ToString();
            }
        }
    }
}