using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DisplayTextInOpening : MonoBehaviour
{
    private TextMeshProUGUI openingText;
    private bool isDisplaying = false;
    private string[] textArray;
    public float awaitTime;

    //private string text01 = "16 years ago,Phinepo Island started to become corrupted out of unknown reason.";
    //private string text02 = "Researchers had been trying to find the reason and a solution to cure the curruption for many years, but not avail.";
    //private string text03 = "According to astrologers, the island would be completely corrupted in no more than 20 years and now it's already in the late stage.";
    //private string text04 = "Only four years reamaining for tis residents.We had to stop the hopeless research and try to find another way out, a new home.";
    //private string text05 = "No matter what it was like before, everyone's setting sail. It would be incredibly lucky to get a seat on board.";
    //private string text06 = "Residents left their home, and most of them chose to believe that the sailing would shed a light into their lives";
    //private string text07 = "Line07 awaits";

    private string text01 = "16年前,小动物们所居住的到佩纳波岛由于不明原因开始腐化";
    private string text02 = "多年以来,学者们一直研究着其原因,以及尝试解决腐败的方法,结果没有任何成果";
    private string text03 = "而根据占星师们预测,20年内岛内就会全部腐化,而现今程度已经很深";
    private string text04 = "预计只有四年时间留给小动物们.我们不得不中断无休止而希望渺茫的研究,探究其他的出路,去找一个新家园";
    private string text05 = "无论先前如何,所有人都在纷纷出航,不管怎样,能拿到一个在船上的位置就已经是莫大的幸运";
    private string text06 = "小动物们离开了养育他们的地方,而他们中多数都选择相信,远航还是会为他们带来光明";
    


    public GameObject[] icons;
    public int index;
    //float iconSwitchTime=10.0f;//no need , i have awaitTime
    [SerializeField] private float timer = 0.0f;
    public string targetScene;

    void Start()
    {
        openingText = GameObject.FindGameObjectWithTag("Text").GetComponent<TextMeshProUGUI>();
        textArray = new string[7];
        textArray[0] = text01;
        textArray[1] = text02;
        textArray[2] = text03;
        textArray[3] = text04;
        textArray[4] = text05;
        textArray[5] = text06;

        StartCoroutine(TextDisplay(textArray));
    }

    private IEnumerator TextDisplay(string[] Text)
    {
        for (int i = 0; i < Text.Length; i++)
        {
            StringSplitter(Text[i]);
            string[] Characters = new string[Text[i].Length];

            //yield return new WaitForSeconds((Characters.Length + 55) * 0.035f);
            yield return new WaitForSeconds(awaitTime);
        }
    }

    private void StringSplitter(string sentence)
    {
        openingText.text = "";
        string[] Characters = new string[sentence.Length];
        for (int i = 0;i < sentence.Length;i++) 
        {
            Characters[i] = System.Convert.ToString(sentence[i]);
        }
        StartCoroutine(StringDisplayDelay(Characters));
    }

    private IEnumerator StringDisplayDelay(string[] Characters)
    {
        for (int i = 0; i < Characters.Length; i++)
        {
            openingText.text+= Characters[i];
            //Add sound effects here
            yield return new WaitForSeconds(0.025f);
        }
        isDisplaying = false;
    }

    private void SwitchScene()
    {
        SceneManager.LoadScene(targetScene);
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space) && isDisplaying == false)
        //{
        //    isDisplaying = true;
        //    StartCoroutine(TextDisplay(textArray));
        //}
        timer += Time.deltaTime;
        if (timer>= awaitTime)
        {
            if (index >= icons.Length)
            {
                SwitchScene();
            }

            if (index < icons.Length)
            {
                icons[index].gameObject.SetActive(false);
                index++;
                Debug.Log("index=" + index);
                icons[index].gameObject.SetActive(true);
            }
            //for (index = 0; index < icons.Length; index++)
            //{
            //    icons[index].gameObject.SetActive(false);
            //    icons[index + 1].gameObject.SetActive(true);
            //}

            timer = 0;
        }
        
    }



}
