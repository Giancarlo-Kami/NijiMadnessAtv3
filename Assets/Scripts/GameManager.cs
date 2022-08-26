using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static int charSelected;

    //difficulty settings
    public static int vidasMax;
    public static int vidaAtual;
    public static int vidaMaxInimigo;

    public static int playerDamage;

    public static string actualScene;

    public static int noSpAttack;

    public static GameManager Instance
    
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("GM").AddComponent<GameManager>();
            }
            return instance;
        }
    }

    public static void setCharSelected(int n)
    {
        charSelected = n;
    }

    public static void setDifficulty(int vidasMax2,int vidaMaxInimigo2,int sp)
    {
        vidasMax = vidasMax2;
        vidaAtual = vidasMax;
        vidaMaxInimigo = vidaMaxInimigo2;
        noSpAttack = sp;
    }



    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(this);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }

    public static void changeScene(string scene){
        SceneManager.LoadScene(scene);
        actualScene = scene;
    }

    public static void nextStage(){
        if(actualScene == "Text1")
            changeScene("Fase1");
        else if(actualScene == "Text2")
            changeScene("Fase2");
        else if(actualScene == "Text3")
            changeScene("Fase3");
        else if(actualScene == "TextWin")
            changeScene("Win");
        else if(actualScene == "TextLose")
            changeScene("GameOver");
    }

    public static void counterSp(){
        GameObject.Find("Bombas").GetComponent<TMP_Text>().text = "Bombs: "+noSpAttack.ToString();
    }
    
}
