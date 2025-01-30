using UnityEngine;
using UnityEngine.AI;


namespace Platformer397 {
    public class EnemyNavigator : MonoBehaviour
    {
        private NavMeshAgent agent;
        private Transform playerTransformer;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            playerTransformer = GameObject.FindWithTag("Player").transform;
        }
        
        // Start is called before the first frame update
        void Start()
        {

        }
        // Update is called once per frame
        void Update()
        {
            agent.SetDestination(playerTransformer.position);  
        }
    }
}
