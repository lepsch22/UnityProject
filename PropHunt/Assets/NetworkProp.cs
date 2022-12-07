using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class NetworkProp : MonoBehaviour
{
    public Transform propLocationTransform;
    //public Transform leftHand;
    //public Transform rightHand;
    //public GameObject CameraController;
    //public GameObject leftHandController;
    public GameObject rightHandController;
    public GameObject propLocationObject;
    public GameObject XROrigin;
    private PhotonView photonView;
    void Start()
    {
        //localPlace = GameObject.Find("Network Player Hunter").transform;
        //if (photonView.IsMine){
        //CameraController = GameObject.Find("Main Camera");
        //leftHandController = GameObject.Find("LeftHand Controller");
        rightHandController = GameObject.Find("RightHand Controller");
        photonView = GetComponent<PhotonView>();
        //}

    }

    void Update()
    {
        photonView = GetComponent<PhotonView>();
        if (photonView.IsMine)
        {
            //Debug.Log("My View");
            //leftHand.gameObject.SetActive(false);
            //rightHand.gameObject.SetActive(false);
            //Head.gameObject.SetActive(false);
            //MapPosition(leftHand, leftHandController);
            //MapPosition(Head, CameraController);
            //MapPosition(rightHand, rightHandController);
            MapPosition(propLocationTransform, XROrigin);
        }

    }
    void MapPosition(Transform target, GameObject Device)
    {

        target.position = Device.transform.position;
        target.rotation = Device.transform.rotation;

    }
}
