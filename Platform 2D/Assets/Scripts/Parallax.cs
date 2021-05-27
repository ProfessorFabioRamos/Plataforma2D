using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform cameraTransform;
    private Vector3 lastCameraPosition;
    public Vector2 parallaxSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        parallaxSpeed = new Vector2(0.5f, 0);
    }
 
     void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxSpeed.x, deltaMovement.y * parallaxSpeed.y);
        lastCameraPosition = cameraTransform.position;
    }
}
