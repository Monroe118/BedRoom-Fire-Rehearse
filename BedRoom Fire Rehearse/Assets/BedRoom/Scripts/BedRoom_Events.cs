using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BedRoom_Events : MonoBehaviour {

    // Set the countdown time
    private int time = 0;

    public bool win = false;

    // The countdown conditions
    private bool startGame;

    // Display content
    public Text stepsText;
    public Text downTime;

    // The display panel
    public Transform mainCanvas;
    public Transform gameCanvas;

    // Other game objects
    public Transform fireManager;
    public Transform gameButtonTrans;
    public Transform roomFire;

    // Handle object
    public Transform left_Manager;
    public Transform right_Manager;

    // The countdown began
    public void StartDownTime() {

        // Initialize the
        time = 180;
        startGame = true;
        win = false;

        // Display panel control
        mainCanvas.gameObject.SetActive(false);
        gameCanvas.gameObject.SetActive(true);
        gameButtonTrans.gameObject.SetActive(false);

        // Display content
        ChangeStepsText("火灾就要波及卧室了，请您尽快关好卧室房门！");

        // Open the living room particle effects
        fireManager.gameObject.SetActive(true);

        // Start coroutines
        StartCoroutine(CountDown(time));

    }

    // Shut the door
    public void ShutDoor() {

        ChangeStepsText("请您尽快拿起床上的被子去卫生间打湿！");

    }

    // Shut the door
    public void ShutDoors()
    {

        ChangeStepsText("请您赶紧把门关上，火灾即将波及卧室了，危险。赶紧进行下一步！");

    }

    // Put a quilt
    public void ToPutQuilt() {

        ChangeStepsText("请您将打湿的被子塞到卧室门下的缝隙！");

    }

    public void GameOver() {

        if (win)
        {
            ChangeStepsText("恭喜您成功通过测试！");

            downTime.text = ("").ToString();

            gameButtonTrans.gameObject.SetActive(true);
        }
        else
        {
            ChangeStepsText("很遗憾，您本次的演示行动不合格。");

            downTime.text = ("").ToString();

            roomFire.gameObject.SetActive(true);

            gameButtonTrans.gameObject.SetActive(true);

        }
    }

    // Re - start the exercise
    public void GameStart(string sceneName) {

        SceneManager.LoadScene(sceneName);

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
                if (win == false)
                {
                    downTime.text = time.ToString();
                    time--;
                }
                else
                {
                    time = 0;
                }
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
