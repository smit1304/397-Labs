using Unity.Cinemachine;
using UnityEngine;

namespace Platformer397
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private CinemachineCamera freeLockCam;
        [SerializeField] private Transform player;
        // Start is called before the first frame update
        void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false; 
            if(player != null ) {   return; }

            player = GameObject.FindWithTag("Player").transform;    
        }
        // Update is called once per frame
        void Update()
        {

        }

        private void OnEnable()
        {
            freeLockCam.Target.TrackingTarget = player;    
        }
    }
}
