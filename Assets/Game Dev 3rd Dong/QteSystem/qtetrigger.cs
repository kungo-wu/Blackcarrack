using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class qtetrigger : MonoBehaviour
{
    private  bool qteon=false;
    public GameObject qtesystem;
    public GameObject qte;
    private GameObject currentQTE;  
    public GameObject player;
    private Image image;
    
    
 
   // public GameObject win;
    //public GameObject fail;
    public  bool click=false;
    public  bool clickmore=false;
    public  float thespeed=0.3f;
    public  float theraise=0.1f;
    public  static bool qtetodoclick;
    public  static bool qtetodoclickmore;
    public int minqtetimes=3;
    public int maxqtetimes=5;
    public  static float speed;
    public  static float raise;
    private List<KeyCode> currentSequence;   // 当前的按键序列
    private int currentQTEIndex=0;
    private KeyCode currentKey;


    private KeyCode[] possibleKeys = {KeyCode.Z, KeyCode.F, KeyCode.Q, KeyCode.Space,KeyCode.R,KeyCode.H,KeyCode.X,KeyCode.C};
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        

        if(other.gameObject.CompareTag ("Player"))
        {
            qteon=true;
        }
         if(qteon==true)
        {
           // win.SetActive(false);
            //fail.SetActive(false);
            ShowNextQTE();
            Destroy(currentQTE);
            if(qtetodoclickmore)
            {
                GameEventSystem.instance.Temporarychange("qtestart");

                player.GetComponent<Animator>().SetTrigger("Captured");
            }
           
            
            PlayerController.isPlayerInQte = true;
            
           
          // player.GetComponent<PlayerController>().enabled = false;
           
           
        }
    }
   
   
       

   /* public void qtetodoclick()
    {
        
       if( isqtetodoclick==true)
       {
        if(image.fillAmount>0 )
        {
            print("10");
            if(Input.GetKeyDown(currentKey))
        {
            print("sucess");
            qtesystem.SetActive(false);
            win.SetActive(true);
         
            image.fillAmount=1;
            OnQTESuccess();
        }
       
        }
        
        
        else
        {
        
            print("false");
           fail.SetActive(true);
           image.fillAmount=1;
            OnQTEFail();
        }
        
       }

    }
    public void qtetodoclickmore()
    {
        
       if( isqtetodoclickmore==true)
       {
         if(image.fillAmount<1 )
        {
        
            if(Input.GetKeyDown(currentKey))
        {
            print("sucess");
            image.fillAmount+= raise;
            if( image.fillAmount>=1)
            {
                win.SetActive(true);
                //OnQTESuccess();
            }
            
         
        }
        }
        
        }
        
       
        
       

    }*/
    
    public void ShowNextQTE()
    {
        // 判断是否生成了所有 QTE
        if (currentQTEIndex >= currentSequence.Count)
        {
            qteon=false;
            Debug.Log("QTE完成");
            //GameEventSystem.instance.QTEfinished();
            currentQTEIndex=0;
            GenerateSequence();
            PlayerController.isPlayerInQte = false;
            Destroy(gameObject);
            return;
        }

        // 生成并显示一个新 QTE
        GameObject currentQTE=Instantiate(qte,qtesystem.transform.position,Quaternion .identity );
        currentQTE.transform .SetParent (qtesystem.transform );
       
        processcontrol controller = currentQTE.GetComponent<processcontrol>();
        processcontrol.qteok=true;
        controller.SetKey(currentSequence[currentQTEIndex]);
        currentKey=currentSequence[currentQTEIndex];
        currentQTEIndex++;
        print("生成成功");
    }
     public void OnQTESuccess()
    {
        if(qteon==true)
        {
       if(processcontrol.qteok==false)
       {
        ShowNextQTE();
        print("生成下一个");
       }
        }
    }
    public void OnQTEFail()
    {
        // 玩家做出错误反应，重置所有数据，重新生成按键序列并显示第一个 QTE
        currentQTEIndex = 0;
        Destroy(currentQTE);
        GenerateSequence();
        ShowNextQTE();
    }
     void GenerateSequence()
    {
        
        // 随机生成按键序列
        currentSequence = new List<KeyCode>();
        int sequenceLength = Random.Range(minqtetimes,maxqtetimes); // 按键序列长度随机 3-5
        for (int i = 0; i < sequenceLength; i++)
        {
            int keyIndex = Random.Range(0, 7);
            currentSequence.Add(possibleKeys[keyIndex]);
        }
        print(currentSequence.Count);
        sequenceLength = Random.Range(3,5);
    }
    public void keytoshowqte()
    {
        
           // win.SetActive(false);
            //fail.SetActive(false);
            ShowNextQTE();
            Destroy(currentQTE);
           PlayerController.isPlayerInQte = true;
           
          // player.GetComponent<PlayerController>().enabled = false;
           
           
    }
    
  

    private void Start()
    {
        // 随机生成按键序列
        GenerateSequence();
        qtetodoclick=click;
        qtetodoclickmore=clickmore;
        speed=thespeed;
        raise=theraise;
        qtesystem=GameObject.Find("qtesystem 1");
        player=GameObject.Find("Player");
    }
   
   private void Update()
   { 
     OnQTESuccess();
    
    // qtetodoclick();
     //qtetodoclickmore();
     
   }
}
/*public class QTEController : MonoBehaviour
{
    public Text keyText;        // 显示按键的文本对象
    public AudioSource successAudio;   // 当玩家按下正确按键时播放的音效
    public AudioSource failAudio;      // 当玩家按下错误按键时播放的音效

    private KeyCode currentKey;    // 当前的按键

    // 定义可能的按键列表
    private KeyCode[] possibleKeys = {KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.Space};

    void OnEnable()
    {
        // 随机选择一个按键
        currentKey = possibleKeys[Random.Range(0, possibleKeys.Length)];
        keyText.text = currentKey.ToString();
    }

    void Update()
    {
        // 检查玩家是否按下了正确的按键
        if (Input.GetKeyDown(currentKey))
        {
            successAudio.Play();
            // 做出正确反应
            gameObject.SendMessageUpwards("OnQTESuccess", SendMessageOptions.RequireReceiver);
        }
        else if (Input.anyKeyDown)
        {
            failAudio.Play();
            // 做出错误反应
            gameObject.SendMessageUpwards("OnQTEFail", SendMessageOptions.RequireReceiver);
        }
    }
}
public class QTEManager : MonoBehaviour
{
    public GameObject qtePrefab;

    void Awake()
    {
        qtePrefab = Resources.Load<GameObject>("QTEPrefab"); // 从 Resources 文件夹中加载预制件
    }

    void ShowNextQTE()
    {
        GameObject qteObject = Instantiate(qtePrefab);
        // ...
    }
}
// 在 qteSystem 空对象下实例化 QTE UI 预制件
GameObject qteObject = Instantiate(qteSystem.qtePrefab);
qteObject.transform.SetParent(qteSystem.transform);  // 设置其父对象为 qteSystem
qteObject.transform.localPosition = Vector3.zero;     // 可以自定义位置


public class QTEManager : MonoBehaviour
{
    public GameObject qtePrefab;    // QTE预制件，包含 QTEController 脚本

    private List<KeyCode> currentSequence;   // 当前的按键序列
    private int currentQTEIndex;             // 当前 QTE 的序号
    private GameObject currentQTE;           // 当前显示的 QTE 对象

    // 定义可能的按键列表
    private KeyCode[] possibleKeys = {KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.Space};

    void Start()
    {
        // 随机生成按键序列
        GenerateSequence();
        // 显示第一个 QTE
        ShowNextQTE();
    }

    void ShowNextQTE()
    {
        // 判断是否生成了所有 QTE
        if (currentQTEIndex >= currentSequence.Count)
        {
            Debug.Log("QTE完成");
            return;
        }

        // 生成并显示一个新 QTE
        currentQTE = Instantiate(qtePrefab, transform);
        QTEController controller = currentQTE.GetComponent<QTEController>();
        controller.SetKey(currentSequence[currentQTEIndex]);

        currentQTEIndex++;
    }

    void OnQTESuccess()
    {
        // 玩家做出正确反应，显示下一个 QTE
        Destroy(currentQTE);
        ShowNextQTE();
    }

    void OnQTEFail()
    {
        // 玩家做出错误反应，重置所有数据，重新生成按键序列并显示第一个 QTE
        currentQTEIndex = 0;
        Destroy(currentQTE);
        GenerateSequence();
        ShowNextQTE();
    }

    void GenerateSequence()
    {
        // 随机生成按键序列
        currentSequence = new List<KeyCode>();
        int sequenceLength = Random.Range(3, 6); // 按键序列长度随机 3-5
        for (int i = 0; i < sequenceLength; i++)
        {
            int keyIndex = Random.Range(0, possibleKeys.Length);
            currentSequence.Add(possibleKeys[keyIndex]);
        }
    }
}*/
