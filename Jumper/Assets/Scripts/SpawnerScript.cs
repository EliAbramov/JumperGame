using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

    public GameObject knife;

    private float max_Y = 4.5f, min_Y = -3f;
 
    void Start()
    {
        StartCoroutine(StartSpawning());
    } 

    IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(Random.Range(1f, 4f));

        GameObject knifeClone = Instantiate(knife);

        float y = Random.Range(min_Y, max_Y);

        knifeClone.transform.position = new Vector2(transform.position.x, y);

        // Coroutine call itself to spawn knifes 
        StartCoroutine(StartSpawning());
    }

}
