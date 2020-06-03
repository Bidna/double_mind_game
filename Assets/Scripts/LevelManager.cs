using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public List<Level> levelPrefabs = new List<Level>();
    public Level currentLevel;
    public int currentLevelIndex;
    public GameObject deathScreen;
    public GameObject banner;
    [SerializeField]
    public AudioSource ambient;
    [SerializeField]
    public AudioSource death;
    
    private int startLevelScore;
    private int score;
    public int Score
    {
        get => score;
        set
        {
            score = value;
            GameObject.Find("Score").GetComponent<Text>().text = score.ToString();
        }
    }
    
    public void LoadLevel(int level)
    {
        if (currentLevel != null)
        {
            Destroy(currentLevel.gameObject);
            currentLevel = null;
        }
        startLevelScore = Score;

        ambient.Play();
        currentLevelIndex = level;
        currentLevel = Instantiate(levelPrefabs[level].gameObject).GetComponent<Level>();

    }

    public IEnumerator GameOver()
    {
        Score = startLevelScore;
        ambient.Stop();
        death.Play();
        deathScreen.SetActive(true);
        yield return new WaitForSeconds(1.5f);
             
        deathScreen.SetActive(false);
        banner.SetActive(true);
        yield return new WaitForSeconds(2f);
        banner.SetActive(false);
        LoadLevel(currentLevelIndex);


        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
