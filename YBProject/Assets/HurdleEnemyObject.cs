using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurdleEnemyObject : MonoBehaviour
{
    public HurdleObject_1 mHurdleObject_1;
    public HurdleObject_2 mHurdleObject_2;
    public EnemyObject_1 mEnemyObject_1;
    public EnemyObject_2 mEnemyObject_2;

    public List<MoveEnemyObject> MoveObjectList = new List<MoveEnemyObject>();

    float SaveTime = 0f;
    float ObjectCreateGapTime = 0f;
    public void GameStart()
    {
        for (int i = 0; i < MoveObjectList.Count; i++)
        {
            DestroyImmediate(MoveObjectList[i].gameObject);
        }
        MoveObjectList.Clear();
        SaveTime = Time.time;
        WaveStart();
    }
    public void WaveStart()
    {
        ObjectCreateGapTime = YBProjectMgr.Instance.ENEMY_1_GAP_TIME;
    }
    public void UpdateObject()
    {
        if (Time.time > SaveTime + ObjectCreateGapTime)
        {
            SaveTime = Time.time;
            //HurdleObject_1 obj = Instantiate(mHurdleObject_1, this.transform);
            //obj.SetData();
            //MoveObjectList.Add(obj);

            //HurdleObject_2 obj = Instantiate(mHurdleObject_2, this.transform);
            //obj.SetData();
            //MoveObjectList.Add(obj);

            //EnemyObject_1 obj = Instantiate(mEnemyObject_1, this.transform);
            //obj.SetData();
            //MoveObjectList.Add(obj);

            EnemyObject_2 obj = Instantiate(mEnemyObject_2, this.transform);
            obj.SetData();
            MoveObjectList.Add(obj);
        }

        for (int i = 0; i < MoveObjectList.Count; i++)
        {
            MoveObjectList[i].UpdateMove();
        }

        //for (int i = MoveObjectList.Count - 1; i >= 0; i--)
        //{
        //    if(MoveObjectList[i].transform.localPosition.x < -25)
        //    {
        //        DestroyImmediate(MoveObjectList[i].gameObject);
        //        MoveObjectList.RemoveAt(i);
        //    }
        //}
    }
}
