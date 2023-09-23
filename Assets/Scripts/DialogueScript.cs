using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DialogueScript : MonoBehaviour
{
    
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int _index;
    private int _length;
    public string name;
    
    public static bool notdialogue;
    public static DialogueScript instance;
    
    private void Awake() 
    {
        if(instance==null)
        {
            instance =this;
        }
        else
        {
            if(instance!=this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
        _length=lines.Length;
        if ((Input.GetKeyDown(KeyCode.F) ||Input.GetKeyDown(KeyCode.E))&& gameObject.activeInHierarchy == true&&!notdialogue)
        {
            
            if (textComponent.text == lines[_index])
            {
                
                NextLine();
                
               
            }
            else
            {
                
                StopAllCoroutines();               
                textComponent.text = lines[_index];
                
            }
            
        }

        
    }

   
    void StartDialogue()
    {
        
        
        
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[_index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (_index < lines.Length - 1)
        {
            
            _index++;
            textComponent.text = string.Empty;
            checkname();
            StartCoroutine(TypeLine());
        }
        else
        {
            _index=0;
            textComponent.text =string.Empty;
            GetComponent<dialogueuianimation>().hide();
            name="";
            GameEventSystem.instance.DialogueFinish();
            print("DialogueFinish检测完成");
            QuestUIManager. instance.UpdateQuestList();
        }
    }
    public void LoadDialogue(string[] _newlines)
    {
         lines=_newlines;
        _length=lines.Length;
        
         //textComponent.text =lines[_index] ;
         
        _index=0;
        textComponent.text = string.Empty; 
        checkname();     
        StartDialogue();
        _length=lines.Length;
         

    }
    private void checkname()
    {
        name="";
        if(lines[_index].StartsWith("n-"))
        {
            name=lines[_index].Replace("n-","");
            _index++;

        }
    }
}