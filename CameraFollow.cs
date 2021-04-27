using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private float smooth = 0.1f;
    public Vector2 minPosition;
    public Vector2 maxPosition;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if(transform.position != target.position)
        {
            Vector3 targetposition = new Vector3(target.position.x, target.position.y, transform.position.z);

            targetposition.x = Mathf.Clamp(targetposition.x, minPosition.x, maxPosition.x);
            targetposition.y = Mathf.Clamp(targetposition.y, minPosition.y, maxPosition.y);
            transform.position = Vector3.Lerp(transform.position, targetposition, smooth);
        }
    }
}
