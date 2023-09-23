using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class guide : MonoBehaviour
{
    
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int _index;
    private int _length;
    //public string name;
    
    public static bool notdialogue;
    public static guide instance;
    private Vector3 origintransform;
    bool dialogueStarted = false;
    //public GameObject guideprefeb;
    
    private void Awake() 
    {
        
        origintransform=transform.position;
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
    private void OnEnable() 
    {
        
        transform.position=origintransform;
        textComponent.text = string.Empty;
    }
    // Update is called once per frame
    void Update()
    {
         
        _length=lines.Length;
        if (Input.GetMouseButtonDown(0)&& gameObject.activeInHierarchy == true&&!notdialogue)
        {
            
            if (textComponent.text == lines[_index])
            {
                
                //NextLine();
                
               
            }
            else
            {
                
                //StopAllCoroutines();               
                //textComponent.text = lines[_index];
                
            }
            
        }

        
    }

   
    void StartDialogue()
    {
        
   StopAllCoroutines();
   StartCoroutine(TypeLine());
        
        
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[_index].ToCharArray())
        {

            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        dialogueStarted = false;
    }

    void NextLine()
    {
        if (_index < lines.Length - 1)
        {
            
            _index++;
            textComponent.text = string.Empty;
            //checkname();
            StartCoroutine(TypeLine());
        }
        else
        {
            _index=0;
            textComponent.text =string.Empty;
            gameObject.SetActive(false);
            //name="";
            //GameEventSystem.instance.DialogueFinish();
           // print("DialogueFinish检测完成");
           // QuestUIManager. instance.UpdateQuestList();
        }
    }
    public void LoadDialogue(string[] _newlines)
    {
         
         lines=null;
         lines=_newlines;
        _length=lines.Length;
        
         //textComponent.text =lines[_index] ;
         
        _index=0;
        textComponent.text = string.Empty; 
        //checkname();     
        StartDialogue();
        //_length=lines.Length;
         

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
    public void click()
    {
        GetComponent<dialogueuianimation>().hide();
    }
}