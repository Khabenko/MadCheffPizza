using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour {

	// Use this for initialization
    public Image image;
    public Text text;
    private float timeLeft = 30f;
    private float timerIncriment;

    void Start ()
    {
       
        timerIncriment = 1/(timeLeft / 360f);
     


    }
	
	// Update is called once per frame
	void Update ()
	{
	    image.fillAmount -= 0.0005555f;
	    timeLeft -= Time.deltaTime;
	    Debug.Log(timeLeft);
        if (timeLeft < 0)
	    {
           
	        MovePlayer.roundEnd = true;
	    }

    }
}
