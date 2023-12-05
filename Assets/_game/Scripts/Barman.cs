using System;
using System.Collections;
using System.Collections.Generic;
using AOT;
using FMOD;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace _game.Scripts
{
    public class Barman : MonoBehaviour
    {
        [SerializeField] private StudioEventEmitter _pokrik;
        [SerializeField] private List<DialogLine> _dialog = new List<DialogLine>();
        private bool _shoutAtPlayer = true;
        private bool _firtime = true;

        public IEnumerator Start()
        {
            while (_shoutAtPlayer)
            {
                _pokrik.Play();
                yield return new WaitForSeconds(5f);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            _shoutAtPlayer = false;
            if (_firtime)
                StartCoroutine(BarmanDialogFirstTime());
        }

        private IEnumerator BarmanDialogFirstTime()
        {
            _firtime = false;
            foreach (var DialogLine in _dialog)
            {
                DialogLine.DialogLineSound.Play();
                yield return new WaitForSeconds(DialogLine.LineLength);
            }
        }
    }

    [Serializable]
    public struct DialogLine
    {
        public StudioEventEmitter DialogLineSound;
        public float LineLength;
    }
}
