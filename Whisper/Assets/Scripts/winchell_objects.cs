using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winchell_objects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        circle circle = new circle("circle", 3);
        shape square = new square("triangle", 2, 3);
        //shape triangle = new shape("square");
        Debug.Log(circle.name);
    } 
}

public class shape
{
    public string name;
    public int num_sides;

    
}

public class circle : shape
{
    float radius;
    public circle(string name, float radius)
    {
        this.name = name;
        num_sides = 1;
        this.radius = radius;
    }
    public float Area()
    {
        return Mathf.PI * radius * radius;
    }
    
}

public class square : shape
{
    float length, height;
    public square(string name, float length, float height)
    {
        this.name = name;
        num_sides = 1;
        this.length = length;
        this.height = height;
    }
    public float Area()
    {
        return length * height;
    }

}