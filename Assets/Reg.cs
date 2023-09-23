using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reg : MonoBehaviour
{
    bool isClick = false;
    public TextMesh text;
    string s;
    Dictionary<string, string> pairs = new Dictionary<string, string>()
    {
        {"@1", "<color=red>"},
        { "@2" , "<color=#DDDDDD>"},
        { "@3" , "<color=green>"},
        { "@4" , "<color=#FFDD22>"},
        { "@5" , "<color=blue>"},
        {"@0", "</color>"},
        { "$1" , "<size=10>"},
        { "$2" , "<size=18>"},
        { "$0" , "</size>"}

    };
    // Start is called before the first frame update
    IEnumerator Start()
    {
        // pairs.Add("#1", "<color#FFFFFF>");
        s = "今天$2@1我们@0开发$0一个@3人工智能@0";
        string s_print = null;
        string s_print_last = null;
        string s_label;
        string s_end = pairs["@0"];
        string s_sizeEnd = pairs["$0"];
        bool isChanged = false;
        int changedNo = 0, sizeNo = 0;
        bool isSized = false;
        bool isCanPrint = false;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != '@' && s[i] != '$')
            {
                s_print = s_print + s.Substring(i, 1);
                isCanPrint = true;
            }
            else
            {
                s_label = s.Substring(i, 2);
                s_print = s_print + pairs[s_label];
                isCanPrint = false;

                if (s[i] == '@')
                {
                    isChanged = !isChanged;
                    changedNo = i;

                }
                if (s[i] == '$')
                {
                    isSized = !isSized;
                    sizeNo = i;

                }
                i++;
            }




            if (isChanged && isSized)
            {
                if (changedNo > sizeNo)
                {
                    s_print_last = s_print + s_end + s_sizeEnd;
                }
                else
                {
                    s_print_last = s_print + s_sizeEnd + s_end;

                }


            }
            else if (isChanged && !isSized)
            {
                s_print_last = s_print + s_end;
            }
            else if (!isChanged && isSized)
            {
                s_print_last = s_print + s_sizeEnd;

            }
            else
            {
                s_print_last = s_print;
            }



            if (isCanPrint)
            {
                if (!isClick)
                {
                    yield return new WaitForSeconds(1f);
                }
                text.text = s_print_last;
                Debug.Log(s_print_last);


            }

        }




        
        
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            isClick = true;
        }
    }
}
