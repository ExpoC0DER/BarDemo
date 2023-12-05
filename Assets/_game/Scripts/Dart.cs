using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using FMODUnity;

public class Dart : MonoBehaviour
{
    [SerializeField] private Transform _starPos, _endPos;
    [SerializeField] private float _speed, _delay;
    private StudioEventEmitter _dartHitSound;
    private bool throwing = true;


    private void Awake() { _dartHitSound = GetComponent<StudioEventEmitter>(); }

    private IEnumerator Start()
    {
        while (throwing)
        {
            transform.position = _starPos.position;
            transform.DOMove(_endPos.position, _speed).SetEase(Ease.Flash).OnComplete(_dartHitSound.Play);
            yield return new WaitForSeconds(_delay);
        }
    }


    private void Update() { }
}
