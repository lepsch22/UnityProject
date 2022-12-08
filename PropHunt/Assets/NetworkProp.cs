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
    public GameObject collidedObject;
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
            if (XROrigin.GetComponent<IsPlayerGettingHit>().HPIntVal < 100) {
                XROrigin.GetComponent<IsPlayerGettingHit>().isMyNetworkedPlayerDead = true;
                PhotonNetwork.Destroy(gameObject);
                
            }

            MapPosition(propLocationTransform, XROrigin);
            if (rightHandController.GetComponent<PropRay>().propChanged)
            {
                //collidedObject = rightHandController.GetComponent<PropRay>().collidedObject;
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
        photonView.RPC("ChangeMeshRPC", RpcTarget.All);
    }

    [PunRPC]
    void ChangeMeshRPC()
    {
        // Change the mesh on all clients (except the one that called the RPC method).


        var obj = XROrigin;
        Mesh mesh = obj.GetComponent<MeshFilter>().mesh;
        Debug.Log("Send/RecieverRPC");
        propLocationObject.GetComponent<MeshFilter>().mesh = mesh;
        propLocationObject.GetComponent<MeshRenderer>().material = obj.GetComponent<MeshRenderer>().material;
        propLocationObject.transform.rotation = obj.transform.rotation;
        propLocationObject.transform.position = new Vector3(propLocationObject.transform.position.x, propLocationObject.transform.position.y + 0.5f, propLocationObject.transform.position.z);
    }
}
