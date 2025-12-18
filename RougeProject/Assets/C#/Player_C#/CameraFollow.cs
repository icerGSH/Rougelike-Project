using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothing;

    public Vector2 minPosition;
    public Vector2 maxPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void LateUpdate()
    {
        if(player!= null)
        {
            if(transform.position!=player.position)
            {
                Vector3 targetPos = player.position;
                targetPos.x = Mathf.Clamp(targetPos.x, minPosition.x, maxPosition.x);
                targetPos.y = Mathf.Clamp(targetPos.y, minPosition.y, maxPosition.y);
                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing*Time.deltaTime);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
