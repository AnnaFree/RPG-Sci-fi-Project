using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    //transform type since we need to know position
    [SerializeField] Transform target;

    // Update is called once per frame
   //late update ensures the animation has time to start before the camera so the camera will not be buggy
    void LateUpdate()
    {
        transform.position = target.position;
    }
}
