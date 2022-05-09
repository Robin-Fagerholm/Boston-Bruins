using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakkaraController : MonoBehaviour
{
    private bool isBeingCooked;
    public int grillState;
    // grillState 0-3
    private int coockingRate = 10;
    private GameManager gameManager;
    
    private Vector3 mousePosition;
    public float moveSpeed = 1.1f;
    private bool beingMoved = false;

    // Start is called before the first frame update
    void Start()
    {
        isBeingCooked = false;
        grillState = 0;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive && beingMoved){
            mousePosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        }
    }
    void OnMouseDown(){
        if (gameManager.isGameActive){
            beingMoved = true;
        }
    }
    void OnMouseUp(){
        if (gameManager.isGameActive){
            beingMoved = false;
        }
    }
    void FollowMouse(){
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
    }
    IEnumerator CoockingTimer(){
        while(isBeingCooked){
            yield return new WaitForSeconds(coockingRate);
            //Vaihda seuraavaan vaiheeseen.
            if (grillState == 3){
                yield break;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Fire"){
            //Grillaus ääni päälle
            StartCoroutine(CoockingTimer());
            grillState = 1;
        }
    }
    void OnTriggerExit2D(Collider2D other){
        if (other.tag == "Fire"){
            StopCoroutine(CoockingTimer());
        }
    }
}
