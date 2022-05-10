using UnityEngine;
using UnityEngine.UI;

public class OpenNotification : MonoBehaviour
{

    public Canvas NotificationMenu;
    // Start is called before the first frame update
    void Start()
    {
        NotificationMenu.enabled = false;
    }

    public void NotificationOpen()
    {
        if (Input.GetKey(KeyCode.M))
        {
            NotificationMenu.enabled = true;
            GetComponent<ShowNotification>().NotificationEnabled();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
