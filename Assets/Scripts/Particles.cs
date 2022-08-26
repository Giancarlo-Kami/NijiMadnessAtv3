using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    public ParticleSystem system;
    public int no_column;
    public float speed;
    public Sprite texture;
    public Color color;
    public float lifetime;
    public float size;
    private float angle;
    public float firerate;
    public Material material;
    public float spin_speed;
    private float time;
    public int shotMode;

    private void Awake()
    {
        Summon();
    }

    private void FixedUpdate()
    {
        time+=Time.fixedDeltaTime;
        if(shotMode == 1)
            transform.rotation = Quaternion.Euler(0,0,time * spin_speed);
        else if(shotMode == 2)
            transform.rotation = Quaternion.Euler(0,0,Mathf.Sin(time) * spin_speed);
        else if(shotMode == 3)
            transform.rotation = Quaternion.Euler(0,0,time * spin_speed *-1);
    }
    void Summon()
    {
        angle = 360f/no_column;
        for(int i=0;i<no_column;i++){ 
            Material particleMaterial = material;

            var go = new GameObject("Particle System");
            go.transform.Rotate(angle*i, 90, 0);
            go.transform.parent = this.transform;
            go.transform.position = this.transform.position;
            system = go.AddComponent<ParticleSystem>();
            go.GetComponent<ParticleSystemRenderer>().material = particleMaterial;
            var mainModule = system.main;
            mainModule.startSpeed = speed;
            mainModule.maxParticles = 10000;
            mainModule.simulationSpace = ParticleSystemSimulationSpace.World;


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
            col.collidesWith = LayerMask.GetMask("Env","Player");
            col.sendCollisionMessages = true;


            go.AddComponent<OnParticle>();
        }

        InvokeRepeating("DoEmit", 0f,firerate);
        
    }

    void DoEmit()
    {
        foreach(Transform child in transform)
        {
            if(child.name=="Particle System")
            {
                system = child.GetComponent<ParticleSystem>();
                var emitParams = new ParticleSystem.EmitParams();
                emitParams.startColor = color;

                emitParams.startSize = size;
                emitParams.startLifetime = lifetime;
                system.Emit(emitParams, 1);
            }
        }
    }
}
