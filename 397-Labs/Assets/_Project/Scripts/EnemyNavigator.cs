using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace Platformer397 {
    public class EnemyNavigator : MonoBehaviour, IObserver
    {
        private NavMeshAgent agent;
        private Transform playerTransformer;
        [SerializeField] private PlayerController player;
        [SerializeField] private List<Transform> waypoints = new List<Transform>();
        [SerializeField] private float distanceThreshold = 0f; 
        private int index = 0;
        private Vector3 destination;

        public void OnNotify()
        {
            Debug.Log("Observer notified !");    
        }

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            playerTransformer = GameObject.FindWithTag("Player").transform;
            player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
            destination = waypoints[index].position;
        }

        private void OnEnable()
        {
            player.AddObserver(this);
        }

        private void OnDisable()
        {
            player.RemoveObserver(this);
        }

        // Start is called before the first frame update
        void Start()
        {
            agent.destination = destination;    
        }
        // Update is called once per frame
        void Update()
        {
            if (agent == null)
                return;

            if (Vector3.Distance(destination, transform.position) < distanceThreshold)
            {
                index = (index + 1) % waypoints.Count;
                destination = waypoints[index].position;
                agent.destination = destination;
            }
                 
        }
    }
}
