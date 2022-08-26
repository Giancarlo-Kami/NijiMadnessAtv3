using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class TMPController : MonoBehaviour
{
    // Start is called before the first frame update

    void Awake()
    {
    }

    public void ButtonPress()
    {

        if(SceneManager.GetActiveScene().name == "Win" || SceneManager.GetActiveScene().name == "GameOver")
            {
                GameManager.changeScene("Menu");
            }
    }

    public void StartPress()
    {
        GameManager.changeScene("DifSelect");
    }


    public void ButtonCharA()
    {
        GameManager.setCharSelected(1);
        GameManager.changeScene("Text1");
    }
    public void ButtonCharB()
    {
        GameManager.setCharSelected(2);
        GameManager.changeScene("Text1");
    }
    public void ButtonCharC()
    {
        GameManager.setCharSelected(3);
        GameManager.changeScene("Text1");
    }

    public void ButtonEasy()
    {
        GameManager.setDifficulty(10,1500,3);
        GameManager.changeScene("CharSelec");
    }

    public void ButtonMedium()
    {
        GameManager.setDifficulty(8,1860,2);
        GameManager.changeScene("CharSelec");
    }

    public void ButtonHard()
    {
        GameManager.setDifficulty(5,2250,1);
        GameManager.changeScene("CharSelec");
    }

}
