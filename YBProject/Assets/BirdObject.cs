using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdObject : MonoBehaviour
{
    public Rigidbody Rigi;
    public void GameReady()
    {
        // x 최소값 -9 y 최소값 -5
        gameObject.transform.localPosition = new Vector3(-9 + YBProjectMgr.Instance.BIRD_START_POS_X, -5 + YBProjectMgr.Instance.BIRD_START_POS_Y, 0);
        Rigi.isKinematic = true;
        Rigi.detectCollisions = false;
    }

    public void GameStart()
    {
        Rigi.isKinematic = false;
        Rigi.detectCollisions = true;
    }

    public void UpdateObject()
    {
        System.Action jumpAction = () =>
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            gameObject.GetComponent<Rigidbody>().AddForce(0, YBProjectMgr.Instance.BIRD_JUMP_HEIGHT, 0);
        };
        if (Input.GetMouseButtonDown(0))
        {
            jumpAction();
        }
        else
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        jumpAction();
                        Debug.Log("TouchPhase Began!");

                        break;

                    case TouchPhase.Moved:
                        Debug.Log("TouchPhase Moved!");

                        break;

                    case TouchPhase.Stationary:
                        Debug.Log("TouchPhase Stationary!");

                        break;

                    case TouchPhase.Ended:
                        Debug.Log("TouchPhase Ended!");

                        break;

                    case TouchPhase.Canceled:
                        Debug.Log("TouchPhase Canceled!");

                        break;
                }
            }
        }
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        //YBProjectMgr.Instance.GameType = YBProjectMgr.GAME_TYPE.OVER;
    }
}
