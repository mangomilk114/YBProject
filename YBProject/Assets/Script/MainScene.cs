using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{
    public UIMainMenu MainMenu;
    public UISetting Setting;
    public MsgPopup MsgPopupView;
    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        MsgPopupView.gameObject.SetActive(false);
        ViewMainMenu();

        YBProjectMgr.Instance.mMainScene = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameStart()
    {
        MainMenu.gameObject.SetActive(false);
        Setting.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        ViewMainMenu();
    }

    public void ViewMainMenu()
    {
        MainMenu.gameObject.SetActive(true);
        Setting.gameObject.SetActive(false);
    }

    public void ViewSetting()
    {
        MainMenu.gameObject.SetActive(false);
        Setting.gameObject.SetActive(true);
        Setting.SettingLoad_Default();
    }

    public void ViewMsgPopup(string msg)
    {
        MsgPopupView.gameObject.SetActive(true);
        MsgPopupView.SetData(msg);
    }
}
