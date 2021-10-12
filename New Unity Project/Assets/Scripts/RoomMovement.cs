using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMovement : MonoBehaviour{
	
	public Vector2 cameraChangeMax;
	public Vector2 cameraChangeMin;
	public Vector3 playerChange;
	private Camera_Follow cam;
	
    // Start is called before the first frame update
    void Start(){
        cam= Camera.main.GetComponent<Camera_Follow>();
    }

    // Update is called once per frame
    void Update(){
        
    }
	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			cam.minPosition = cameraChangeMin;
			cam.maxPosition = cameraChangeMax;
			other.transform.position += playerChange;
		}
	}
}
