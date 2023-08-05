using UnityEngine;
using UnityEngine.UI;

public class AudioVolume : MonoBehaviour
{
	public AudioSource AudioSourceBackGround;
	public AudioSource AudioSourceAttack;
	public AudioSource AudioSourceWood;

	public Slider SliderBackGroundVolume;
	public Slider SliderAttackVolume;
	public Slider SliderWoodVolume;

	public Slider SliderBackGroundPitch;
	public Slider SliderAttackPitch;
	public Slider SliderWoodPitch;

	void Update()
	{
        	AudioSourceBackGround.volume = SliderBackGroundVolume.value;
        	AudioSourceBackGround.pitch = SliderBackGroundPitch.value;

        	AudioSourceAttack.volume = SliderAttackVolume.value;
        	AudioSourceAttack.pitch = SliderAttackPitch.value;

        	AudioSourceWood.volume = SliderBackGroundVolume.value;
        	AudioSourceWood.pitch = SliderWoodPitch.value;
	}
}
