using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slimeness : MonoBehaviour
{
    public Animator anim;
    public float bounciness;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            anim.SetBool("isBouncedOn", true);

            collision.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounciness, ForceMode2D.Impulse);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            anim.SetBool("isBouncedOn", false);
        }
    }
}
