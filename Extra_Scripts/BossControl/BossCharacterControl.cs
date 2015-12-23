using System;
using UnityEngine;

namespace ThirdPersonRPG.Boss
{
    [RequireComponent(typeof (NavMeshAgent))]
    [RequireComponent(typeof (BossCharacter))]
    public class BossCharacterControl : MonoBehaviour
    {
        public NavMeshAgent agent { get; private set; } // the navmesh agent required for the path finding
        public BossCharacter character { get; private set; } // the character we are controlling
        
		private Transform target; // target to aim for

        // Use this for initialization
        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<NavMeshAgent>();
            character = GetComponent<BossCharacter>();
			target = GameObject.FindGameObjectWithTag ("Player").transform;

	        agent.updateRotation = false;
	        agent.updatePosition = true;
        }


        // Update is called once per frame
        private void Update()
        {
            if (target != null && gameObject.GetComponent<EnemyHealth>().isDead == false)
            {
                agent.SetDestination(target.position);

				
				
                // use the values to move the character
                character.Move(agent.desiredVelocity, false);
            }
            else
            {
                // We still need to call the character's move function, but we send zeroed input as the move param.
                character.Move(Vector3.zero, false);
            }

        }
    }
}
