using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform player;
    public Vector2 Smooth = new Vector2(1,1);
    public Vector2 Margin;

    public BoxCollider2D Bounds { get; set; }
    private Vector2 minBounds, maxBounds;

    float cameraHalfWidth, cameraHalfHeight;

    public bool isFollowing { get; set; }

    private void Start()
    {

        cameraHalfHeight = GetComponent<Camera>().orthographicSize;
        cameraHalfWidth = cameraHalfHeight * ((float)Screen.width / Screen.height);
    }

    private void Update()
    {
        
        
    }
    
    void LateUpdate()
    {
        if (isFollowing && player != null)
        {
            float x = transform.position.x;
            float y = transform.position.y;


            //find new point to move towards using smoothing
            if (Mathf.Abs(x - player.position.x) > Margin.x)
                x = Mathf.Lerp(x, player.position.x, Smooth.x * Time.deltaTime);
            if (Mathf.Abs(y - player.position.y) > Margin.y)
                y = Mathf.Lerp(y, player.position.y, Smooth.y * Time.deltaTime);
            


            float minX = minBounds.x + cameraHalfWidth;            float maxX = maxBounds.x - cameraHalfWidth;            float minY = minBounds.y + cameraHalfHeight;            float maxY = maxBounds.y - cameraHalfHeight;

            //check that camera is inside current bounds

            if (transform.position.x < minBounds.x + cameraHalfWidth) minX = transform.position.x;            else if (transform.position.x > maxBounds.x - cameraHalfWidth) maxX = transform.position.x;            if (transform.position.y < minY) minY = transform.position.y;            else if (transform.position.y > maxY) maxY = transform.position.y;            x = Mathf.Clamp(x, minX, maxX);            y = Mathf.Clamp(y, minY, maxY);              transform.position = new Vector3(x, y, transform.position.z); 
        }
        else
        {
            player = FindObjectOfType<PlayerController>().transform;
        }
    }

    public void SetBound(BoxCollider2D bounds)
    {
        this.Bounds = bounds;

        minBounds = Bounds.bounds.min;
        maxBounds = Bounds.bounds.max;
    }
    public void SetTarget(Transform Target)
    {
        player = Target;
        isFollowing = true;
    }
}