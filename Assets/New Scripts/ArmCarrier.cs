using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmCarrier : MonoBehaviour
{
    public LayerMask objectLayer;

    [Range(.1f,3)]
    public float tasimaMesafesi = 0.5f; //taşıyıcı ile kutu arası mesafe

    private void Update()
    {
        MeshCollider mesh = GetComponent<MeshCollider>();
        RaycastHit hit;

        Physics.Raycast(mesh.bounds.center, Vector3.down, out hit, 3f, objectLayer);

    if (GetComponentInParent<ArmTurn>().asama == 1)
        {
            hit.collider.transform.position = GetComponent<Transform>().position - Vector3.up*tasimaMesafesi;
            hit.collider.transform.rotation = GetComponent<Transform>().rotation;
            hit.collider.GetComponent<Rigidbody>().isKinematic = true;
        }

    else if (GetComponentInParent<ArmTurn>().asama == 2 && hit.collider != null)
        {
        hit.collider.GetComponent<Rigidbody>().isKinematic = false;
            GameObject.Find("carrier").GetComponent<Animator>().SetBool("YukGeldi",true);
            GameObject.Find("carrier").GetComponent<Animator>().SetBool("YukGitti",false);
            GetComponentInParent<ArmTurn>().asama = 3;
        }
    }
    
    

}
