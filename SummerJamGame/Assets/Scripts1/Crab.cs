using UnityEngine;

public class Crab : MonoBehaviour
{
	public float Speed;
	public Transform PlayerT;

	void FixedUpdate (){
		PlayerT = GameObject.FindGameObjectWithTag("Player").transform;
		if(Vector2.Distance(transform.position, PlayerT.position) <= 5) transform.position = Vector2.MoveTowards(transform.position, PlayerT.position, Time.deltaTime * Speed * -1);
	}
}
