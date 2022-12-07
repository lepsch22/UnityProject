using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;

public class NetworkHunter : MonoBehaviour
{
    public Transform Head;
    public Transform leftHand;
    public Transform rightHand;
    public GameObject CameraController;
    public GameObject leftHandController;
    public GameObject rightHandController;
    private PhotonView photonView;
    void Start()
    {
        //localPlace = GameObject.Find("Network Player Hunter").transform;
        if (photonView.IsMine){
            CameraController = GameObject.Find("Main Camera");
            leftHandController = GameObject.Find("LeftHand Controller");
            rightHandController = GameObject.Find("RightHand Controller");
            photonView = GetComponent<PhotonView>();
        }

    }

    void Update()
    {
        photonView = GetComponent<PhotonView>();
        if (photonView.IsMine)
        {
            Debug.Log("My View");
            leftHand.gameObject.SetActive(false);
            rightHand.gameObject.SetActive(false);
            Head.gameObject.SetActive(false);
            MapPosition(leftHand, leftHandController);
            MapPosition(Head, CameraController);
            MapPosition(rightHand, rightHandController);
        }
        if (!photonView.IsMine) {
            Debug.Log("Not My View");
        }
    }
    void MapPosition(Transform target, GameObject Device) 
    {

        target.position = Device.transform.position;
        target.rotation = Device.transform.rotation;

    }
}
