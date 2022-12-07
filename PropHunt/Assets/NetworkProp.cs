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
        XROrigin = GameObject.Find("PlayerPropNew(Clone)");
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
        if(rightHandController.GetComponent<PropRay>().propChanged){
            var obj = XROrigin;
            Mesh mesh = obj.GetComponent<MeshFilter>().mesh;
            Mesh mesh2 = Instantiate(mesh);
            propLocationObject.GetComponent<MeshCollider>().sharedMesh = mesh2;
            propLocationObject.GetComponent<MeshFilter>().mesh = mesh2;
            propLocationObject.GetComponent<MeshRenderer>().material = obj.GetComponent<MeshRenderer>().material;
            propLocationObject.transform.rotation = obj.transform.rotation;
            propLocationObject.transform.position = new Vector3(propLocationObject.transform.position.x, propLocationObject.transform.position.y + 0.5f, propLocationObject.transform.position.z);
            rightHandController.GetComponent<PropRay>().propChanged = false;
        }

    }
    void MapPosition(Transform target, GameObject Device)
    {
        target.position = Device.transform.position;
        target.rotation = Device.transform.rotation;

    }
}
