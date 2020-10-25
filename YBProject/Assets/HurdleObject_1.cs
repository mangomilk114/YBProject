using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurdleObject_1 : MoveEnemyObject
{
    public GameObject Hurdle_Top; // 16
    public GameObject Hurdle_Bottom; // -5
    public SpriteRenderer Hurdle_Top_Sprite;
    public SpriteRenderer Hurdle_Bottom_Sprite;
    public BoxCollider Hurdle_Top_Collider;
    public BoxCollider Hurdle_Bottom_Collider;

    private bool Top = true;
    float TopYPos = 11;
    float BottomYPos = -10;
    float SizeX = 1.2f;
    float SizeY = 13;
    public void SetData()
    {
        // 랜덤으로 위, 아래 선택
        transform.localPosition = new Vector3(13, 0, 0);
        Hurdle_Top.gameObject.SetActive(false);
        Hurdle_Bottom.gameObject.SetActive(false);
        Hurdle_Top.transform.localPosition = new Vector3(0, TopYPos, 0);
        Hurdle_Bottom.transform.localPosition = new Vector3(0, BottomYPos, 0);
        Hurdle_Top_Sprite.size = new Vector2(SizeX, SizeY);
        Hurdle_Bottom_Sprite.size = new Vector2(SizeX, SizeY);
        Hurdle_Top_Collider.size = new Vector2(SizeX, SizeY);
        Hurdle_Bottom_Sprite.size = new Vector2(SizeX, SizeY);

        Top = Random.Range(0, 2) == 1 ? true : false;
        float heightRandom = Random.Range(YBProjectMgr.Instance.HURDLE_1_HEIGHT_MIN, YBProjectMgr.Instance.HURDLE_1_HEIGHT_MAX);
        float widthRandom = Random.Range(YBProjectMgr.Instance.HURDLE_1_WIDTH_MIN, YBProjectMgr.Instance.HURDLE_1_WIDTH_MAX);

        if (Top)
        {
            Hurdle_Top.gameObject.SetActive(true);
            Hurdle_Top.transform.localPosition = new Vector3(0, TopYPos - heightRandom, 0);
            Hurdle_Top_Sprite.size = new Vector2(widthRandom, SizeY);
            Hurdle_Top_Collider.size = new Vector2(widthRandom, SizeY);
        }
        else
        {
            Hurdle_Bottom.gameObject.SetActive(true);
            Hurdle_Bottom.transform.localPosition = new Vector3(0, BottomYPos + heightRandom, 0);
            Hurdle_Bottom_Sprite.size = new Vector2(widthRandom, SizeY);
            Hurdle_Bottom_Collider.size = new Vector2(widthRandom, SizeY);
        }
    }

    public override void UpdateMove()
    {
        transform.localPosition += new Vector3(-YBProjectMgr.Instance.BIRD_BASE_SPEED, 0, 0);
    }
}
