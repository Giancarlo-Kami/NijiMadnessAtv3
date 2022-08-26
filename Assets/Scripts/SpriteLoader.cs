using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLoader : MonoBehaviour
{
    // Start is called before the first frame update
    private string spriteName;
    private SpriteRenderer sprite;


    void Awake()
    {
        if(GameManager.charSelected == 1)
            {
                spriteName = "Sprites/Finana";
            }
        else if(GameManager.charSelected == 2)
            {
                spriteName = "Sprites/Pomu";
            }
        else
            {
                spriteName = "Sprites/Elira";
            }

        var go = new GameObject("Sprite");
        go.transform.parent = this.transform;
        go.transform.position = new Vector3(this.transform.position.x,this.transform.position.y ,this.transform.position.z);
        go.transform.localScale = new Vector3(1f,1f,1f);
        sprite = go.AddComponent<SpriteRenderer>();
        sprite.sprite = Resources.Load<Sprite>(spriteName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
