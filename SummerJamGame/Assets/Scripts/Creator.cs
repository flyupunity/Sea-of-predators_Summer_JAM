using UnityEngine;

public class Creator : MonoBehaviour
{
	public GameObject Turtle;
	public GameObject Fish;

    public float turtleScale;
    public float fishScale;

    void Start()
	{
        int num0 = Random.Range(2, 5);
        for (int i = 0; i < num0; i++)
        {
            GameObject newTurtle = Instantiate(Turtle, new Vector2(0, 0), Quaternion.identity);
            newTurtle.transform.GetChild(0).transform.position = new Vector2(Random.Range(-16f, 25), Random.Range(-3f, 30f));
            newTurtle.transform.GetChild(1).transform.position = new Vector2(Random.Range(-16f, 25), Random.Range(-3f, 30f));
            newTurtle.transform.GetChild(0).name = i + "";
            newTurtle.transform.GetChild(1).name = i + "";
            newTurtle.transform.GetChild(0).transform.localScale = new Vector3(turtleScale, turtleScale, turtleScale);
            newTurtle.transform.GetChild(1).transform.localScale = new Vector3(turtleScale, turtleScale, turtleScale);
        }
        int num1 = Random.Range(20, 30);
        for (int i = 0; i <= num1; i ++) 
		{
			GameObject newFish = Instantiate(Fish, new Vector2(0,0), Quaternion.identity);
			newFish.transform.GetChild(0).transform.position = new Vector2(Random.Range(-16f, 25), Random.Range(-3f, 30f));
            newFish.transform.GetChild(1).transform.position = new Vector2(Random.Range(-16f, 25), Random.Range(-3f, 30f));
            newFish.transform.GetChild(0).name = i + "";
            newFish.transform.GetChild(1).name = i + "";
            newFish.transform.GetChild(0).transform.localScale = new Vector3(fishScale, fishScale, fishScale);
            newFish.transform.GetChild(1).transform.localScale = new Vector3(fishScale, fishScale, fishScale);
            //Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());
        }
	}
}
