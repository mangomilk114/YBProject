using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    public Button StartButton;
    public Button SettingButton;

    private void Awake()
    {
        StartButton.onClick.AddListener(onClickStart);
        SettingButton.onClick.AddListener(onClickSetting);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickStart()
    {
        YBProjectMgr.Instance.GameReady();
        YBProjectMgr.Instance.GameStart();
    }

    public void onClickSetting()
    {
        YBProjectMgr.Instance.mMainScene.ViewSetting();
    }
}
