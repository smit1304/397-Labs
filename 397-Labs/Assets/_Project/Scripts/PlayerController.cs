using System;
using UnityEngine;


namespace Platformer397{

    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private InputReader input;
        [SerializeField] private Rigidbody rb;

        [SerializeField] private float moveSpeed = 200f;
        [SerializeField] private float rotationSpeed = 200f;
        [SerializeField] private Transform mainCamera;

        private Vector3 movement;
        
        private void Awake()
        {
            //Debug.Log("[Awake]");
            rb = GetComponent<Rigidbody>();
            mainCamera = Camera.main.transform;   
            rb.freezeRotation = true;   
        }
        private void Start()
        {
            //Debug.Log("[Start]");
            input.EnablePlayerActions();    
        }

        private void OnEnable()
        {
            //Debug.Log("[OnEnable]");
            input.Move += GetMovement;
        }

        private void FixedUpdate()
        {
            UpdateMovement();   
        }

        private void GetMovement(Vector2 move)
        {
            //Debug.Log("Input is working "+ move);
            movement.x = move.x;
            movement.z = move.y;
        }

        private void UpdateMovement() 
        {
            var adjusteeDirection = Quaternion.AngleAxis(mainCamera.eulerAngles.y, Vector3.up) * movement;

            if (adjusteeDirection.magnitude > 0) 
            {
                //handle rotation and movement
                HandleMovement(adjusteeDirection);
                HandleRotation(adjusteeDirection);
            }
            else
            {
                // not change the rotation or movement, but need to apply rigidbody Y movement for gravity
                rb.linearVelocity = new Vector3(0f, rb.linearVelocity.y, 0f);
            }

        }

        private void HandleMovement(Vector3 adjustedMovement) 
        { 
            var velocity = adjustedMovement * moveSpeed * Time.fixedDeltaTime;  
            rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);

        }
        private void HandleRotation(Vector3 adjustedMovement) 
        { 
            var targetRotation = Quaternion.LookRotation(adjustedMovement, Vector3.up); 

            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);

        }   
        private void OnDisable()
        {
            input.Move -= GetMovement;
            Debug.Log("[OnDisable]");
        }

        private void OnDestroy()
        {
            Debug.Log("[OnDestroy]");

        }
    }
}

