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
    public GameObject collidedObject;
    private PhotonView photonView;
    public GameObject[] players;
    
    void Start()
    {
        rightHandController = GameObject.Find("RightHand Controller");
        XROrigin = GameObject.Find("PlayerPropNew(Clone)");
        photonView = GetComponent<PhotonView>();
        /*
        if(photonView.IsMine){
            players = GameObject.FindGameObjectsWithTag("PlayerPropNetworked");
            foreach(GameObject obj in players){
                if(!obj.GetPhotonView().IsMine){
                var objToTurnInto = GameObject.FindWithTag(obj.GetComponent<NetworkProp>().currMesh);
                obj.GetComponentInChildren<MeshFilter>().mesh = objToTurnInto.GetComponent<MeshFilter>().mesh;
                obj.GetComponentInChildren<MeshRenderer>().materials = objToTurnInto.GetComponent<MeshRenderer>().materials;          
                }
            }
        }
        */
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
        //propLocationObject.transform.rotation = obj.transform.rotation;
        //propLocationObject.transform.position = new Vector3(propLocationObject.transform.position.x, propLocationObject.transform.position.y + 0.5f, propLocationObject.transform.position.z);
    }
}
