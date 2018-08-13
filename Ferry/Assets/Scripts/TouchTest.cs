using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTest : MonoBehaviour {
    
	void Start () {
		
	}
	
	void Update () {

        if (Input.touchCount > 0)
        {
            Debug.Log(Input.GetTouch(0).position);
        }

        
	}
}
