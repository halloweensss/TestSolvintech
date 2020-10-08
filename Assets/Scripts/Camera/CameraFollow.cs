using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform targetObject;
    [SerializeField] private float speed;
    [SerializeField] private float speedRotation;
    
    [SerializeField] private Vector3 offset;

    private Vector3 _velocity = Vector3.zero;

    
    void FixedUpdate()
    {
        if (targetObject != null)
        {
            Look(targetObject);
        }
    }

    private void Look(Transform target)
    {
        
        //transform.position = newPos;
        transform.position = target.position + target.up * offset.y;

        Quaternion targetRot = Quaternion.LookRotation(-transform.position.normalized, -target.up);
        //transform.rotation = targetRot;
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * speedRotation);
        //transform.LookAt(target);
    }
}
