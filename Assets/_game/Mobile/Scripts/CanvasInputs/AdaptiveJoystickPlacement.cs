using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _game.Mobile.Scripts.CanvasInputs
{
    public class AdaptiveJoystickPlacement : MonoBehaviour
    {
        [SerializeField] private RectTransform _joystickMove;
        [SerializeField] private RectTransform _joystickLook;
        private StarterAsset _input;

        private void Awake() { _input = new StarterAsset(); }

        private void Start()
        {
            _input.Player.TouchPress.started += ctx => StartTouch(ctx);
            _input.Player.TouchPress.canceled += ctx => EndTouch(ctx);
        }

        private void StartTouch(InputAction.CallbackContext context)
        {
            Vector2 touchPos = _input.Player.TouchPosition.ReadValue<Vector2>();
            Debug.Log("Touch started " + touchPos);
            if (touchPos.x < (float)Screen.width / 2)
            {
                _joystickMove.anchoredPosition = new(touchPos.x * (1600f / Screen.width), touchPos.y * (900f / Screen.height));
            }
            else
            {
                _joystickLook.anchoredPosition = new(touchPos.x * (1600f / Screen.width) - 1600, touchPos.y * (900f / Screen.height));
            }
        }

        private void EndTouch(InputAction.CallbackContext context)
        {
            Debug.Log("Touch ended");
        }



        private void OnEnable() { _input.Enable(); }

        private void OnDisable() { _input.Disable(); }
    }
}
