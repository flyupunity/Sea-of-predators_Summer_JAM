using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour 
{
	[Range (0,10)]
	public float runSpeed = 1.5f;
	public float walkSpeed = 30f;
	[Range (0,1)]
	public float crouchSpeed = 0.5f;

	[SerializeField] private Collider2D m_CrouchDisableCollider;
	public float horizontalMove;
	public float verticalMove;

	public Text Text;
	public int Logs;
	public int MaxLogs;

	public Slider SliderHP;
	[Range (0,100)]
	public float HP;

	public Vector2 Move; 
	public KeyCode Run; 
	public KeyCode LA; 
	private Rigidbody2D _rigidBody; 

	public AudioSource Attack;
	public bool PlusHP = true;
	bool crouch = false;

	public FixedJoystick FixedJoystick;

	void Awake(){
		_rigidBody = GetComponent<Rigidbody2D>();
		crouch = false;
	}
	void Update () {
		SliderHP.value = HP;
		Text.text = Logs + "/" + MaxLogs;
//#if ANDROID
		horizontalMove = FixedJoystick.Horizontal * walkSpeed;
		verticalMove = FixedJoystick.Vertical * walkSpeed;

		if (horizontalMove > 0){
			Vector3 theScale = transform.localScale;
			theScale.x = -2;
			transform.localScale = theScale;
		}else{
			Vector3 theScale = transform.localScale;
			theScale.x = 2;
			transform.localScale = theScale;
		}

		/*horizontalMove = Input.GetAxisRaw("Horizontal") * walkSpeed;
		verticalMove = Input.GetAxisRaw("Vertical") * walkSpeed;
			
		if (Input.GetKey(LA)){
			Vector3 theScale = transform.localScale;
			theScale.x = -2;
			transform.localScale = theScale;
		}else{
			Vector3 theScale = transform.localScale;
			theScale.x = 2;
			transform.localScale = theScale;
		}*/
	}
	void FixedUpdate ()
	{
		Move = new Vector2(horizontalMove, verticalMove);
		_rigidBody.MovePosition(_rigidBody.position + Move * Time.fixedDeltaTime);
		if (crouch){
			runSpeed *= crouchSpeed;
			if (m_CrouchDisableCollider != null)m_CrouchDisableCollider.enabled = false;
		}
		if (Logs >= MaxLogs) SceneManager.LoadScene(2);
		if (PlusHP) HP += 0.03f;
		else HP -= 0.01f;

		if (HP >= 100) HP = 100f;	
	}
	void OnTriggerEnter2D(Collider2D other){
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
	}
	public void SRun(){
		walkSpeed *= runSpeed;
	}
	public void SUnnRun(){
		walkSpeed /= runSpeed;
	}
	public void SAttack(){
		Attack.Play();
	}
}