using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Economyscript : MonoBehaviour {

    private Animator PierAnimator;
    private int PeopleOnBoard;
    private int PeopleWaiting;
    private int PeopleDestination;
    private int SpaceLeft;
    private int PeopleBoarding;
    private int PeopleLeft;
    private float Coins;

    public Text OnBoardCount;
    public Text CoinCount;

    public GameObject Waiting2;
    public GameObject Waiting3;
    public GameObject Waiting4;
    public GameObject Waiting1;

    public GameObject Leaving1;
    public GameObject Leaving2;
    public GameObject Leaving3;
    public GameObject Leaving4;



    void Start() {
        PierAnimator = GetComponent<Animator>();
        
    }

    void Update(){
        PeopleOnBoard = PierAnimator.GetInteger("PeopleOnBoard");
        PeopleWaiting = PierAnimator.GetInteger("PeopleWaiting");
        PeopleDestination = PierAnimator.GetInteger("PeopleDestination");

        OnBoardCount.text = PeopleOnBoard.ToString();
        CoinCount.text = (Coins.ToString());
    }

    void Reset() {
        Waiting4.SetActive(true);
        Waiting3.SetActive(true);
        Waiting2.SetActive(true);
        Waiting1.SetActive(true);

        Leaving1.SetActive(true);
        Leaving2.SetActive(true);
        Leaving3.SetActive(true);
        Leaving4.SetActive(true);
    }

    void AddtoBoat() {
        PierAnimator.SetInteger("PeopleOnBoard", PeopleOnBoard + 1);
        PeopleOnBoard = PeopleOnBoard + 1;
        PierAnimator.SetInteger("PeopleWaiting", PeopleWaiting - 1);
        PeopleWaiting = PeopleWaiting - 1;
        Coins = Coins + Mathf.Round(Random.Range(5f, 15f));

    }

    void SubtractfromBoat() {
        if (PeopleDestination > 0) {
            PierAnimator.SetInteger("PeopleDestination", PeopleDestination - 1);
            PeopleDestination = PeopleDestination - 1;
            PierAnimator.SetInteger("PeopleOnBoard", PeopleOnBoard - 1);
            PeopleOnBoard = PeopleOnBoard - 1;
        }

    }

    void CheckBefore()
    {
        SpaceLeft = 5 - (PeopleOnBoard - PeopleDestination);
        PeopleLeft = (PeopleWaiting - SpaceLeft);
        if (PeopleLeft < 0) { PeopleLeft = 0; }
        PeopleBoarding = (PeopleWaiting - (PeopleLeft));
        Debug.Log(PeopleBoarding);

        if (PeopleWaiting == 3)
        {
            Waiting2.SetActive(false);
        }
        if (PeopleWaiting == 2)
        {
            Waiting4.SetActive(false);
            Waiting2.SetActive(false);
        }
        if (PeopleWaiting == 1)
        {
            Waiting4.SetActive(false);
            Waiting3.SetActive(false);
            Waiting2.SetActive(false);


        }
        if (PeopleDestination == 3)
        {
            Leaving4.SetActive(false);
        }
        if (PeopleDestination == 2)
        {
            Leaving4.SetActive(false);
            Leaving3.SetActive(false);
        }
        if (PeopleDestination == 1)
        {
            Leaving4.SetActive(false);
            Leaving3.SetActive(false);
            Leaving2.SetActive(false);
        }
    }

    void CheckAfter()
    {
        if (PeopleBoarding == 1)
        {
            Waiting1.SetActive(false);
        }
        if (PeopleBoarding == 2)
        {
            Waiting1.SetActive(false);
            Waiting3.SetActive(false);
        }
        if (PeopleBoarding == 3)
        {
            Waiting1.SetActive(false);
            Waiting3.SetActive(false);
            Waiting4.SetActive(false);
        }
    }
}
