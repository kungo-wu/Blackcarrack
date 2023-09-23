using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class musiccontrol : MonoBehaviour
{
    public AudioSource audiosingle;
    public AudioSource audiowalk;
    public AudioSource audioback;
    public AudioClip[] musicClips;
    
    // Start is called before the first frame update
    void Start()
    {
        GameEventSystem.instance.onTemporarychange+=audioplay;
        
    }
     void OnDisable()
     {
         GameEventSystem.instance.onTemporarychange-=audioplay;
     }
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position=GameObject.Find("Player").transform.position;
        if(GameObject.Find("Player").GetComponent<Animator>().GetFloat("Speed")!=0f)
        {
            Debug.Log("移动");
            if (!audiowalk.isPlaying)
            audiowalk.Play();
        }
        else
        {
            if (audiowalk.isPlaying)
            audiowalk.Stop();
        }
       if(SceneManager.GetActiveScene().name=="Deck(Ship)"||SceneManager.GetActiveScene().name=="Deck(First)")
       {
         audioback.volume=1f;
         if (!audioback.isPlaying)
             audioback.Play();
       }
       else if(SceneManager.GetActiveScene().name!="Start")
       {
            audioback.volume=0.3f;
            if (!audioback.isPlaying)
            audioback.Play();
       }
    }
    public void audioplay(string _id)
    {
        if(_id=="opendoor")
        {
            audiosingle.clip = musicClips[0];
            audiosingle.Play();
        }
        if(_id=="puzzlecomplete")
        {
             audiosingle.clip = musicClips[1];
            audiosingle.Play();
        }
        if(_id=="openbag")
        {
             audiosingle.clip = musicClips[2];
            audiosingle.Play();
        }
        if(_id=="qtestart")
        {
            audiosingle.clip = musicClips[3];
            audiosingle.Play();
        }
        if(_id=="pickitem")
        {
            audiosingle.clip = musicClips[4];
            audiosingle.Play();
        }
        if(_id=="fishcomplete")
        {
            audiosingle.clip = musicClips[5];
            audiosingle.Play();
        }
        if(_id=="ending1")
        {
            audiosingle.clip = musicClips[6];
            audiosingle.Play();
        }
        if(_id=="ending4")
        {
            audiosingle.clip = musicClips[7];
            audiosingle.Play();
        }
        if(_id=="ending15")
        {
            audiosingle.clip = musicClips[8];
            audiosingle.Play();
        }
        if(_id=="ending36")
        {
            audiosingle.clip = musicClips[9];
            audiosingle.Play();
        }

    }
    
}
