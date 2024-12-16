using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    //transform type since we need to know position
    [SerializeField] Transform target;

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position;
    }
}
