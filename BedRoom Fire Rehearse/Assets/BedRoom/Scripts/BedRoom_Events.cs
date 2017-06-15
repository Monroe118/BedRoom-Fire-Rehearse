using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;

public class BedRoom_Events : MonoBehaviour {

    // Set the countdown time
    private int time;

    public bool win;

    // The countdown conditions
    private bool startGame;

    // Display content
    public Text stepsText;
    public Text downTime;

    // The display panel
    public Transform mainCanvas;
    public Transform gameCanvas;

    // Other game objects
    public BedRoom_Fire fireManage;
    public Transform gameButtonTrans;

    // Handle object
    public Transform left_Manager;
    public Transform right_Manager;

    // The countdown began
    public void StartDownTime() {

        // Initialize the
        time = 180;
        startGame = true;

        // Display panel control
        mainCanvas.gameObject.SetActive(false);
        gameCanvas.gameObject.SetActive(true);

        // Display content
        ChangeStepsText("火灾就要波及卧室了，请尽快关好卧室房门！");

        // Open the living room particle effects
        fireManage.FireOn();

        // Start coroutines
        StartCoroutine(CountDown(time));

    }

    // Shut the door
    public void ShutDoor() {

        ChangeStepsText("现在尽快拿起床上的被子去卫生间打湿！");

    }

    // Shut the toilet door
    public void ShutToiletDoor()
    {

        ChangeStepsText("打开水龙头将被子打湿！");

    }

    // Put a quilt
    public void ToPutQuilt() {

        ChangeStepsText("将打湿的被子塞到卧室门的缝隙！");

    }

    public void GameOver() {
        if (win)
        {
            ChangeStepsText("恭喜你成功通过测试！");

            gameButtonTrans.gameObject.SetActive(true);
        }
        else
        {
            ChangeStepsText("很遗憾，您本次的演示行动不合格。");

            GameObject.Find("BedRoomFire").GetComponent<BedRoom_RoomFire>().OpenRoomFire();

            gameButtonTrans.gameObject.SetActive(true);
        }
    }

    public void ChangeStepsText(string str)
    {
        stepsText.text = str;
    }

    // The countdown
    private IEnumerator CountDown(int time)
    {
        while (startGame)
        {
            if (time > 0)
            {
                downTime.text = time.ToString();
                time--;
            }
            else
            {
                GameOver();

                StopCoroutine("CountDown");
            }

            yield return new WaitForSeconds(1);
        }
    }
}
