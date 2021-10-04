using System.Collections;
using UnityEngine;

public class zoomControl : MonoBehaviour{
    public float zoomSize=5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetAxis("Mouse ScrollWheel")>0)
        {
            if (zoomSize>2)
            zoomSize-=1;
        }
        if (Input.GetAxis("Mouise ScrollWheel")<0)
        {
            if (zoomSize < 4)
            zoomSize +=1;
        }
        GetComponent<Camera> ().orthographicSize=zoomSize;
    }
}