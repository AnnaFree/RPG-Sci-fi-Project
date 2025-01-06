using RPG.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//UnityEngine.AI include NavMesh
namespace RPG.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] Transform target;

        NavMeshAgent navMeshAgent;
        //default monoBehavior methods
        private void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {

            UpdateAnimator();
        }
        //check if stopped method
        public void Stop()
        {
            navMeshAgent.isStopped = true;
        }
        //moving methods
       

        public void MoveTo(Vector3 destination)
        {
            navMeshAgent.destination = destination;
            navMeshAgent.isStopped = false;
        }

        public void StartMoveAction(Vector3 destination)
        {
            //cancel fighting before moving
            GetComponent<Fighter>().Cancel();
            MoveTo(destination);
        }

        private void UpdateAnimator()
        {//transform to a local to give the information more easily to the animator
            Vector3 velocity = navMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            //all we need to know is the z speed to know how fast we are going
            float speed = localVelocity.z;

            //string references are not ideal but sometimes you have to use them
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);

        }
    }

}
