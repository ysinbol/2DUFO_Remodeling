using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMeteorite : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
        int childCount = transform.childCount;
        for(int i=0;i<childCount - 1;i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
	}
	
    void SpawnMeteorites()
    {

    }
}
