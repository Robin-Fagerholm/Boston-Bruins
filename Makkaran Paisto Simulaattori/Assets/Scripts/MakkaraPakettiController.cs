using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakkaraPakettiController : MonoBehaviour
{
    public GameObject makkaraPrefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Makkara")
        {
            Instantiate(makkaraPrefab, transform.position, Quaternion.identity);
        }
    }
}
