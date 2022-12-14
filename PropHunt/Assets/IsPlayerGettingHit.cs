using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;


public class IsPlayerGettingHit : MonoBehaviour

{
    public bool isMyNetworkedPlayerDead = false;
    public int HPIntVal = 100;
    [SerializeField] TextMeshProUGUI m_Object;

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collision detected with object: " + collision.gameObject.name);
        if (collision.gameObject.tag == "Bullet") {
            int temp;
            int.TryParse(m_Object.text, out temp);
            GameObject co = gameObject;
            float meshArea = 0.8f+co.gameObject.GetComponent<MeshFilter>().mesh.bounds.size.x * co.gameObject.GetComponent<MeshFilter>().mesh.bounds.size.y * co.gameObject.GetComponent<MeshFilter>().mesh.bounds.size.z;
            float hpToLose = (1 / (meshArea * 1.2f))*49f;
            temp = temp  - (int)hpToLose;

            HPIntVal = temp;
            Debug.Log("Test String " + temp.ToString());

            m_Object.text = temp.ToString();
        }
        if(isMyNetworkedPlayerDead)
        {
            Destroy(gameObject);
        }

    }




}
