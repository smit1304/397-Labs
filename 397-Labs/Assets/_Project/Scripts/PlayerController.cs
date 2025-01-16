using System;
using UnityEngine;


namespace Platformer397{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private InputReader input;

        private void Start()
        {
            Debug.Log("[Start]");
            input.EnablePlayerActions();    
        }

        private void OnEnable()
        {
            Debug.Log("[OnEnable]");
            input.Move += Move;
        }

        private void Move(Vector2 arg0)
        {
            Debug.Log("Input is working "+ arg0);
        }

        private void OnDisable()
        {
            input.Move -= Move;
            Debug.Log("[OnDisable]");
        }

        private void OnDestroy()
        {
            Debug.Log("[OnDestroy]");

        }
    }
}

