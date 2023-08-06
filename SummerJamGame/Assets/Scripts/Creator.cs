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
        Collider2D[] turtles = new Collider2D[num0];

        for (int i = 0; i < num0; i++)
        {
            GameObject newTurtle = Instantiate(Turtle, new Vector2(0, 0), Quaternion.identity);
            newTurtle.transform.GetChild(0).transform.position = new Vector2(Random.Range(-16f, 25), Random.Range(-3f, 30f));
            newTurtle.transform.GetChild(1).transform.position = new Vector2(Random.Range(-16f, 25), Random.Range(-3f, 30f));
            newTurtle.transform.GetChild(0).name = i + "";
            newTurtle.transform.GetChild(1).name = i + "";
            newTurtle.transform.GetChild(0).transform.localScale = new Vector3(turtleScale, turtleScale, turtleScale);
            newTurtle.transform.GetChild(1).transform.localScale = new Vector3(turtleScale, turtleScale, turtleScale);
            turtles[i] = newTurtle.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Collider2D>();
            print("turtles");
        }
        int num1 = Random.Range(20, 30);
        Collider2D[] fishes = new Collider2D[num1];

        for (int i = 0; i <= num1; i++)
        {
            GameObject newFish = Instantiate(Fish, new Vector2(0, 0), Quaternion.identity);
            newFish.transform.GetChild(0).transform.position = new Vector2(Random.Range(-16f, 25), Random.Range(-3f, 30f));
            newFish.transform.GetChild(1).transform.position = new Vector2(Random.Range(-16f, 25), Random.Range(-3f, 30f));
            newFish.transform.GetChild(0).name = i + "";
            newFish.transform.GetChild(1).name = i + "";
            newFish.transform.GetChild(0).transform.localScale = new Vector3(fishScale, fishScale, fishScale);
            newFish.transform.GetChild(1).transform.localScale = new Vector3(fishScale, fishScale, fishScale);
            print(newFish.transform.GetChild(0).gameObject);
            fishes[i] = newFish.transform.GetChild(0).gameObject.GetComponent<Collider2D>();
            //Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());
            for (int y = 0; y < num0; y++)
            {
                Physics2D.IgnoreCollision(fishes[i], turtles[y]);
                print(i);
            }
        }
    }
}
