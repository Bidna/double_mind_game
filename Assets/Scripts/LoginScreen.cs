﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class LoginScreen : MonoBehaviour
{
<<<<<<< HEAD
    public AudioSource main_Menu;
=======
>>>>>>> ac6f58bb5f66a43cbfd58124bb94f94b7e46d44b
    public GameObject mainMenu;
    public TMP_InputField loginInput;
    public TMP_InputField passwordInput;
    public TMP_Text logOutput;

    public string currentUser;
    
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
        StartCoroutine(Auth());
    }

    private static bool authComplete;
    private static string responseString;
    
    private IEnumerator Auth()
    {
        authComplete = false;
        AuthAsync();

        while (!authComplete)
        {
            yield return null;
        }
        
<<<<<<< HEAD
     //   if (responseString.Contains("true"))
     //  {
=======
        if (responseString.Contains("true"))
        {
>>>>>>> ac6f58bb5f66a43cbfd58124bb94f94b7e46d44b
            logOutput.color = Color.green;
            logOutput.text = "Login successful!";
            
            // authComplete = false;
            // GetUserAsync();
            //
            // while (!authComplete)
            // {
            //     yield return null;
            // }
            Debug.Log(responseString);
            yield return new WaitForSecondsRealtime(1);
            //Get user level
            gameObject.SetActive(false);
<<<<<<< HEAD
            FindObjectOfType<LevelManager>().LoadLevel(0);
        main_Menu.Stop();

        logOutput.text = "";
     //  }
    //    else
   //     {
            logOutput.color = Color.red;
            logOutput.text = "Login or password wrong!";
     //   }
=======
            FindObjectOfType<LevelManager>().LoadLevel(0); 
            logOutput.text = "";
        }
        else
        {
            logOutput.color = Color.red;
            logOutput.text = "Login or password wrong!";
        }
>>>>>>> ac6f58bb5f66a43cbfd58124bb94f94b7e46d44b
    }

    private async Task GetUserAsync()
    {
        var client = new HttpClient();
        var values = new Dictionary<string, string>
        {
            {"Email", currentUser}
        };

        var content = new FormUrlEncodedContent(values);
        
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("http://nedden-001-site1.dtempurl.com/api/Users"),
            Content = new StringContent("{\"Email\" : \""+currentUser+"\"}"),
        };
        var response = await client.SendAsync(request).ConfigureAwait(false);
        
        responseString = await response.Content.ReadAsStringAsync();
        authComplete = true;
    }
    
    private async Task AuthAsync()
    {
        var client = new HttpClient();
        currentUser = loginInput.text;
        var values = new Dictionary<string, string>
        {
            {"Email", currentUser},
            {"Password", passwordInput.text}
        };

        var content = new FormUrlEncodedContent(values);

        var response = await client.PostAsync("http://nedden-001-site1.dtempurl.com/api/Users", content);
        
        responseString = await response.Content.ReadAsStringAsync();
        authComplete = true;
    }

    private async Task PutAsync()
    {
        var client = new HttpClient();
        currentUser = loginInput.text;
        var values = new Dictionary<string, string>
        {
            {"Email", currentUser},
            {"UserLevel", FindObjectOfType<LevelManager>().currentLevelIndex.ToString()},
<<<<<<< HEAD
            {"UserPoints", FindObjectOfType<Player>().Score.ToString()}
=======
            {"UserPoints", FindObjectOfType<Player>().score.ToString()}
>>>>>>> ac6f58bb5f66a43cbfd58124bb94f94b7e46d44b
        };

        var content = new FormUrlEncodedContent(values);

        var response = await client.PutAsync("http://nedden-001-site1.dtempurl.com/api/Users", content);
        
        responseString = await response.Content.ReadAsStringAsync();
        authComplete = true;
    }
    
    public void SendData()
    {
        FindObjectOfType<LevelManager>().StartCoroutine(EnumSendData());
    }

    IEnumerator EnumSendData()
    {
        authComplete = false;
        PutAsync();
        
        while (!authComplete)
        {
            yield return null;
        }
        Debug.Log(responseString);
    }
}
