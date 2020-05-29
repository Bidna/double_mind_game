using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginScreen : MonoBehaviour
{
    public GameObject mainMenu;
    
    public void OnEnable()
    {
        Time.timeScale = 0;
    }
    public void OnDisable()
    {
        Time.timeScale = 1;
    }
    
    public void OpenMainMenu()
    {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
    
    
    public void PlayGame()
    {
        gameObject.SetActive(false);
    }

}
