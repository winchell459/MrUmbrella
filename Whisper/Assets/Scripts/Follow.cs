using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform player;
    public Vector2 Smooth = new Vector2(1,1);
    public Vector2 Margin;

    public BoxCollider2D Bounds; // { get; set; }
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
    // Use this for initialization
   
    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        if (isFollowing)
        {
            float x = transform.position.x;
            float y = transform.position.y;

            //find new point to move towards using smoothing
            if (Mathf.Abs(x - player.position.x) > Margin.x)
                x = Mathf.Lerp(x, player.position.x, Smooth.x * Time.deltaTime);
            if (Mathf.Abs(y - player.position.y) > Margin.y)
                y = Mathf.Lerp(y, player.position.y, Smooth.y * Time.deltaTime);

            //check that camera is inside current bounds
            //if (Mathf.Abs(maxBounds.x - minBounds.x) > cameraHalfWidth * 2)
                x = Mathf.Clamp(x, minBounds.x + cameraHalfWidth, maxBounds.x - cameraHalfWidth);
            //if (Mathf.Abs(maxBounds.y - minBounds.y)  > cameraHalfHeight * 2)
                y = Mathf.Clamp(y, minBounds.y + cameraHalfHeight, maxBounds.y - cameraHalfHeight);

            transform.position = new Vector3(x, y, transform.position.z);
        }

    }

    public void SetBounds(BoxCollider2D bounds)
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