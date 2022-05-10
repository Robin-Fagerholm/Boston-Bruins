using UnityEngine;
using UnityEngine.UI;

public class ShowNotification : MonoBehaviour
{

    public Image Notification;
    public float coolDown = 180f;
    public Animator NotificationAnim;


    public void NotificationEnabled()
    {
        NotificationAnim.Play("Notification");
        Notification.enabled = true;
    }

    public void StartTimer()
    {
        Invoke("NotificationEnabled", coolDown);
    }

    public void ResetTimer()
    {
        Invoke("StartTimer", 300);
    }
    // Start is called before the first frame update
    void Start()
    {
        Notification.enabled = false;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
