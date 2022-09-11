using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotificationObject : MonoBehaviour
{
    float timeToWait = 3f;
    public float currentTime = 0f;
    public TextMeshProUGUI mtext;

    public Image type;

    public Sprite positiveSprite;
    public Sprite negativeSprite;

    CanvasGroup cg;

    // Start is called before the first frame update
    void Start()
    {
        type = GetComponentInChildren<Image>();
        StartCoroutine("DestroyThisAfter5Seconds", 5f);
        cg = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    { 
        currentTime += Time.deltaTime;

        if(currentTime > timeToWait)
        {
            cg.alpha -= Time.deltaTime * 2;
        }
        
    }

    public void ChangeText(string messagey)
    {
       mtext.text = messagey;
    }

    public void ChangeType(bool positive)
    {
        if (positive)
        {
            type.sprite = positiveSprite;
        }
        else if (!positive)
        {
            type.sprite = negativeSprite;
        }
    }

    public void DestroyThis()
    {
        Destroy(gameObject);
    }

    IEnumerator DestroyThisAfter5Seconds()
    {
        yield return new WaitForSeconds(5);
        
        
        Destroy(gameObject);
    }
}
