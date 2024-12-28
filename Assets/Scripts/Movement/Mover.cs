using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//UnityEngine.AI include NavMesh
public class Mover : MonoBehaviour
{
    [SerializeField] Transform target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
        UpdateAnimator();
    }
    
    private void MoveToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);
        if (hasHit)
        {
            MoveTo(hit.point);

            Debug.Log("Destination: " + hit.point);

        }
    }

    public void MoveTo(Vector3 destination)
    {
        GetComponent<NavMeshAgent>().destination = destination;
       
    }

    private void UpdateAnimator()
    {//transform to a local to give the information more easily to the animator
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        //all we need to know is the z speed to know how fast we are going
        float speed = localVelocity.z;
        
        //string references are not ideal but sometimes you have to use them
        GetComponent<Animator>().SetFloat("forwardSpeed", speed);
       
    }
}
