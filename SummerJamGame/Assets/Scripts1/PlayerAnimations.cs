using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAnimations : MonoBehaviour
{
	public string AnimNameUp;
	public string AnimNameDown;
	public string AnimNameRotation;
	public string AnimNameIdle;

	public PlayerMovement PlayerMovement;

	private Animator Anim;

	void Awake(){
        	Anim = GetComponent<Animator>();
	}

	void Update(){
        	if(PlayerMovement.HP <= 0){
			Anim.SetBool(AnimNameUp, false);
			Anim.SetBool(AnimNameDown, false);
			Anim.SetBool(AnimNameIdle, false);
			Anim.SetBool(AnimNameRotation, false);
			Anim.SetBool("Over", true);
		}
        	if(PlayerMovement.HP > 0){
        		if(PlayerMovement.horizontalMove < PlayerMovement.verticalMove && PlayerMovement.verticalMove > 0){
				Anim.SetBool(AnimNameUp, true);
				Anim.SetBool(AnimNameDown, false);
				Anim.SetBool(AnimNameIdle, false);
				Anim.SetBool(AnimNameRotation, false);
			}else if(PlayerMovement.horizontalMove < PlayerMovement.verticalMove && PlayerMovement.verticalMove < 0 && PlayerMovement.horizontalMove < 0.9 && PlayerMovement.horizontalMove > -0.9){
				Anim.SetBool(AnimNameUp, false);
				Anim.SetBool(AnimNameDown, true);
				Anim.SetBool(AnimNameIdle, false);
				Anim.SetBool(AnimNameRotation, false);
			}else if(PlayerMovement.horizontalMove > PlayerMovement.verticalMove || PlayerMovement.horizontalMove > 0.9 || PlayerMovement.horizontalMove < -0.9)
			{
				Anim.SetBool(AnimNameUp, false);
				Anim.SetBool(AnimNameDown, false);
				Anim.SetBool(AnimNameIdle, false);
				Anim.SetBool(AnimNameRotation, true);
			}else{
				Anim.SetBool(AnimNameUp, false);
				Anim.SetBool(AnimNameDown, false);
				Anim.SetBool(AnimNameIdle, true);
				Anim.SetBool(AnimNameRotation, false);
			}
		}
	}
	public void Restart()
	{
		SceneManager.LoadScene(1);
	}
}
