using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mapbutton : MonoBehaviour {

    public Animator Anim;
    public Button mapbutton;

	// Use this for initialization
	void Start () {
        Button button = mapbutton.GetComponent<Button>();
        button.onClick.AddListener(togglemap);
    }
	void togglemap () {
        Anim.SetTrigger("OpenMap");
		
	}
}
