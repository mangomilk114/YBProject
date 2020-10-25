using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{
    public Button StartButon;
    private void Awake()
    {
        StartButon.onClick.AddListener(() =>
        {
            YBProjectMgr.Instance.GameReady();
            YBProjectMgr.Instance.GameStart();
        });
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
