using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravitation : MonoBehaviour
{
    [SerializeField] private float gravity = -10;
    [SerializeField] private float rotationObject = 20;
    
    private Transform _transform;

    public void Start()
    {
        _transform = GetComponent<Transform>();
    }

    public void Attract(Rigidbody rigidbody)
    {
        Transform objectTransform = rigidbody.transform;
        Vector3 gravityUp = (objectTransform.position - _transform.position).normalized;
        Vector3 transformUp = objectTransform.up;
        
        rigidbody.AddForce(gravityUp * gravity);

        Quaternion rotation = Quaternion.FromToRotation(transformUp, gravityUp) * objectTransform.rotation;
        objectTransform.rotation = Quaternion.Lerp(objectTransform.rotation, rotation, 
            Time.deltaTime * rotationObject);
    }
}
