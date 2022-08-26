using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextRoller : MonoBehaviour
{



    [SerializeField]private string[] textos;
    [SerializeField]private string[] nome;
    [SerializeField]private float textSpeed = 0.01f;

    [SerializeField]private TextMeshProUGUI caixaTexto;
    private int textoEscolhido ;
    private string nomeExibido;

    private void Awake(){
        textoEscolhido = 0;
        ActivateText();
    }

    public void ActivateText()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        if(nome[textoEscolhido] == "Personagem"){
            if(GameManager.charSelected == 1)
                nomeExibido = "Finana";
            else if(GameManager.charSelected == 2)
                nomeExibido = "Pomu";
            else
                nomeExibido = "Elira";
        }else nomeExibido = nome[textoEscolhido];

        for(int i=0;i < textos[textoEscolhido].Length + 1; i++)
        {
            caixaTexto.text = nomeExibido + ": "+ textos[textoEscolhido].Substring(0,i);
            yield return new WaitForSeconds(textSpeed);
        }
        yield return new WaitForSeconds(2);

        textoEscolhido++;
        if(textoEscolhido < textos.Length){
            ActivateText();
        }else {
            GameManager.nextStage();
        }
            
    }
}
