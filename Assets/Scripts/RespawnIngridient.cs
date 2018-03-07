using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnIngridient : MonoBehaviour {

    public GameObject TomatoGameObject;
    public GameObject MashromGameObjectObject;
    public GameObject SpiderObjectObject;

    [SerializeField]
    public float leftSide = -5.5f;
    [SerializeField]
    public float rightSide= 5.5f;
    [SerializeField]
    public float hightPointRespown = 5f;

    [SerializeField]
    public float delayForRespown = 0.1f;

    void Start()
    {
        StartCoroutine(Spawn());
        StartCoroutine(SpawnSpider());

    }

    IEnumerator Spawn()
    {
        while (true)
        {

        //    Instantiate(SpiderObjectObject, new Vector2(Random.Range(leftSide, rightSide), hightPointRespown), Quaternion.identity);
         //   yield return new WaitForSecondsRealtime(Random.Range(2f, 3f));

            Instantiate(MashromGameObjectObject, new Vector2(Random.Range(leftSide, rightSide), hightPointRespown), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(2f, 3f));

            Instantiate(TomatoGameObject, new Vector2(Random.Range(leftSide, rightSide), hightPointRespown), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(1f,2f));
        }
    }


    IEnumerator SpawnSpider()
    {
        while (true)
        {

            Instantiate(SpiderObjectObject, new Vector2(Random.Range(leftSide, rightSide), hightPointRespown), Quaternion.identity);
            yield return new WaitForSecondsRealtime(Random.Range(2f, 3f));
       
        }
    }
}
