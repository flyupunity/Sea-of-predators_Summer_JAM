using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Turtle : MonoBehaviour
{
	public float Speed;
    public Transform target;

    bool Player = false;
    Transform PlayerT;

    void Awake(){
		Player = false;
    }

	void Update (){

		PlayerT = GameObject.FindGameObjectWithTag("Player").transform;

		if(Player == true){

            GetComponent<Rigidbody2D>().MovePosition(transform.position - transform.right * Time.deltaTime * Speed * -1);

            Vector3 rotation = PlayerT.position - transform.position;
            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
        }
		if(Player == false){
            if (Vector2.Distance(transform.position, PlayerT.position) <= 2f * transform.localScale.y)
            {
                Player = true;
                Speed *= 2;
            }
            GetComponent<Rigidbody2D>().MovePosition(transform.position - transform.right * Time.deltaTime * Speed * -1);

            Vector3 rotation = target.position - transform.position;
            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
        }
		
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
        if (other.gameObject.name == "Dno" || other.gameObject.name == "Border")
        {
            RandomTargetPosition();
        }
        if (other.gameObject.name == gameObject.name)
        {
            RandomTargetPosition();
        }
    }

    private void RandomTargetPosition()
    {
        target.position = new Vector2(Random.Range(-16f, 25), Random.Range(-3f, 30f));
    }
}
