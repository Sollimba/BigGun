using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonControl : MonoBehaviour
{
    public Transform cannonBarrel; 
    public Transform cannonBody;
    public float rotationSpeed = 5f; 

    void Update()
    {
        float barrelRotationInput = Input.GetAxis("Vertical");
        float bodyRotationInput = Input.GetAxis("Horizontal");

        cannonBarrel.Rotate(Vector3.left, barrelRotationInput * rotationSpeed * Time.deltaTime);
        cannonBody.Rotate(Vector3.up, bodyRotationInput * rotationSpeed * Time.deltaTime);
    }
}
