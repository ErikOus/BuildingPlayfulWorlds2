using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PierPoint : MonoBehaviour {

    public Animator PierAnim;
    public GameObject self;

    public int PeopleWaiting;
    public int PeopleLeave;

    public int PeopleLeaving;

    public GameObject Boat;
    BoatMotor BoatMotorScript;

    // Use this for initialization
    void Start () {
        BoatMotorScript = Boat.GetComponent<BoatMotor>();
    }

    void Update () {
        if (PeopleLeave > PierAnim.GetInteger("PeopleOnBoard")) {
            PeopleLeaving = PierAnim.GetInteger("PeopleOnBoard");
        }
        if (PeopleLeave <= PierAnim.GetInteger("PeopleOnBoard")) {
            PeopleLeaving = PeopleLeave;
        }
    }
	
	void OnTriggerEnter () {
        self.SetActive(false);
        PierAnim.SetTrigger("ArriveInArea");
        PierAnim.SetInteger("PeopleWaiting", PeopleWaiting);
        PierAnim.SetInteger("PeopleDestination", PeopleLeaving);
        BoatMotorScript.speed = 0f;
        BoatMotorScript.turnspeed = 0f;
		
	}
}
