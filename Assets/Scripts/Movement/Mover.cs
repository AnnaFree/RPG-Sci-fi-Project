using RPG.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//UnityEngine.AI include NavMesh
namespace RPG.Movement
{
    //adding , after inheritance allows addition to other interfaces, like IAction interface
    //cannot inherit from more than one class but can inherit from many interfaces
    public class Mover : MonoBehaviour, IAction
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
        public void Cancel()
        {
            //public method must be included for IAction to be passed
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
            //redirects to mutual dependency
            GetComponent<ActionScheduler>().StartAction(this);
            //cancel fighting before moving
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
