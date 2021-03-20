using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3GameCameraController : MonoBehaviour
{
    private float moveSpeed = 1.5f;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target.position.z > -0.08968905) {
            Vector3 newPosition = new Vector3(target.position.x, transform.position.y, target.position.z - 4f);
            transform.position = Vector3.Lerp(transform.position, newPosition, moveSpeed*Time.deltaTime);
        } else {
             Vector3 newPosition = new Vector3(target.position.x, transform.position.y,  transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPosition, moveSpeed*Time.deltaTime);
        }    
    }
}
