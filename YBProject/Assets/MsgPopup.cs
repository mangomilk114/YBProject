using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MsgPopup : MonoBehaviour
{
    public Text Msg;
    public Button OkButton;

    private void Awake()
    {
        OkButton.onClick.AddListener(() =>
        {
            this.gameObject.SetActive(false);
        });
    }

    public void SetData(string msg)
    {
        Msg.text = msg;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
