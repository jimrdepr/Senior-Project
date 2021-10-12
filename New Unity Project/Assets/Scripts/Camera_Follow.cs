using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    Transform target;
    Vector3 offset;
	public Vector2 maxPosition;
	public Vector2 minPosition;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        offset.x = 0;
        offset.y = 0;
        offset.z = -10;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x + offset.x, target.position.y + offset.y, offset.z);
    }
}
