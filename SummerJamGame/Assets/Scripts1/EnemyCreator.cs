using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
	public Transform PlayerT;

	public GameObject Enemy1;
	public GameObject Enemy2;
	public GameObject Enemy3;

	public Transform Point1;
	public Transform Point2;
	public Vector2 Position;

	public float Timer1;
	public float Timer2;
	public float Timer3;

	public float MaxTimer1;
	public float MaxTimer2;
	public float MaxTimer3;

	void FixedUpdate()
	{
		Position = new Vector2(Random.Range(Point1.position.x, Point2.position.x), Random.Range(Point1.position.y, Point2.position.y));

		if(Timer1 > 0) Timer1 --;
		if(Timer2 > 0) Timer2 --;
		if(Timer3 > 0) Timer3 --;

		if(Timer1 <= 0){
			GameObject newEnemy1 = Instantiate(Enemy1, Position, transform.rotation);
			Timer1 = MaxTimer1 * 50;
		}

		if(Timer2 <= 0){
			GameObject newEnemy2 = Instantiate(Enemy2, Position, transform.rotation);
			Timer2 = MaxTimer2 * 50;
		}

		if(Timer3 <= 0){
			GameObject newEnemy3 = Instantiate(Enemy3, Position, transform.rotation);
			Timer3 = MaxTimer3 * 50;
		}
	}
}
