using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAudioClip : MonoBehaviour
{
    public int audioClipListNum;
    AudioClip[] rareClipArray;
    AudioClip[] hyperRareArray;
    AudioClip[] basicClipArray;
    public GameObject Background_Music;
    // Start is called before the first frame update
    void Start()
    {
        Background_Music = GameObject.Find("BackGround_Music");
        rareClipArray = Background_Music.GetComponent<songList>().rareClipArray;
        hyperRareArray = Background_Music.GetComponent<songList>().hyperRareArray;
        basicClipArray = Background_Music.GetComponent<songList>().basicClipArray;

    }

    // Update is called once per frame
    public void playAudio(int audioClipListNum, int audioClipIndex)
    {
        if (audioClipListNum == 0)
        {
            GetComponent<AudioSource>().clip = basicClipArray[audioClipIndex];
        }
        else if (audioClipListNum == 1)
        {
            GetComponent<AudioSource>().clip = rareClipArray[audioClipIndex];
        }
        else if (audioClipListNum == 2)
        {
            GetComponent<AudioSource>().clip = hyperRareArray[audioClipIndex];
        }
        GetComponent<AudioSource>().Play();
    }
}
