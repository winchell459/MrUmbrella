using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public bool isFollowing { get; set; }

    public Vector2 Margin;
    public Vector2 Smoothing;

    public BoxCollider2D Bounds;
    private Vector3 minBounds, maxBounds;

    Camera myCamera;
    float cameraHalfWidth;
    float cameraHalfHeight;

    // Start is called before the first frame update
    void Start()
    {
        //SetBounds(Bounds);
        //isFollowing = true;
        myCamera = GetComponent<Camera>();
        cameraHalfWidth = myCamera.orthographicSize * ((float)Screen.width / Screen.height);
        cameraHalfHeight = myCamera.orthographicSize;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = transform.position.x;
        float y = transform.position.y;

        if (isFollowing)
        {
            if (Mathf.Abs(x - Target.position.x) > Margin.x)
                x = Mathf.Lerp(x, Target.position.x, Smoothing.x * Time.deltaTime);
            if (Mathf.Abs(y - Target.position.y) > Margin.y)
                y = Mathf.Lerp(y, Target.position.y, Smoothing.y * Time.deltaTime);

            x = Mathf.Clamp(x, minBounds.x + cameraHalfWidth, maxBounds.x - cameraHalfWidth);
            y = Mathf.Clamp(y, minBounds.y + cameraHalfHeight, maxBounds.y - cameraHalfHeight);

            transform.position = new Vector3(x, y, transform.position.z);
        }
    }

    public void SetBounds(BoxCollider2D Bounds)
    {
        this.Bounds = Bounds;
        minBounds = Bounds.bounds.min;
        maxBounds = Bounds.bounds.max;
    }

    public void SetTarget(Transform Target)
    {
        this.Target = Target;
        isFollowing = true;
    }
}
