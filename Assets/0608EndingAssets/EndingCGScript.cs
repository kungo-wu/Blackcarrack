using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class EndingCGScript : MonoBehaviour
{
    public GameObject Cloud;
    public GameObject BackGround;
    public GameObject SpecialCG;
    public Image CloudImage;
    public Image BackGroundImage;

    [SerializeField]
    private Sprite backGroundBright;
    [SerializeField]
    private Sprite backGroundDark;
    [SerializeField]
    private Sprite cloudWhite;
    [SerializeField]
    private Sprite cloudBlack;

    //0���� 1���� 2���� 3���� 4�� 5����
    public int endingBranch = 0;
    
    
     GameObject AugurAlive;
     GameObject CaptainAlive;
     GameObject ChefAlive;
     GameObject FirstMateAlive;
     GameObject MerchantAlive;
     GameObject ServantAlive;
     GameObject[] NPCS=new GameObject[6];

    public static bool isWorshipStopped=false;

     static bool isAugurAlive;
     static bool isCaptainAlive;
     static bool isChefAlive;
     static bool isFirstMateAlive;
     static bool isMerchantAlive;
     static bool isServantAlive;
     int activatedNPCsInEnding=0;

    public TextMeshProUGUI textCompoent;
    public string[] lines;
    public float textSpeed;

    private int index;

    private string text00 = "我想乌鸦的决定是正确的，没人知道这艘船究竟会驶向哪个地方。数日后，船只奇迹般又驶回了我们居住的大陆";
    private string text01 = "我想乌鸦的决定是正确的，没人知道这艘船究竟会驶向哪个地方。数日后，船只依旧在这片茫茫无边的大海上航行，我不知道船会开到哪里，我们的未来在哪里……";
    private string text02 = "我破坏了乌鸦的邪恶仪式，我们的船依旧平稳航行在原本计划的路线上,船只自己停靠在了一片黑暗的海域，这里比我们原先居住的腐坏的大陆更加恐怖和扭曲，我想我们做了一个错误的决定……";
    private string text03 = "我破坏了乌鸦的邪恶仪式，我们的船依旧平稳航行在原本计划的路线上，但是大家都不在了，只有我一个人……";
    private string text04 = "我想乌鸦的决定是正确的，没人知道这艘船究竟会驶向哪个地方。数日后，船只依旧在这片茫茫无边的大海上航行，我不知道船会开到哪里，我们的未来在哪里……";
    private string text05 = "我破坏了乌鸦的邪恶仪式，我们的船依旧平稳航行在原本计划的路线上，数日后，船只依旧在这片茫茫无边的大海上航行，我不知道船会开到哪里，但是大家都有一种很不祥的预感";
    private string text06 = "报错";


    private void Awake()
    {
        lines = new string[7];
        lines[0] = text00;
        lines[1] = text01;
        lines[2] = text02;
        lines[3] = text03;
        lines[4] = text04;
        lines[5] = text05;
        lines[6] = text06;


        //��ʽ����ֹ���
        //isWorshipStopped = true;

        //��ɫ�������
        isAugurAlive = true;
        isCaptainAlive = true;
        isChefAlive = true;
        isFirstMateAlive = true;
        isMerchantAlive = true;
        isServantAlive = true;
        

    }
    // Start is called before the first frame update
    void Start()
    {
        textCompoent.text = string.Empty;
        
        GetNPCsInScene();
        GetBackgroundAndCloudAndSpecial();
        ShowNPCs();
        SetBackgroundSituation();
        ShowBackgroundAndCloud();
        StartDialogue();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void GetNPCsInScene()
    {
        //NPCS.Length==6
        NPCS = GameObject.FindGameObjectsWithTag("NPCAlive");

        AugurAlive = GameObject.Find("AugurAlive");
        CaptainAlive = GameObject.Find("CaptainAlive");
        ChefAlive = GameObject.Find("ChefAlive");
        FirstMateAlive = GameObject.Find("FirstMateAlive");
        MerchantAlive = GameObject.Find("MerchantAlive");
        ServantAlive = GameObject.Find("ServantAlive");
        
     
    }
    void ShowNPCs()
    {
        if (!GameObject.Find("astrologer").GetComponent<npcstate>().death)
        {
            AugurAlive.SetActive(true);
        }
        else
        {
            AugurAlive.SetActive(false);
        }

        if (!GameObject.Find("Captain ").GetComponent<npcstate>().death)
        {
            CaptainAlive.SetActive(true);
        }
        else
        {
            CaptainAlive.SetActive(false);
        }

        if (!GameObject.Find("firstmate").GetComponent<npcstate>().death) 
        {
            FirstMateAlive.SetActive(true);
        }
        else
        {
            FirstMateAlive.SetActive(false);
        }

        if (!GameObject.Find("merchant").GetComponent<npcstate>().death) 
        {
            MerchantAlive.SetActive(true);
        }
        else
        {
            MerchantAlive.SetActive(false);
        }

        if (!GameObject.Find("servant").GetComponent<npcstate>().death)
        {
            ServantAlive.SetActive(true);
        }
        else
        {
            ServantAlive.SetActive(false);
        }

        if (!GameObject.Find("chef").GetComponent<npcstate>().death)
        {
            ChefAlive.SetActive(true);
        }    
        else
        {
            ChefAlive.SetActive(false);
        }

        //get the number of activatedNPC
        for (int i = 0; i < NPCS.Length; i++)
        {
            if (NPCS[i].activeInHierarchy==true)
            {
                activatedNPCsInEnding++;
            }
        }

        Debug.Log("The number of activated NPCs is" + activatedNPCsInEnding);
    }

    void GetBackgroundAndCloudAndSpecial()
    {
        BackGroundImage = BackGround.GetComponent<Image>();
        CloudImage=Cloud.GetComponent<Image>();
    }

    void SetBackgroundSituation()
    {
        if (isWorshipStopped)
        {
            if (activatedNPCsInEnding==0)//ȫ��
            {
                //����
                endingBranch = 3;
                GameEventSystem.instance.Temporarychange("ending4");
            }
            else if (activatedNPCsInEnding>0&&activatedNPCsInEnding<6)
            {
                //����
                endingBranch = 5;
                GameEventSystem.instance.Temporarychange("ending15");
            }
            else if(activatedNPCsInEnding==6)
            {
                //����
                endingBranch = 2;
                GameEventSystem.instance.Temporarychange("ending1");
            }
        }
        else//worshipUnstopped
        {
            if (activatedNPCsInEnding == 0)
            {
                //��
                endingBranch = 1;
                GameEventSystem.instance.Temporarychange("ending36");
            }
            else if (activatedNPCsInEnding > 0 && activatedNPCsInEnding < 6)
            {
                //��
                endingBranch = 4;
                GameEventSystem.instance.Temporarychange("ending36");
            }
            else if (activatedNPCsInEnding == 6)
            {
                //��
                endingBranch = 0;
                GameEventSystem.instance.Temporarychange("ending15");
            }
        }
    }

    void ShowBackgroundAndCloud()
    {
        //���죺�ױ�������
        if (endingBranch == 0) 
        {
            
            BackGroundImage.sprite = backGroundBright;
            Cloud.SetActive(false);
            Debug.Log("����CG");
        }
        //���죺�ױ�������
        else if(endingBranch == 1||endingBranch==4)
        {
            BackGroundImage.sprite = backGroundBright;
            Cloud.SetActive(true);
            CloudImage.sprite = cloudWhite;
            Debug.Log("����CG");
        }
        //���죺�ڱ�������
        else if (endingBranch == 2||endingBranch==5)
        {
            BackGroundImage.sprite = backGroundDark;
            Cloud.SetActive(true);
            CloudImage.sprite = cloudBlack;
            Debug.Log("����CG");
        }
        //����cg����ʱ���óɱ�������ʾ
        else if (endingBranch == 3)
        {
            SpecialCG.SetActive(true);
            Debug.Log("����CG");
        }
       
        else
        {
            Debug.Log("EndingBranch=" + endingBranch);
            Debug.Log("�����˷Ƿ��Ľ�ַ�֧");
        }
    }

    void StartDialogue()
    {
        //index = 0;
        switch(endingBranch)
        {
            case 0:index = 0; 
                break;
                case 1:index = 1;
                break;
                case 2:index = 2;
                break;
                case 3:index = 3;
                break;
                case 4:index = 4;
                break;
                case 5:index = 5;
                break;
                case 6:index = 6;
                break;
                default: break;
        }
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textCompoent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    
}
