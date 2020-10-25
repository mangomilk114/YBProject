using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YBProjectMgr : MonoBehaviour
{
    public static YBProjectMgr _instance = null;
    public static YBProjectMgr Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<YBProjectMgr>() as YBProjectMgr;
            }
            return _instance;
        }
    }

    // 새 시작 위치 X (0 ~ 4)
    [NonSerialized]
    public float BIRD_START_POS_X = 2f;

    // 새 시작 위치 Y (2 ~ 9)
    [NonSerialized]
    public float BIRD_START_POS_Y = 5f;

    // 새 점프 높이
    [NonSerialized]
    public float BIRD_JUMP_HEIGHT = 300f;

    // 새 낙하속도 (구현 방법 아직 모름)
    [NonSerialized]
    public float BIRD_JUMP_DOWN_SPEED = 0f;

    // 새 기본 속도
    [NonSerialized]
    public float BIRD_BASE_SPEED = 0.05f;

    // 새 스테이지 추가 속도
    [NonSerialized]
    public float BIRD_ADD_SPEED = 0f;




    // 장애물 넘어가기 관련
    // 길이 (0 ~ 7 사이)
    [NonSerialized]
    public float HURDLE_1_HEIGHT_MAX = 7f;
    [NonSerialized]
    public float HURDLE_1_HEIGHT_MIN = 0f;
    // 두께 (1.2 ~ )
    [NonSerialized]
    public float HURDLE_1_WIDTH_MAX = 3f;
    [NonSerialized]       
    public float HURDLE_1_WIDTH_MIN = 1.2f;

    // 생성 간격
    [NonSerialized]
    public float HURDLE_1_GAP_TIME = 1f;



    // 장애물 사이 통과하기 관련
    // 장애물 사이 통과 간격
    [NonSerialized]
    public float HURDLE_2_PASS_HEIGHT_MAX = 5f;
    [NonSerialized]
    public float HURDLE_2_PASS_HEIGHT_MIN = 1f;
    // 두께
    [NonSerialized]
    public float HURDLE_2_WIDTH_MAX = 0f;
    [NonSerialized]
    public float HURDLE_2_WIDTH_MIN = 0f;
    // 생성 위치 (-3 ~ 4)
    [NonSerialized]
    public float HURDLE_2_POS_Y_MAX = 0f;
    [NonSerialized]       
    public float HURDLE_2_POS_Y_MIN = 0f;
    // 생성 간격
    [NonSerialized]
    public float HURDLE_2_GAP_TIME = 3f;


    // 뽀꾸뽀꾸 (사인곡선으로 이동
    // 생성 위치 (2 ~ 9)
    [NonSerialized]
    public float ENEMY_1_POS_Y_MAX = 9f;
    [NonSerialized]
    public float ENEMY_1_POS_Y_MIN = 2f;
    // 이동속도
    [NonSerialized]
    public float ENEMY_1_SPEED_MAX = 5.2f;
    [NonSerialized]      
    public float ENEMY_1_SPEED_MIN = 0.1f;
    // 크기
    [NonSerialized]
    public float ENEMY_1_SIZE_MAX = 2f;
    [NonSerialized]      
    public float ENEMY_1_SIZE_MIN = 0f;
    // 파장
    [NonSerialized]
    public float ENEMY_1_MOVE_X_MAX = 0.2f;
    [NonSerialized]
    public float ENEMY_1_MOVE_X_MIN = 0.1f;
    // 진폭
    [NonSerialized]
    public float ENEMY_1_MOVE_Y_MAX = 3.0f;
    [NonSerialized]
    public float ENEMY_1_MOVE_Y_MIN = 2.0f;
    // 생성 간격
    [NonSerialized]
    public float ENEMY_1_GAP_TIME = 1f;


    // 징오징오
    // 생성 위치 (2 ~ 9)
    [NonSerialized]
    public float ENEMY_2_POS_Y_MAX = 9f;
    [NonSerialized]    
    public float ENEMY_2_POS_Y_MIN = 2f;
    // 크기            
    [NonSerialized]    
    public float ENEMY_2_SIZE_MAX = 1f;
    [NonSerialized]    
    public float ENEMY_2_SIZE_MIN = 0f;
    // 내려가는 거리          
    [NonSerialized]    
    public float ENEMY_2_DOWN_Y_MAX = 4f;
    [NonSerialized]    
    public float ENEMY_2_DOWN_Y_MIN = 2f;
    // 내려가는 속도
    [NonSerialized]
    public float ENEMY_2_DOWN_SPEED_MAX = 5f;
    [NonSerialized]           
    public float ENEMY_2_DOWN_SPEED_MIN = 2.5f;
    // 올라가는 거리          
    [NonSerialized]
    public float ENEMY_2_UP_Y_MAX = 4f;
    [NonSerialized]
    public float ENEMY_2_UP_Y_MIN = 2f;
    // 올라가는 거리          
    [NonSerialized]
    public float ENEMY_2_UP_X_MAX = 6f;
    [NonSerialized]
    public float ENEMY_2_UP_X_MIN = 2f;
    // 내려가는 속도
    [NonSerialized]
    public float ENEMY_2_UP_SPEED_MAX = 5f;
    [NonSerialized]
    public float ENEMY_2_UP_SPEED_MIN = 2.5f;
    // 생성 간격       
    [NonSerialized]    
    public float ENEMY_2_GAP_TIME = 0f;

    public enum GAME_TYPE
    {
        READY,
        PLAYING,
        OVER,
    }


    public MainScene mMainScene;
    public LandObject mLandObject;
    public BirdObject mBirdObject;
    public HurdleEnemyObject mHurdleEnemyObject;
    public GAME_TYPE GameType = GAME_TYPE.PLAYING;

    public void Start()
    {
        Screen.SetResolution(1920, 1080, false);
        GameReady();
        StartCoroutine(Co_GameUpdate());
        DontDestroyOnLoad(this);
    }

    public void GameReady()
    {
        mLandObject.GameReady();
        mBirdObject.GameReady();
        GameType = GAME_TYPE.READY;
    }

    public void GameStart()
    {
        mMainScene.GameStart();
        mBirdObject.GameStart();
        mHurdleEnemyObject.GameStart();
        GameType = GAME_TYPE.PLAYING;
    }

    public void GameOver()
    {
        mMainScene.GameOver();
        GameType = GAME_TYPE.OVER;
    }

    public IEnumerator Co_GameUpdate()
    {
        while(true)
        {
            if(GameType == GAME_TYPE.OVER)
            {
                yield return null;
            }
            else if (GameType == GAME_TYPE.READY)
            {
                yield return null;
            }
            else if (GameType == GAME_TYPE.PLAYING)
            {
                mLandObject.UpdateObject();
                mBirdObject.UpdateObject();
                mHurdleEnemyObject.UpdateObject();
                yield return null;
            }
        }
    }
}
