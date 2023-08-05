 using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour 
{
	public float walkSpeed = 30f;

	public float horizontalMove;
	public float verticalMove;

	public Vector2 Move; 

	private Rigidbody2D _rigidBody; 
	public AudioSource Attack;


	void Awake(){
		_rigidBody = GetComponent<Rigidbody2D>();
	}
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * walkSpeed;
		verticalMove = Input.GetAxisRaw("Vertical") * walkSpeed;

		Move = new Vector2(horizontalMove, verticalMove);
		_rigidBody.MovePosition(_rigidBody.position + Move * Time.deltaTime);

		//if (Logs >= MaxLogs) SceneManager.LoadScene(2);

	}
	/*void OnTriggerEnter2D(Collider2D other){
		if (other.TryGetComponent<Log>(out Log Log)){ 
			Logs ++;
			Destroy(other.gameObject);
		}
		if (other.gameObject.GetComponent<URP>()){ 
			PlusHP = false;
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.GetComponent<URP>()){ 
			PlusHP = true;
		}
	}
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.GetComponent<aircraftF>()){ 

		}
	}*/
}