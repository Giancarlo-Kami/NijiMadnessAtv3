using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            GameManager.playerDamage += GameManager.playerDamage /4;
            this.GetComponent<SpriteRenderer>().color = Color.blue;
            Destroy(this);
        }
    }
}
