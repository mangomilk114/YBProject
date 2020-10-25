using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurdleObject_2 : MoveEnemyObject
{
    public GameObject hurdle_Center;
    public GameObject Hurdle_Top; 
    public GameObject Hurdle_Bottom; 
    public SpriteRenderer Hurdle_Top_Sprite;
    public SpriteRenderer Hurdle_Bottom_Sprite;
    public BoxCollider Hurdle_Top_Collider;
    public BoxCollider Hurdle_Bottom_Collider;

    private bool Top = true;
    float TopYPos = 11.5f;
    float BottomYPos = -1.5f;
    float SizeX = 1.2f;
    float SizeY = 13;
    public void SetData()
    {
        // 랜덤으로 위, 아래 선택
        transform.localPosition = new Vector3(13, 0, 0);
        hurdle_Center.transform.localPosition = new Vector3(0, 0, 0);
        Hurdle_Top.transform.localPosition = new Vector3(0, TopYPos, 0);
        Hurdle_Bottom.transform.localPosition = new Vector3(0, BottomYPos, 0);
        Hurdle_Top_Sprite.size = new Vector2(SizeX, SizeY);
        Hurdle_Bottom_Sprite.size = new Vector2(SizeX, SizeY);
        Hurdle_Top_Collider.size = new Vector2(SizeX, SizeY);
        Hurdle_Bottom_Sprite.size = new Vector2(SizeX, SizeY);

        float passHeightRandom = Random.Range(YBProjectMgr.Instance.HURDLE_2_PASS_HEIGHT_MIN, YBProjectMgr.Instance.HURDLE_2_PASS_HEIGHT_MAX);
        float passPosRandom = Random.Range(YBProjectMgr.Instance.HURDLE_2_POS_Y_MIN, YBProjectMgr.Instance.HURDLE_2_POS_Y_MAX);
        float widthRandom = Random.Range(YBProjectMgr.Instance.HURDLE_2_WIDTH_MIN, YBProjectMgr.Instance.HURDLE_2_WIDTH_MAX);

        hurdle_Center.transform.localPosition = new Vector3(0, passPosRandom, 0);

        Hurdle_Top.transform.localPosition = new Vector3(0, TopYPos + passHeightRandom / 2, 0);
        Hurdle_Bottom.transform.localPosition = new Vector3(0, BottomYPos - passHeightRandom / 2, 0);
        Hurdle_Top_Sprite.size = new Vector2(SizeX + widthRandom, SizeY);
        Hurdle_Top_Collider.size = new Vector2(SizeX + widthRandom, SizeY);
        Hurdle_Bottom_Sprite.size = new Vector2(SizeX + widthRandom, SizeY);
        Hurdle_Bottom_Collider.size = new Vector2(SizeX + widthRandom, SizeY);
    }

    public override void UpdateMove()
    {
        transform.localPosition += new Vector3(-YBProjectMgr.Instance.BIRD_BASE_SPEED, 0, 0);
    }
}
