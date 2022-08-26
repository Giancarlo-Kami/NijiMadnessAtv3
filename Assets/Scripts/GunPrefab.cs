using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPrefab : MonoBehaviour
{
    public ParticleSystem system;
    public float speed;
    public Sprite texture;
    public Color color;
    public float lifetime;
    public float size;
    public float firerate;
    public Material material;
    public int damage;
    public Sprite gunModel;
    private SpriteRenderer gunRender;
    private GameObject child;
    void Awake()
    {

        Summon();


    }
    void Summon()
    {

        child = new GameObject("Sprite");
        child.transform.parent = gameObject.transform;
        child.transform.position = new Vector3(gameObject.transform.position.x - 0.3f,gameObject.transform.position.y,gameObject.transform.position.z);
        child.transform.Rotate(90,270,0);
        child.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
        gunRender = child.AddComponent<SpriteRenderer>();
        gunRender.sprite = gunModel;

        gameObject.transform.rotation = Quaternion.Euler(270,0,0);

        Material particleMaterial = material;
        system = gameObject.AddComponent<ParticleSystem>();
        GetComponent<ParticleSystemRenderer>().material = particleMaterial;

        var mainModule = system.main;
        mainModule.startSpeed = speed;
        mainModule.simulationSpace = ParticleSystemSimulationSpace.World;
        mainModule.scalingMode = ParticleSystemScalingMode.Hierarchy;

        var emission = system.emission;
        emission.enabled = false;

        var shape = system.shape;
        shape.enabled = true;
        shape.shapeType = ParticleSystemShapeType.Sprite;
        shape.sprite = null;

        var text = system.textureSheetAnimation;
        text.mode = ParticleSystemAnimationMode.Sprites;
        text.AddSprite(texture);
        text.enabled = true;

        var col = system.collision;
        col.enabled = true;
        col.lifetimeLoss = 5;
        col.type = ParticleSystemCollisionType.World;
        col.mode = ParticleSystemCollisionMode.Collision2D;
        col.collidesWith = LayerMask.GetMask("Enemy");
        col.sendCollisionMessages = true;

        GameManager.playerDamage = damage;

        InvokeRepeating("DoEmit", 0f,firerate);

    }

    void DoEmit()
    {
            var emitParams = new ParticleSystem.EmitParams();
            emitParams.startColor = color;
            emitParams.startSize = size;
            emitParams.startLifetime = lifetime;

            system.Emit(emitParams, 1);
    }

    private void OnParticleCollision(GameObject other) {
        if (other.tag == "Enemy"){
            other.GetComponent<VidaController>().ControlaVida(false,GameManager.playerDamage);
        }
    }

    public void specialAttack(){
        if(GameManager.noSpAttack>0)
        {
            GameObject enemy = GameObject.Find("Enemy");
            foreach(Transform child in enemy.transform)
            {
                if(child.name=="Particle System")
                {
                    system = child.GetComponent<ParticleSystem>();
                    system.Clear();
                }
            }
            GameManager.noSpAttack--;
            GameManager.counterSp();
        }
    }
}
