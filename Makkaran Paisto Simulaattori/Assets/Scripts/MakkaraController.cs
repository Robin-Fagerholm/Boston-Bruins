using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakkaraController : MonoBehaviour
{
    public bool isBeingCooked;
    private int coockingRate = 10;
    // Start is called before the first frame update
    void Start()
    {
        isBeingCooked = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator CoockingTimer(){
        yield return new WaitForSeconds(coockingRate);
        //Vaihda seuraavaan vaiheeseen.
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Fire"){
            //Grillaus ääni päälle
            StartCoroutine(CoockingTimer());
        }
    }
}
