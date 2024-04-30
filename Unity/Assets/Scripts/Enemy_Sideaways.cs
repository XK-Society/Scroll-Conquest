using UnityEngine;

public class Enemy_Sideaways: MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    private  bool movingLeft;
    private float leftEdge;
    private float rightEdge;


    private void Awake()
    {
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
    }

    private void Update () 
    {
    if (movingLeft)
        {
        if (transform.position.x > leftEdge)
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f);
        }
        else
        {
            movingLeft = false;
        }
        }
    else 
    {
        if (transform.position.x < rightEdge)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
        }
        else
        {
            movingLeft = true;
        }
    }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    } 

}