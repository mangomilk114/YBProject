using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject_2 : MoveEnemyObject
{
    public SpriteRenderer EnemyObjectSprite;
    public BoxCollider EnemyObjectCollider;

    float SizeX = 1.5f;
    float SizeY = 1f;

    float DownHeight = 0f;
    float DownSpeed = 0f;
    float UpHeight = 0f;
    float UpWidth = 0f;
    float UpSpeed = 0f;

    bool DownMove = true;
    float MoveSpeed = 0f;
    Vector3 Ver2Dir = new Vector3();
    Vector3 Ver2End = new Vector3();
    Vector3 Ver2Start = new Vector3();

    public void SetData()
    {
        // 랜덤으로 위, 아래 선택
        float yRandom = Random.Range(YBProjectMgr.Instance.ENEMY_2_POS_Y_MIN, YBProjectMgr.Instance.ENEMY_2_POS_Y_MAX);
        float sizeRandom = Random.Range(YBProjectMgr.Instance.ENEMY_2_SIZE_MIN, YBProjectMgr.Instance.ENEMY_2_SIZE_MAX);
        DownHeight = Random.Range(YBProjectMgr.Instance.ENEMY_2_DOWN_Y_MIN, YBProjectMgr.Instance.ENEMY_2_DOWN_Y_MAX);
        DownSpeed = Random.Range(YBProjectMgr.Instance.ENEMY_2_DOWN_SPEED_MIN, YBProjectMgr.Instance.ENEMY_2_DOWN_SPEED_MAX);
        UpHeight = Random.Range(YBProjectMgr.Instance.ENEMY_2_UP_Y_MIN, YBProjectMgr.Instance.ENEMY_2_UP_Y_MAX);
        UpWidth = Random.Range(YBProjectMgr.Instance.ENEMY_2_UP_X_MIN, YBProjectMgr.Instance.ENEMY_2_UP_X_MAX);
        UpSpeed = Random.Range(YBProjectMgr.Instance.ENEMY_2_UP_SPEED_MIN, YBProjectMgr.Instance.ENEMY_2_UP_SPEED_MAX);
        DownMove = true;

        transform.position = new Vector3(13, yRandom, 0);
        EnemyObjectSprite.size = new Vector2(SizeX + sizeRandom, SizeY + sizeRandom);
        EnemyObjectCollider.size = new Vector2(SizeX + sizeRandom, SizeY + sizeRandom);

        Ver2End = new Vector3(transform.localPosition.x, transform.localPosition.y - DownHeight, 0);
        SetMoveData(true);
    }

    public override void UpdateMove()
    {
        Vector3 tempVector = Ver2Dir * (Time.deltaTime * MoveSpeed);
        tempVector = transform.localPosition + tempVector;
        float fNowDistance = Vector2.Distance(tempVector, transform.localPosition);
        float fDestDistance = Vector2.Distance(Ver2End, transform.localPosition);

        if (fNowDistance >= fDestDistance)
        {
            transform.localPosition = Ver2End;
            SetMoveData(!DownMove);
        }
        else
        {
            transform.localPosition = tempVector;
        }
    }

    public void SetMoveData(bool down)
    {
        DownMove = down;
        if(DownMove)
        {
            Ver2Start = Ver2End;
            Ver2End = new Vector3(transform.localPosition.x, transform.localPosition.y - DownHeight, 0);
            Ver2Dir = Ver2End - transform.localPosition;
            Ver2Dir.Normalize();

            MoveSpeed = DownSpeed;
        }
        else
        {
            Ver2Start = Ver2End;
            Ver2End = new Vector3(transform.localPosition.x - UpWidth, transform.localPosition.y + UpHeight, 0);
            Ver2Dir = Ver2End - transform.localPosition;
            Ver2Dir.Normalize();

            MoveSpeed = UpSpeed;
        }
        
    }


    //private bool m_bMove = true;

    //private float m_fMoveDistance = 1.0f;            // 이동 시키고 싶은 거리를 정해주면 됨

    //private Vector2 m_Vec2MovePos = new Vector2(5,10);      // 이동해야할 최종 위치

    //private Vector2 m_Vec2MyPosition = new Vector2(0, 0);    // 내 위치 (텍스쳐 그려질 위치)

    //public Texture texture;                    // 그려질 텍스쳐

    //void Update()
    //{
    //    if (m_bMove)
    //    {
    //        // 내 위치에서 가야 할 위치에 대한 방향을 구한다.
    //        Vector2 vec2Dir = m_Vec2MovePos - m_Vec2MyPosition;
    //        vec2Dir.Normalize();        // 단위 벡터를 만든다.

    //        // 가야할 방에 시간 값을 곱해서 조금씩 이동하게 한다.
    //        // (시간값 * 이동 거리 = 한 프레임당 이동하고 싶은 간격)
    //        Vector2 vec2Temp = vec2Dir * (Time.deltaTime * m_fMoveDistance);

    //        // 내 위치에서 이동해야할 방향 값을 더하면 조금 이동했을 때의 위치값이 나온다.
    //        vec2Temp = m_Vec2MyPosition + vec2Temp;

    //        // 현재 내 위치로부터 계산되서 나온 다음 위치까지의 거리를 구한다.
    //        float fNowDistance = Vector2.Distance(vec2Temp, m_Vec2MyPosition);

    //        // 내 위치로부터 최종 목적지로 설정된 위치까지의 거리를 구한다.
    //        float fDestDistance = Vector2.Distance(m_Vec2MovePos, m_Vec2MyPosition);

    //        // 두 위치 값을 비교해서 목적 위치를 지나쳤는지 검사한다.
    //        // 현재 예상 거리 값이 최종 거리 값을 넘기거나 같으면 더이상 이동 할 필요 없음
    //        if (fNowDistance >= fDestDistance)
    //        {
    //            m_bMove = false;

    //            // 현재 위치 값을 최종 위치 값으로 설정
    //            m_Vec2MyPosition = m_Vec2MovePos;
    //        }
    //        else
    //        {
    //            m_Vec2MyPosition = vec2Temp;
    //        }

    //        transform.localPosition = m_Vec2MyPosition;
    //    }
    //}
}
