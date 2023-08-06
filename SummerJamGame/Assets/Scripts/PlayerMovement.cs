 using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	public float walkSpeed = 30f;

	public float horizontalMove;
	public float verticalMove;

	public Vector2 Move; 

	private Rigidbody2D _rigidBody; 
	public AudioSource Attack;

	public Sprite[] energyStart;
    public Sprite[] energy;
    public Sprite[] energyEnd;

    private Animator anim;

    void Awake(){
		_rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update() {

        horizontalMove = Input.GetAxisRaw("Horizontal") * walkSpeed;
        verticalMove = Input.GetAxisRaw("Vertical") * walkSpeed;

        if (Input.GetAxisRaw("Horizontal") < 0) transform.rotation = transform.GetChild(1).localRotation;
        if (Input.GetAxisRaw("Horizontal") > 0) transform.rotation = transform.GetChild(2).localRotation;
        if (Input.GetAxisRaw("Horizontal") == 0) transform.rotation = Quaternion.identity;

        Move = new Vector2(horizontalMove, verticalMove);
        _rigidBody.MovePosition(_rigidBody.position + Move * Time.deltaTime);

        if (!Input.GetMouseButton(0) && !anim.GetCurrentAnimatorStateInfo(0).IsName("UpScale"))
        {
            //anim.Play("Idle");
            anim.SetBool("Idle", true);
        }
        else if (Input.GetMouseButton(0) && !anim.GetCurrentAnimatorStateInfo(0).IsName("UpScale"))
        {
            anim.SetBool("Idle", false);
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("PowerTime")) anim.Play("PowerTime");

        }
        else if (Input.GetMouseButtonUp(0) && !anim.GetCurrentAnimatorStateInfo(0).IsName("UpScale"))
        {
            //anim.Play("Idle");
            anim.SetBool("Idle", true);
        }
    }
	/*IEnumerator StartEnergy(float timer)
	{
        yield return new WaitForSeconds(timer);
        GetComponent<SpriteRenderer>().sprite = energyStart[0];
        yield return new WaitForSeconds(timer);
        GetComponent<SpriteRenderer>().sprite = energyStart[1];
        yield return new WaitForSeconds(timer);
        GetComponent<SpriteRenderer>().sprite = energyStart[2];

    }*/

    void OnTriggerEnter2D(Collider2D other){
		if (other.GetComponent<Turtle>()){
			GameOver();
        }
        if (other.gameObject.GetComponent<Fish>() && Input.GetMouseButton(0))
        {
            anim.Play("UpScale");
            other.gameObject.SetActive(false);
        }

    }
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.GetComponent<Turtle>()){
			GameOver();
        }
        if (other.gameObject.GetComponent<Fish>() && Input.GetMouseButton(0))
        {
            anim.Play("UpScale");
            other.gameObject.SetActive(false);
        }
    }
	public void GameOver()
	{

	}
    public void SetScale(float scale)
    {
        transform.localScale = new Vector3(transform.localScale.x * scale, transform.localScale.y * scale, transform.localScale.x * scale);
    }
}