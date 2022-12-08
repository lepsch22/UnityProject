using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;


public class IsPlayerGettingHit : MonoBehaviour

{
    public bool isMyNetworkedPlayerDead;
    public int HPIntVal = 100;
    [SerializeField] TextMeshProUGUI m_Object;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with object: " + collision.gameObject.name);
        if (collision.gameObject.tag == "Bullet") {
            int temp;
            int.TryParse(m_Object.text, out temp);
            temp = temp  - 49;
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
