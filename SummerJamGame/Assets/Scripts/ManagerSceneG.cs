using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerSceneG : MonoBehaviour
{
	public void Game(int Scene)
	{
		SceneManager.LoadScene(Scene);
	}
}
