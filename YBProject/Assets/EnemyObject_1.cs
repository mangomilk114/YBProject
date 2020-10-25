using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject_1 : MoveEnemyObject
{
    public SpriteRenderer EnemyObjectSprite;
    public BoxCollider EnemyObjectCollider;

    float SizeX = 1.5f;
    float SizeY = 1f;

    float SpeedRandom = 0f;
    float MoveHeight = 0f;
    float MoveWidth = 0f;

    private float runningTime = 0f;
    private float yPos = 0f;
    public void SetData()
    {
        // 랜덤으로 위, 아래 선택
        float yRandom = Random.Range(YBProjectMgr.Instance.ENEMY_1_POS_Y_MIN, YBProjectMgr.Instance.ENEMY_1_POS_Y_MAX);
        float sizeRandom = Random.Range(YBProjectMgr.Instance.ENEMY_1_SIZE_MIN, YBProjectMgr.Instance.ENEMY_1_SIZE_MAX);
        SpeedRandom = Random.Range(YBProjectMgr.Instance.ENEMY_1_SPEED_MIN, YBProjectMgr.Instance.ENEMY_1_SPEED_MAX);
        MoveHeight = Random.Range(YBProjectMgr.Instance.ENEMY_1_MOVE_Y_MIN, YBProjectMgr.Instance.ENEMY_1_MOVE_Y_MAX);
        MoveWidth = Random.Range(YBProjectMgr.Instance.ENEMY_1_MOVE_X_MIN, YBProjectMgr.Instance.ENEMY_1_MOVE_X_MAX);

        transform.position = new Vector3(13, yRandom, 0);
        EnemyObjectSprite.size = new Vector2(SizeX + sizeRandom, SizeY + sizeRandom);
        EnemyObjectCollider.size = new Vector2(SizeX + sizeRandom, SizeY + sizeRandom);
    }

    public override void UpdateMove()
    {
        runningTime += Time.deltaTime * SpeedRandom;
        yPos = Mathf.Sin(runningTime) * MoveHeight;
        this.transform.position = new Vector2(this.transform.position.x - MoveWidth, yPos);
    }
}
