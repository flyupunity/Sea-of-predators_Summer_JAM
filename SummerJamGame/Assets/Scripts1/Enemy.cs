using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
	public int i;
	public Transform[] Points;
	public bool Player = false;

	public float Speed;
	public Transform PlayerT;
	public GameObject I;

	public float HP;
	public float MaxHP;
	public float Damege;

	public float SDamege;
	public float PDamege;
	public Slider HPSlider;

	void Awake(){
		Player = false;
	}

	/*public void Attack(){
		HP -= 3;
	}*/
	void FixedUpdate (){
		HPSlider.maxValue = MaxHP;
		HPSlider.value = HP;
		PlayerT = GameObject.FindGameObjectWithTag("Player").transform;
		if (HP <= 0) Destroy(I);

		if(Player == true){
			transform.position = Vector2.MoveTowards(transform.position, PlayerT.position, Time.deltaTime * Speed);
		}
		if(Player == false){
			transform.position = Vector2.MoveTowards(transform.position, Points[i].position, Time.deltaTime * Speed);
			if(transform.position == Points[i].position) i ++;
			if(i == Points.Length) i = 0;
		}
		if(Vector2.Distance(transform.position, PlayerT.position) <= 7) Player = true;
		if(Vector2.Distance(transform.position, PlayerT.position) <= SDamege) PlayerT.gameObject.GetComponent<PlayerMovement>().HP -= Damege;
		if(Vector2.Distance(transform.position, PlayerT.position) <= PDamege) if (Input.GetKeyDown(KeyCode.R)) HP -= 3;
	}
}
