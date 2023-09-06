using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public static TimerScript inst;

    [Header("UI feedback")]
    public TextMeshProUGUI timeFeedback;

    // Start is called before the first frame update
    void Start()
    {
        if (inst) Debug.LogWarning("There is more than 1 LevelManager in the scene");
        inst = this;
        StartCoroutine(TimeTick());
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Timer
    //Calculate only in game time
    IEnumerator TimeTick(int sec = 0, int min = 0)
    {
        while (Time.timeScale != 0)
        {
            yield return new WaitForSeconds(1);
            //update seconds and minutes
            if (sec == 59)
            {
                sec = 0;
                min++;

            }
            else
            {
                sec++;
            }

            if (sec < 10)
            {
                timeFeedback.text = min + ":0" + sec;
            }
            else
            {
                timeFeedback.text = min + ":" + sec;
            }

        }
        StopCoroutine(TimeTick());
    }
}
