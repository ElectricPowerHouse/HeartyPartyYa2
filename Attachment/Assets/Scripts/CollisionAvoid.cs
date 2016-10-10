using UnityEngine;
using System.Collections;

public class CollisionAvoid : MonoBehaviour
{

    public Collider2D top;
    public Collider2D left;
    public Collider2D right;

    // Use this for initialization
    void Start()
    {

        top = GameObject.FindGameObjectWithTag("top").GetComponent<Collider2D>();
        left = GameObject.FindGameObjectWithTag("left").GetComponent<Collider2D>();
        right = GameObject.FindGameObjectWithTag("right").GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), top);
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), left);
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), right);




    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "block")
        {
            GameObject obj = col.gameObject;
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), obj.GetComponent<Collider2D>());
        }
    }

}
