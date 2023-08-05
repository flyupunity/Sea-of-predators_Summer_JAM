using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URPForest : MonoBehaviour
{
    public GameObject VolumeGlobal;
    public GameObject VolumeLocal;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Global>(out Global Global)){ 
	    VolumeLocal.SetActive(true);
	    VolumeGlobal.SetActive(false);
        }
    }
    public void OnTriggerOver2D(Collider other){
        if (other.TryGetComponent<Global>(out Global Global)){ 
	   VolumeGlobal.SetActive(true);
	   VolumeLocal.SetActive(false);
        }
    }
}
