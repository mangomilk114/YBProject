using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandObject : MonoBehaviour
{
    public List<GameObject> LandObjectList = new List<GameObject>();

    private float LandGap = 0;
    private float RepeatXPos = -13f;
    public void Awake()
    {
        float oneLand = Mathf.Abs(LandObjectList[0].transform.localPosition.x);
        float twoLand = Mathf.Abs(LandObjectList[1].transform.localPosition.x);

        LandGap = oneLand - twoLand;
    }

    public void GameReady()
    {
        for (int i = 0; i < LandObjectList.Count; i++)
        {
            LandObjectList[i].transform.localPosition = new Vector3(RepeatXPos + LandGap * i, -5, 0);
        }
    }

    public void UpdateObject()
    {
        float endXPos = 0f;
        int repeatIndex = -1;
        for (int i = 0; i < LandObjectList.Count; i++)
        {
            LandObjectList[i].transform.localPosition += new Vector3(-YBProjectMgr.Instance.BIRD_BASE_SPEED, 0, 0);

            if (endXPos < LandObjectList[i].transform.localPosition.x)
                endXPos = LandObjectList[i].transform.localPosition.x;

            if (LandObjectList[i].transform.localPosition.x < RepeatXPos)
                repeatIndex = i;
        }

        if(repeatIndex >= 0)
        {
            LandObjectList[repeatIndex].transform.localPosition = new Vector3(endXPos + LandGap, -5, 0);
        }
    }
}
