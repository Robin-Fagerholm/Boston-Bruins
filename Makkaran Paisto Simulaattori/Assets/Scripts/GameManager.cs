using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject fire;
    public bool isGameActive;
    // Start is called before the first frame update
    void Start()
    {
        titleScreen.gameObject.SetActive(true);
        fire.gameObject.SetActive(false);
        isGameActive = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        titleScreen.gameObject.SetActive(false);
        isGameActive = true;
        fire.gameObject.SetActive(true);
    }
}
