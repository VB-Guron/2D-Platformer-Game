using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Level1(){
       UnityEngine.SceneManagement.SceneManager.LoadScene("Level1"); 
       GameManager.instance.resetCoins();
    }
    public void Level2(){
       UnityEngine.SceneManagement.SceneManager.LoadScene("Level2"); 
       GameManager.instance.resetCoins();
    }
    public void Level3(){
       UnityEngine.SceneManagement.SceneManager.LoadScene("Level3"); 
       GameManager.instance.resetCoins();
    }
    public void Controls(){
       UnityEngine.SceneManagement.SceneManager.LoadScene("Controls"); 
       GameManager.instance.resetCoins();
    }
    public void Credits(){
       UnityEngine.SceneManagement.SceneManager.LoadScene("Credits"); 
       GameManager.instance.resetCoins();
    }
    public void SelectLevel(){
       UnityEngine.SceneManagement.SceneManager.LoadScene("SelectLevel"); 
       GameManager.instance.resetCoins();
    }
    public void Back(){
       UnityEngine.SceneManagement.SceneManager.LoadScene("Back"); 
       GameManager.instance.resetCoins();
    }
    public void MyMainMenu(){
       UnityEngine.SceneManagement.SceneManager.LoadScene("MyMainMenu"); 
       GameManager.instance.resetCoins();
    }
}
