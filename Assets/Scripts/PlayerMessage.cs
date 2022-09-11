using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMessage : MonoBehaviour
{

    float timeToStopShowing = 2f;
    bool showMessage = false;
    public TextMeshPro _text;

    public static PlayerMessage Instance;

    private void Start()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;
    }

    private void Update()
    {
        if(showMessage && !(_text.gameObject.activeSelf))
        {
            _text.gameObject.SetActive(true);
        } else if (!showMessage && _text.gameObject.activeSelf)
        {
            _text.gameObject.SetActive(false);
        }
    }

    public void SetMessage(string msg)
    {
        _text.text = msg;
    }

    public void ShowMessage(bool condition)
    {
        showMessage = condition;
    }




}
