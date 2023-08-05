using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfAndroid : MonoBehaviour
{
	public GameObject[] Active;
	public GameObject[] NotActive;
//#if ANDROID 
	void Start(){
		for(int i = 0; i <= Active.Length - 1; i++){
			Active[i].SetActive(true);
            	}
		for(int i = 0; i <= NotActive.Length - 1; i++){
			NotActive[i].SetActive(false);
            	}
	}
//#endif
}