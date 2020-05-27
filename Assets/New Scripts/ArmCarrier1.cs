using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmCarrier1 : MonoBehaviour
{
    public LayerMask objectLayer;

    [Range(.1f,3)]
    public float tasimaMesafesi = 0.5f; //taşıyıcı ile kutu arası mesafe

    private void Update()
    {
        MeshCollider mesh = GetComponent<MeshCollider>();
        RaycastHit hit;

        if (GameObject.Find("carrier").GetComponent<Transform>().position.z < -8f && GameObject.Find("carrier").GetComponent<Animator>().GetBool("YukGeldi"))
        {
            GetComponentInParent<ArmTurn1>().yap();
            GameObject.Find("carrier").GetComponent<Animator>().SetBool("YukGeldi", false);
        }

        Physics.Raycast(mesh.bounds.center, Vector3.down, out hit, 3f, objectLayer);

    if (GetComponentInParent<ArmTurn1>().asama == 1)
        {
            hit.collider.transform.position = GetComponent<Transform>().position - Vector3.up*tasimaMesafesi;
            hit.collider.transform.rotation = GetComponent<Transform>().rotation;
            hit.collider.GetComponent<Rigidbody>().isKinematic = true;
        }

    else if (GetComponentInParent<ArmTurn1>().asama == 2 && hit.collider != null)
        {
            GameObject.Find("carrier").GetComponent<Animator>().SetBool("YukGitti", true);
            GameObject.Find("carrier").GetComponent<Animator>().SetBool("YukGeldi", false);
            hit.collider.GetComponent<Rigidbody>().isKinematic = false;
            GetComponentInParent<ArmTurn1>().asama = 3;
        }
    }
    
    

}
