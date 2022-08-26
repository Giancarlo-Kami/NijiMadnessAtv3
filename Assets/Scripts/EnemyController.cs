using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    float sinCenterY;
    public float amp = 0.5f;
    public float freq = 3f;
    private int sig = 1;
    public float step = 0.01f;

    void Awake()
    {
        sinCenterY = transform.position.y;
    }

    private void FixedUpdate() {        
        Vector2 pos = transform.position;
        if(pos.x < -1.5 && sig == -1){
            sig = 1;
        }else if(pos.x > 1.5 && sig == 1){
            sig = -1;
        }
        pos.x += (step * sig);
        transform.position = pos;

        float sin = Mathf.Sin(pos.x * freq) * amp;
        pos.y = sinCenterY + sin;
        transform.position = pos;
        transform.Find("spriteEnemy").rotation = Quaternion.Euler(0,0,0);

    }
}
