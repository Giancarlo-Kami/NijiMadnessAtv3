using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float maxSpeed;
    Rigidbody2D rb;
    private SpriteRenderer sprite;
    private string spriteName;
    private string gunName;
    private GameObject gun;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        Collider2D collider = GetComponent<Collider2D>();

        maxSpeed = speed;
        if(GameManager.charSelected == 1)
            {
                spriteName = "Sprites/Finana";
                gunName = "Prefabs/gunPrefab1";
            }
        else if(GameManager.charSelected == 2)
            {
                spriteName = "Sprites/Pomu";
                gunName = "Prefabs/gunPrefab2";
            }
        else
            {
                spriteName = "Sprites/Elira";
                gunName = "Prefabs/gunPrefab3";
            }


        var go = new GameObject("Sprite");
        go.transform.parent = this.transform;
        go.transform.position = new Vector3(this.transform.position.x,this.transform.position.y ,this.transform.position.z);
        go.transform.localScale = new Vector3(2f,2f,2f);
        sprite = go.AddComponent<SpriteRenderer>();
        sprite.sprite = Resources.Load<Sprite>(spriteName);

        gun = Resources.Load<GameObject>(gunName);
        Instantiate(gun,gameObject.transform);
        GameManager.counterSp();
    }
    private void FixedUpdate()
    {
        KeyCode upKey = KeyCode.W;
        KeyCode downKey = KeyCode.S;
        KeyCode leftKey = KeyCode.A;
        KeyCode rightKey = KeyCode.D;
        KeyCode shift = KeyCode.LeftShift;

        if (Input.GetKey(upKey))
            rb.velocity = Vector2.up * speed;
        else if (Input.GetKey(downKey))
            rb.velocity = Vector2.down * speed;
        else if (Input.GetKey(leftKey))
            rb.velocity = Vector2.left * speed;
        else if (Input.GetKey(rightKey))
            rb.velocity = Vector2.right * speed;
        else
            rb.velocity = Vector2.zero;
        if (Input.GetKey(shift))
            speed = maxSpeed/2;
        else
            speed = maxSpeed;
    }
    private void Update()
    {
        KeyCode space = KeyCode.Space;

        if (Input.GetKeyDown(space))
            gun.GetComponent<GunPrefab>().specialAttack();

    }

}
