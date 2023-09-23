using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FadingInOpening : MonoBehaviour
{
    [SerializeField] private CanvasGroup tutorialCanvasGroup;
    [SerializeField] private bool fadeIn = false;
    [SerializeField] private bool fadeOut = false;

    //-------------------------------------------------------------//

    //private TextMeshProUGUI openingText;
    //private bool isDisplaying = false;
    //private string[] textArray;

    //private string text01 = "16 years ago,Phinepo Island started to become corrupted out of unknown reason.";
    //private string text02 = "Researchers had been trying to find the reason and a solution to cure the curruption for many years, but not avail.";
    //private string text03 = "According to astrologers, the island would be completely corrupted in no more than 20 years and now it's already in the late stage.";
    //private string text04 = "Only four years reamaining for tis residents.We had to stop the hopeless research and try to find another way out, a new home.";
    //private string text05 = "No matter what it was like before, everyone's setting sail. It would be incredibly lucky to get a seat on board.";
    //private string text06 = "Residents left their home, and most of them chose to believe that the sailing would shed a light into their lives";

    private void Start()
    {
        tutorialCanvasGroup.alpha = 1;
        fadeOut = true;
        //---------------------------------------------------------------------------------//
        

    }

    private void Update()
    {
        if (fadeOut)
        {
            StartCoroutine(WaitForSecondsBeforeFadeOut());
        }

        if (fadeIn)
        {
            StartCoroutine(WaitForSecondsBeforeFadeIn());
        }
        

    }

    IEnumerator WaitForSecondsBeforeFadeIn()
    {
        if (tutorialCanvasGroup.alpha < 1)
        {
            tutorialCanvasGroup.alpha += Time.deltaTime;
            if (tutorialCanvasGroup.alpha >= 1)
            {
                fadeIn = false;
                yield return new WaitForSeconds(2);
                fadeOut = true;
            }

        }
    }

    IEnumerator WaitForSecondsBeforeFadeOut()
    {
        if (tutorialCanvasGroup.alpha >= 0)
        {
            tutorialCanvasGroup.alpha -= Time.deltaTime;
            if (tutorialCanvasGroup.alpha == 0)
            {
                fadeOut = false;
                yield return new WaitForSeconds(5);
                fadeIn = true;
            }
        }
    }

    //---------------------------------------------------------------------------------//

    //private IEnumerator TextDisplay(string[] Text)
    //{
    //    for (int i = 0; i < Text.Length; i++)
    //    {
    //        StringSplitter(Text[i]);
    //        string[] Characters = new string[Text[i].Length];

    //        yield return new WaitForSeconds((Characters.Length + 45) * 0.035f);
    //    }
    //}

    //private void StringSplitter(string sentence)
    //{
    //    openingText.text = "";
    //    string[] Characters = new string[sentence.Length];
    //    for (int i = 0; i < sentence.Length; i++)
    //    {
    //        Characters[i] = System.Convert.ToString(sentence[i]);
    //    }
    //    StartCoroutine(StringDisplayDelay(Characters));
    //}

    //private IEnumerator StringDisplayDelay(string[] Characters)
    //{
    //    for (int i = 0; i < Characters.Length; i++)
    //    {
    //        openingText.text += Characters[i];
    //        //Add sound effects here
    //        yield return new WaitForSeconds(0.025f);
    //    }
    //    isDisplaying = false;
    //}





    //https://www.youtube.com/watch?v=tF9RMjF9wDc
    //https://www.youtube.com/watch?v=x9BsW6oKiZ8






}