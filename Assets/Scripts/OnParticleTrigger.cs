using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnParticle : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake(){
    }



    private void OnParticleCollision(GameObject other) {
        if (other.tag == "Player")
            other.GetComponent<VidaController>().ControlaVida(false,1);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
