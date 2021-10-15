
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public Transform target ;
    private Vector3 offset ;
    public float smoothSpeed =0.04f ;

    // Start is called before the first frame update
    void Start()
    {
      offset = transform.position -target.position;
    }

    // Late Update is called later
    void LateUpdate()
    {
        Vector3 newPosition =Vector3.Lerp(transform.position ,target.position + offset,smoothSpeed);//speed should be between 0 ans 1
        transform.position = newPosition; 
    }
}
