using UnityEngine;

public class Fish : MonoBehaviour
{
	public float Speed;
    public Transform target;

    public Sprite[] sprites;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length - 1)];
        float scale = Random.Range(0.5f, 1.5f);
        transform.GetChild(0).localScale = new Vector3(scale, scale, scale);
    }

    void Update ()
    {
        rb.MovePosition(transform.position - transform.right * Time.deltaTime * Speed * -1);

        Vector3 rotation = target.position - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

    }
           
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == gameObject.name)
        {
            RandomTargetPosition();
        }
        if (other.gameObject.name == "Dno" || other.gameObject.name == "Border")
        {
            RandomTargetPosition();
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == gameObject.name)
        {
            RandomTargetPosition();
        }
        if (other.gameObject.name == "Dno" || other.gameObject.name == "Border")
        {
            RandomTargetPosition();
        }
    }
    public void RandomTargetPosition()
    {
        target.position = new Vector2(Random.Range(-16f, 25), Random.Range(-3f, 30f));
    }
}
