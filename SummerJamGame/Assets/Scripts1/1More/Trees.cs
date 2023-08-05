using UnityEngine;
using UnityEngine.UI;

public class Trees : MonoBehaviour
{
	public float HP = 10;
	public Slider Slider;
	public Transform PlayerT;

	public float Timer;
	public SpriteRenderer Tree;
	public GameObject Log;

	public GameObject Canvas;
	public AudioSource Wood;


	void Awake(){
		HP = 10;
		Tree.enabled = true;
		Log.SetActive(false);
		Canvas.SetActive(true);
	}
	void FixedUpdate (){
		Slider.value = HP;
		if(HP <= 0){
			Log.SetActive(true);
			Tree.enabled = false;
			Canvas.SetActive(false);
		}
 		if(Vector2.Distance(transform.position, PlayerT.position) <= 3) {
			if (Input.GetKeyDown(KeyCode.E)) Wood.Play();
			if (Input.GetKey(KeyCode.E)) {
				Timer++;
				if(Timer >= 10){
					HP -= 1;
					Timer = 0;
				}
			}else{
				if(Timer >= 1) Timer --;
			}
		}
	}
}
