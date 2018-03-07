using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveIngridient : MonoBehaviour {

    [SerializeField]
    public float speed = 3f;

    public static int scoreCount;
    private bool slised;
    private Vector3 _destinationPosition;
    private Vector3 _destinationPositionPizzaDone;
    public bool pizzaDone;
    
  

    // Use this for initialization
    void Start()
    {
           _destinationPositionPizzaDone = new Vector3(MovePlayer._pizza.transform.position.x, MovePlayer._pizza.position.y+5, 0);
      //  _destinationPositionPizzaDone = MovePlayer._pizza.transform.position;

    }


    void lookfor()
    {
        slised = true;
        speed = 0;
    }

   void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.tag == "Chef"  && transform.gameObject.tag != "Spider"&& !MovePlayer.ingridientList.Contains(gameObject))
        {
            other.gameObject.GetComponent<Animator>().SetTrigger("attak");
   
            switch (transform.gameObject.tag)
            {
                case "Tomato":
                    transform.GetComponent<Animator>().SetTrigger("slice");               
                    MovePlayer.ingridientList.Add(transform.gameObject);
                    _destinationPosition = new Vector3(MovePlayer._pizza.position.x, MovePlayer.ingridientList.Count * 0.7f, 0);
                    break;
                case "Mashroms":
                    transform.GetComponent<Animator>().SetTrigger("Mashrom_slice");             
                    MovePlayer.ingridientList.Add(transform.gameObject);
                    _destinationPosition = new Vector3(MovePlayer._pizza.position.x, MovePlayer.ingridientList.Count * 0.7f, 0);
                    break;
                default:
             break;          
            }
        }


       


        if (other.gameObject.tag == "Pizza")
        {
            Destroy(gameObject);
        }


        if (other.gameObject.tag == "Chef" && transform.gameObject.tag == "Spider")
        {
           other.GetComponent<Animator>().SetTrigger("hit");

            if (MovePlayer.life.Count > 0)
            {
               // Destroy(gameObject);
                speed = speed * -1;
                Destroy(MovePlayer.life[MovePlayer.life.Count - 1]);
                MovePlayer.life.RemoveAt(MovePlayer.life.Count - 1);
                   
            }

        }
    
    }





    // Update is called once per frame
    void Update()
    {
        
       

        if (slised)
        { 
            transform.position = Vector3.Lerp(transform.position, _destinationPosition, 2 * Time.deltaTime);
           
        }


        if (pizzaDone)
        {

            if (transform.position.x > MovePlayer._pizza.position.x-1f)
            {
                transform.position = Vector3.Lerp(transform.position, _destinationPositionPizzaDone, 2 * Time.deltaTime);
            }
            else
            {
                _destinationPositionPizzaDone = new Vector3(MovePlayer._pizza.transform.position.x, MovePlayer._pizza.position.y, 0);
                transform.position = Vector3.Lerp(transform.position, _destinationPositionPizzaDone, 2 * Time.deltaTime);
            }
         
   
        }

  


        if (transform.position.y < -6f || transform.position.y > 6f)
        {
          
            Destroy(gameObject);
        }

        if (transform.position.y < -3f && transform.gameObject.tag == "Spider")
        {
            speed = speed * -1;
        }

        transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
    }
}
