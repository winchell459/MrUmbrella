using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xu_Objects : MonoBehaviour
{
    void Start()
    {
        circle circle = new circle("circle", 3);
        shape square = new square("square", 2, 3);

        Debug.Log(circle.Area());


    }

  
}

public class shape
{
    public string name;
    public int num_side;
    
}
public class circle : shape
{
   float radius;
   public circle(string name, float radius)
   {
        this.name = name;
        num_side = 1;
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
    public square(string name, float height, float length)
    {
        this.name = name;
        num_side = 1;
        this.length = length;
        this.height = height;
    }
    public float Area()
    {
        return length * height;
    }
}