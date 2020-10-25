using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISetting : MonoBehaviour
{
    public InputField PosWidth;
    public InputField PosHeight;
    public InputField JumpHeight;
    public InputField Speed;

    public List<Button> Setting_Button_List = new List<Button>();
    public List<GameObject> Setting_Obj_List = new List<GameObject>();

    public InputField Setting_1_Gap;
    public InputField Setting_1_Height_Max;
    public InputField Setting_1_Height_Min;
    public InputField Setting_1_Width_Max;
    public InputField Setting_1_Width_Min;

    public Button Back;
    public Button SaveBack;
    public Button Play;
    public Button Save;

    private int SettingIndex;

    private void Awake()
    {
        Back.onClick.AddListener(onClickBack);
        SaveBack.onClick.AddListener(onClickSaveBack);
        Play.onClick.AddListener(onClickPlay);
        Save.onClick.AddListener(onClickSave);

        Setting_Button_List[0].onClick.AddListener(() =>
        {
            onClickSettingObj(0);
        });
    }

    public void onClickBack()
    {
        YBProjectMgr.Instance.mMainScene.ViewMainMenu();
    }

    public void onClickSaveBack()
    {
        SettingSave();
        YBProjectMgr.Instance.mMainScene.ViewMainMenu();
    }

    public void onClickPlay()
    {

    }

    public void onClickSave()
    {
        SettingSave();
    }

    public void onClickSettingObj(int index)
    {
        if (SettingIndex == index)
            return;

        for (int i = 0; i < Setting_Obj_List.Count; i++)
        {
            if (i == index)
                Setting_Obj_List[i].gameObject.SetActive(true);
            else
                Setting_Obj_List[i].gameObject.SetActive(false);
        }

        SettingLoad(index);
    }

    public void SettingSave()
    {
        YBProjectMgr.Instance.BIRD_START_POS_X = ConvertStr(ref PosWidth) / 1000f;
        YBProjectMgr.Instance.BIRD_START_POS_Y = ConvertStr(ref PosHeight) / 1000f;
        YBProjectMgr.Instance.BIRD_JUMP_HEIGHT = ConvertStr(ref JumpHeight);
        YBProjectMgr.Instance.BIRD_JUMP_DOWN_SPEED = ConvertStr(ref Speed) / 1000f;
        YBProjectMgr.Instance.HURDLE_1_GAP_TIME = ConvertStr(ref Setting_1_Gap) / 1000f;
        YBProjectMgr.Instance.HURDLE_1_HEIGHT_MAX = ConvertStr(ref Setting_1_Height_Max) / 1000f;
        YBProjectMgr.Instance.HURDLE_1_HEIGHT_MIN = ConvertStr(ref Setting_1_Height_Min) / 1000f;
        YBProjectMgr.Instance.HURDLE_1_WIDTH_MAX = ConvertStr(ref Setting_1_Width_Max) / 1000f;
        YBProjectMgr.Instance.HURDLE_1_WIDTH_MIN = ConvertStr(ref Setting_1_Width_Min) / 1000f;
    }

    public void SettingLoad_Default()
    {
        PosWidth.text = "" + YBProjectMgr.Instance.BIRD_START_POS_X * 1000;
        PosHeight.text = "" + YBProjectMgr.Instance.BIRD_START_POS_Y * 1000;
        JumpHeight.text = "" + YBProjectMgr.Instance.BIRD_JUMP_HEIGHT;
        Speed.text = "" + YBProjectMgr.Instance.BIRD_BASE_SPEED * 1000;
        SettingIndex = -1;
    }

    public void SettingLoad(int index)
    {
        if(index == 0)
        {
            Setting_1_Gap.text = "" + YBProjectMgr.Instance.HURDLE_1_GAP_TIME * 1000;
            Setting_1_Height_Max.text = "" + YBProjectMgr.Instance.HURDLE_1_HEIGHT_MAX * 1000;
            Setting_1_Height_Min.text = "" + YBProjectMgr.Instance.HURDLE_1_HEIGHT_MIN * 1000;
            Setting_1_Width_Max.text = "" + YBProjectMgr.Instance.HURDLE_1_WIDTH_MAX * 1000;
            Setting_1_Width_Min.text = "" + YBProjectMgr.Instance.HURDLE_1_WIDTH_MIN * 1000;
        }
        
    }

    public int ConvertStr(ref InputField textInputField)
    {
        try
        {
            return Convert.ToInt32(textInputField.text.ToString());
        }
        catch
        {
            YBProjectMgr.Instance.mMainScene.ViewMsgPopup("숫자만 입력해주세요");
        }
        return 0;
    }
}

