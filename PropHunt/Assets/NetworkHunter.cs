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
    //public Transform localPlace;
    //InputDevice leftController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
    // Start is called before the first frame update
    void Start()
    {
        //localPlace = GameObject.Find("Network Player Hunter").transform;
        CameraController = GameObject.Find("Main Camera");
        leftHandController = GameObject.Find("LeftHand Controller");
        rightHandController = GameObject.Find("rightHand Controller");
        photonView = GetComponent<PhotonView>();

    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            //CameraController = GameObject.Find("Main Camera");
            Head.transform.position = CameraController.transform.position;
            Head.transform.rotation = CameraController.transform.rotation;
            leftHand.position = leftHandController.transform.position;
            leftHand.rotation = leftHandController.transform.rotation;
            rightHand.position = rightHand.transform.position;
            rightHand.rotation = rightHand.transform.rotation;
        }

        //MapPosition(Head, XRNode.Head);
        // MapPosition(leftHand, XRNode.LeftHand);
        //MapPosition(rightHand, XRNode.RightHand);
        //Target.transform.position = localPlace.position;
        //Target.transform.rotation = localPlace.rotation;


    }
    void MapPosition(Transform target, XRNode node) 
    {
        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 postion);

        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation);

        target.position = postion;
        target.rotation = rotation;

    }
}
