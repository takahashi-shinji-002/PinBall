using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class FripperController : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    // 右画面の指の識別
    public int RightFingerid;

    // 左画面の指の識別
    public int LeftFingerid;

    // Use this for initialization
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }


    // Update is called once per frame
    void Update()
    {

        // 左矢印キーを押した時左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        // 右矢印キーを押した時右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        // 矢印キー離された時フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                //タッチした指の情報
                Touch touch = Input.GetTouch(i);


                // 座標xがスクリーンの2分の1以上の場合
                if (touch.position.x >= Screen.width / 2)
                {
                    // 右側をタップしたら右のフリッパーが動く
                    if (touch.phase == TouchPhase.Began && tag == "RightFripperTag")
                    {
                        SetAngle(this.flickAngle);
                        RightFingerid = touch.fingerId;
                    }
                }
                // 左側をタップしたら左のフリッパーが動く
                else if (touch.phase == TouchPhase.Began && tag == "LeftFripperTag")
                {
                    SetAngle(this.flickAngle);
                    LeftFingerid = touch.fingerId;
                }


                // タップが終了したらフリッパーが元に戻る
                if (touch.phase == TouchPhase.Ended && tag == "LeftFripperTag")
                {
                    if(touch.fingerId == LeftFingerid)
                    {
                        SetAngle(this.defaultAngle);
                    }
                }

                if (touch.phase == TouchPhase.Ended && tag == "RightFripperTag")
                {
                    if (touch.fingerId == RightFingerid)
                    {
                        SetAngle(this.defaultAngle);
                    }
                }
            }
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
