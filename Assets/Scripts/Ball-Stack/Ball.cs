using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject stack;

    public ParticleSystem dmparticle;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        string mName = other.gameObject.GetComponent<MeshRenderer>().material.name;
        Debug.Log("tag ===>     " + other.gameObject.tag);
        Debug.Log("mname ===>     " + mName);

        if (mName == "Material.002 (Instance)" || mName == "Danger (Instance)"){
            if (mName == "Material.002 (Instance)"){
               // GameManager.instance.increaseScore();
            }
            // StackCreator sn = stack.GetComponent<StackCreator>();
            // sn.removeCubeFromArray(other.gameObject);
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            
        }else if (mName == "Pink (Instance)"){
            
            Instantiate(dmparticle,other.gameObject.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            // Destroy(this.gameObject);
        }
    }
}
