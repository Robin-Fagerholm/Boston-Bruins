using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject titleScreen;
    public bool isGameActive;
    // Start is called before the first frame update
    void Start()
    {
        isGameActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(){
        titleScreen.gameObject.SetActive(false);
        isGameActive = true;
    }
}
