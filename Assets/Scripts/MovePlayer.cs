using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour {


    public Transform player;
    public GameObject LifeGameObject;
    private Vector3 mousePos;
    public static List<GameObject> life;
    public GameObject pizza;
    public static Transform _pizza;
    

    public Text score;
    public Text comboScore;
    private int countComboScore;
    private bool gameOver = false;

    private bool flipRight;
    private Animator animator;

    private int countTomato;
    private int countMash;



    public static bool roundEnd;
  

    public static List<GameObject> ingridientList;
    

    //Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    [SerializeField]
    private float speed = 5f;


    void Awake()
    {
        life = new List<GameObject>();
        _pizza = pizza.transform;
      
        life.Add(Instantiate(LifeGameObject, new Vector2(score.transform.position.x+0.3f, 3f), Quaternion.identity));
        life.Add(Instantiate(LifeGameObject, new Vector2(score.transform.position.x + 0.3f, 2f), Quaternion.identity));
        life.Add(Instantiate(LifeGameObject, new Vector2(score.transform.position.x + 0.3f, 1f), Quaternion.identity));

    }

    void Start()
    {
        animator = player.GetComponent<Animator>();
        ingridientList = new List<GameObject>();
 
    }


    void verifyCombo()
    {

        if (countTomato == 2)
        {
            comboScore.text = "Сombo \n Margarita X2 ";
            countComboScore = countComboScore * 2;
        }
        else
        {
            
        }

        MoveIngridient.scoreCount += countComboScore;
        countTomato = 0;
        countMash = 0;
        countComboScore = 0;

    }



    void Update()
    {
        
        score.text = "Score: \n" + MoveIngridient.scoreCount;
        if (ingridientList.Count == 1)
        {
          comboScore.text = "";
        }
        

        if (ingridientList.Count==5)
        {
          for (int i = 0; i < ingridientList.Count; i++)
            {
      
           switch (ingridientList[i].tag)
           {
               case "Tomato":
                   countComboScore += 10;
                   countTomato++;        
                   break;
               case "Mashroms":
                   countComboScore += 10;
                   countMash++;
                   break;
               default:
                   break;
           }

                ingridientList[i].GetComponent<MoveIngridient>().pizzaDone = true;
      
            }
            ingridientList.Clear();
            verifyCombo();
        }

        if (life.Count==0)
        {
            gameOver = true;
           player.GetComponent<Animator>().SetTrigger("die");
        }


        if (gameOver)
        {
            MoveIngridient.scoreCount = 0;
            
        }

   }

    
    
    void OnMouseDown()
    {
        animator.SetBool("walk",true);
       
    }

    void OnMouseUp()
    {
        animator.SetBool("walk", false);
    }

    
    private void OnMouseDrag()
    {
        
       
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.x = mousePos.x > 5f ? 5f : mousePos.x;
        mousePos.x = mousePos.x < -5f ? -5f : mousePos.x;
        player.position = Vector2.MoveTowards(player.position,
            new Vector2(mousePos.x, player.position.y),
            speed * Time.deltaTime);

     //   animator.SetFloat("Speed",speed);

        if (mousePos.x > player.position.x || mousePos.x > 0)
        {
            flipRight = false;
        }
        else
        {
            flipRight = true;
        }
        Flip();

    }






    private void Flip()
    {
        
        if (player.localScale.x > 0 && !flipRight )
        {
            Vector3 theScale = player.localScale;
            theScale.x *= -1;
            player.localScale = theScale;
        }

        if (player.localScale.x < 0 && flipRight)
        {
            Vector3 theScale = player.localScale;
            theScale.x *= -1;
            player.localScale = theScale;
        }


    }


}
