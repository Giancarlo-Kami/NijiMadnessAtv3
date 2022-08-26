using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnParticleEnemy : MonoBehaviour
{
    void Start()
    {
        GameManager.playerDamage = 1;
    }
    private void OnParticleCollision(GameObject other) {
        if (other.tag == "Enemy"){
            other.GetComponent<VidaController>().ControlaVida(false,GameManager.playerDamage);
        }
    }
    void Update()
    {
        
    }
}
