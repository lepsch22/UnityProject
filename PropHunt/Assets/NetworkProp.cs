using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class NetworkProp : MonoBehaviour
{
    public Transform propLocationTransform;
    public string currMesh;
    //public Transform leftHand;
    //public Transform rightHand;
    //public GameObject CameraController;
    //public GameObject leftHandController;
    public GameObject rightHandController;
    public GameObject propLocationObject;
    public GameObject XROrigin;
    public GameObject Background_Music;

    public GameObject collidedObject;
    private PhotonView photonView;
    public GameObject[] players;

    private int audioClipListNum = 0;
    private int audioClipIndex=0;
    AudioClip[] rareClipArray;
    AudioClip[] hyperRareArray;
    AudioClip[] basicClipArray;

    AudioSource childAudioSource;

    void Start()
    {
        Background_Music = GameObject.Find("BackGround_Music");
        rareClipArray = Background_Music.GetComponent<songList>().rareClipArray;
        hyperRareArray = Background_Music.GetComponent<songList>().hyperRareArray;
        basicClipArray = Background_Music.GetComponent<songList>().basicClipArray;
        rightHandController = GameObject.Find("RightHand Controller");
        XROrigin = GameObject.Find("PlayerPropNew(Clone)");
        Background_Music = GameObject.Find("BackGround_Music");
        childAudioSource = GetComponentInChildren<AudioSource>();
        photonView = GetComponent<PhotonView>();
        if (photonView.IsMine) {
            InvokeRepeating("checkAudioPlay", 3, 3);
        }
    }
    

    void Update()
    {
        photonView = GetComponent<PhotonView>();
        if (photonView.IsMine)
        {
            rightHandController = GameObject.Find("RightHand Controller");
            XROrigin = GameObject.Find("PlayerPropNew(Clone)");
            propLocationObject.SetActive(false);
            if (XROrigin.GetComponent<IsPlayerGettingHit>().HPIntVal < 100) {
                XROrigin.GetComponent<IsPlayerGettingHit>().isMyNetworkedPlayerDead = true;
                PhotonNetwork.Destroy(gameObject);
                
            }

            MapPosition(propLocationTransform, XROrigin);
            if (rightHandController.GetComponent<PropRay>().propChanged)
            {
                ChangeMesh();
                rightHandController.GetComponent<PropRay>().propChanged = false;
            }
        }
    }
    void MapPosition(Transform target, GameObject Device)
    {
        target.position = Device.transform.position;
        target.rotation = Device.transform.rotation;
    }
    public void ChangeMesh()
    {
        // Call the RPC method on all other clients.
        collidedObject = rightHandController.GetComponent<PropRay>().collidedObject;
        string meshTag = collidedObject.tag;
        Debug.Log("Collided Mesh Tag" + meshTag);
        photonView.RPC("ChangeMeshRPC", RpcTarget.All,meshTag);
    }

    [PunRPC]
    public void ChangeMeshRPC(string meshTag)
    {
        // Change the mesh on all clients (except the one that called the RPC method).
        var obj = GameObject.FindWithTag(meshTag);
        Mesh mesh = obj.GetComponent<MeshFilter>().mesh;
        Debug.Log("Send/RecieverRPC");
        currMesh = meshTag;
        propLocationObject.GetComponent<MeshFilter>().mesh = mesh;
        propLocationObject.GetComponent<MeshRenderer>().materials = obj.GetComponent<MeshRenderer>().materials;

    }
    [PunRPC]
    void playSoundNetworked(int listNum, int clipIndex)
    {
        Debug.Log("RPC Play Random Sound");
        if (listNum == 0){
            childAudioSource.clip = basicClipArray[clipIndex];
        }
        else if (listNum == 1) {
            childAudioSource.clip = rareClipArray[clipIndex];
        }
        else if (listNum == 2){
            childAudioSource.clip = hyperRareArray[clipIndex];
        }
        childAudioSource.Play();
    }
    void checkAudioPlay() {
        if (photonView.IsMine)
        {
            Debug.Log("CheckAudioPlay");

            if (Random.Range(0, 6) == 2)
            {
               
                Debug.Log("Select a Song.");
                int randNum = Random.Range(0, 100);
                rareClipArray = Background_Music.GetComponent<songList>().rareClipArray;
                hyperRareArray = Background_Music.GetComponent<songList>().hyperRareArray;
                basicClipArray = Background_Music.GetComponent<songList>().basicClipArray;

                if (randNum <= 70)
                {
                    audioClipIndex = Random.Range(0, basicClipArray.Length);
                    audioClipListNum = 0;
                }
                else if (randNum >= 71 && randNum <= 95)
                {
                    audioClipListNum = 1;
                    audioClipIndex = Random.Range(0, rareClipArray.Length);
                }
                else if (randNum >= 95 && randNum <= 100)
                {
                    audioClipListNum = 2;
                    audioClipIndex = Random.Range(0, hyperRareArray.Length);
                }
                XROrigin.GetComponent<playAudioClip>().playAudio(audioClipListNum, audioClipIndex);
                photonView.RPC("playSoundNetworked", RpcTarget.All, audioClipListNum, audioClipIndex);

            }
        }
        
    }

}
