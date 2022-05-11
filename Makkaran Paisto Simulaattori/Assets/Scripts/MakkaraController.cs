using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MakkaraController : MonoBehaviour
{
    private bool isBeingCooked;
    public int grillState;
    // grillState 0-3
    private int coockingRate = 5;
    private GameManager gameManager;

    public Animator GrillStateAnim;

    // Manages Points
    public int points;
    public Text pointsText;
    
    private Vector3 mousePosition;
    public float moveSpeed = 1.1f;
    private bool beingMoved = false;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        pointsText.enabled = false;
    //rb2d = GetComponent<Rigidbody2D>();
    isBeingCooked = false;
        grillState = 0;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = "Points: " + points;

        if (gameManager.isGameActive && beingMoved){
            mousePosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        }
        else if (gameManager.isGameActive && !beingMoved && collisions == 0)
        {
            //rb2d.gravityScale = 1;
        }
        else
        {
            //rb2d.gravityScale = 0;
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
    public int collisions = 0;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Notch")
        {
            GrillStateAnim.Play("GrillState");
            pointsText.enabled = true;
            points += 1;
            //Grillaus ääni päälle
            isBeingCooked = true;
            StartCoroutine(CoockingTimer());
            grillState = 1;
        }
        if (other.tag != "Makkara")
        {
            collisions++;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Notch")
        {
            StopCoroutine(CoockingTimer());
            GrillStateAnim.StopPlayback();
        }
        if (other.tag != "Makkara")
        {
            collisions--;
        }
    }
}