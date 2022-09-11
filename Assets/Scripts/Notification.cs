using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notification : MonoBehaviour
{
    [SerializeField] GameObject currentNotification;
    public static Notification Instance { get; private set; }
    public GameObject notification;
    GameObject notis;
    private void OnEnable()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        Instance = this;
        notis = GameObject.Find("notifications");
        SendNotification(true, "Hello, test");
    }

    public void SendNotification(bool positive, string message)
    {
        if (currentNotification != null)
        {
            if (currentNotification.GetComponent<NotificationObject>().mtext.text == message)
                return;
        }

        currentNotification = Instantiate(notification);
        currentNotification.transform.SetParent(notis.transform);
        currentNotification.GetComponent<NotificationObject>().ChangeText(message);
        currentNotification.GetComponent<NotificationObject>().ChangeType(positive);
    }
}
