using UnityEngine;
using UnityEngine.UI;

public class Plot : MonoBehaviour
{
	public string Name;
	public string Plon;

	public string PSeaWall = "I can't sail - I need a raft";
	public string P_aircraftF = "What, seems to be my plane!!!";
	public string Enemy = "What are these terrible monsters?";

	public Text NameText;
	public Text PlotText;
	public Transform List;

	public GameObject Panel;
	public GameObject ObjectLearn;
	public GameObject Fire_Axe;

	void Awake()
	{
		//Panel.SetActive(false);
		ObjectLearn.SetActive(false);
	}

	void Update()
	{
		NameText.text = Name;
		PlotText.text = Plon;

		if(Vector2.Distance(transform.position, List.position) <= 0.3) ObjectLearn.SetActive(true);
		else ObjectLearn.SetActive(false);
		if(Vector2.Distance(transform.position, Fire_Axe.transform.position) <= 0.3) Fire_Axe.SetActive(false);
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.GetComponent<Enemy>()){ 
			Panel.SetActive(true);
			Name = "I";
			Plon = Enemy + "";
		}
	}
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.GetComponent<aircraftF>()){ 
			Panel.SetActive(true);
			Name = "I";
			Plon = P_aircraftF + "";
		}
		if (other.gameObject.GetComponent<SeaWall>()){ 
			Panel.SetActive(true);
			Name = "I";
			Plon = PSeaWall + "";
		}
		if (other.gameObject.GetComponent<Enemy>()){ 
			Panel.SetActive(true);
			Name = "I";
			Plon = Enemy + "";
		}
	}
}
