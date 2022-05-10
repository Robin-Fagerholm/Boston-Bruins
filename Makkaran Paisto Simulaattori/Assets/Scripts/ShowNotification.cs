using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowNotification : MonoBehaviour
{


    public Image Notification;
    public float coolDown = 180f;
    public float coolDownReset = 300f;
    public Animator NotificationAnim;
    public float Notifications;

    public TextMeshPro AmountText;

    public float amount = 1;


    public void NotificationEnabled()
    {
        NotificationAnim.Play("Notification");
        Notification.enabled = true;
        Notifications += amount;
        AmountText.enabled = true;
    }

    public void StartTimer()
    {
        Invoke("NotificationEnabled", coolDown);
    }

    public void ResetTimer()
    {
        Invoke("StartTimer", coolDownReset);
    }
    // Start is called before the first frame update
    void Start()
    {
        Notification.enabled = false;
        AmountText.enabled = false;
    }


    public void Amount()
    {
        amount += Notifications;
    }

    // Update is called once per frame
    void Update()
    {
        AmountText.text = "Amount: " + amount;
    }
}
