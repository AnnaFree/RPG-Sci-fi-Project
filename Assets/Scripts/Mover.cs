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
        GetComponent<NavMeshAgent>().destination = target.position;
    }
}
