using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VidaController : MonoBehaviour
{

    public int vidas;
    public int vidasMax;
    private TMP_Text vidasText;
    public float vidaInimigo;
    public float vidaMaxInimigo;

    private int randomNum;
    public GameObject pickup;
    private Image vidaInimigoBar;


    void Awake()
    {
        vidasMax = GameManager.vidasMax;
        vidaMaxInimigo = GameManager.vidaMaxInimigo;
        if(this.tag == "Player"){
            vidas = GameManager.vidaAtual;
            vidasText = GameObject.Find("Vidas").GetComponent<TMP_Text>();
            vidasText.text = "Vidas: " +vidas.ToString();
        }else if(this.tag == "Enemy"){
            vidaInimigo = vidaMaxInimigo;
            vidaInimigoBar = GameObject.Find("HealthBar").GetComponent<Image>();
            attBarra();
        }
        
    }

    public void ControlaVida(bool sinal, int qtd)
    {
        if(this.tag=="Player"){
            if(sinal){
                if(vidas+qtd >= vidasMax)
                    vidas = vidasMax;
                else
                    vidas += qtd;

            }else{
                vidas -= qtd;
                GameManager.vidaAtual = vidas;

            }
            vidasText.text = "Vidas: " + vidas.ToString();
            if(vidas<=0){
                    GameManager.changeScene("TextLose");
            }
        }else{
            if(!sinal){
                vidaInimigo -= qtd;
                randomNum = Random.Range(1,100);
                if(randomNum <= 5*GameManager.charSelected){
                    Instantiate(pickup,this.transform.position,Quaternion.identity);
                }
            }
            attBarra();
            if(vidaInimigo<=0){
                if(GameManager.actualScene == "Fase1"){
                    GameManager.changeScene("Text2");
                }
                else if(GameManager.actualScene == "Fase2"){
                    GameManager.changeScene("Text3");
                }
                else if(GameManager.actualScene == "Fase3"){
                    GameManager.changeScene("TextWin");
                }
            }
        }
    }

    void attBarra(){
        vidaInimigoBar.fillAmount = vidaInimigo/vidaMaxInimigo;
    }
}


