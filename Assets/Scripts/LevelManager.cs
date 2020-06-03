using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public void LoadLevel(int level)
    {
        if (currentLevel != null)
        {
            Destroy(currentLevel.gameObject);
            currentLevel = null;
        }
        ambient.Play();
        currentLevelIndex = level;
        currentLevel = Instantiate(levelPrefabs[level].gameObject).GetComponent<Level>();

    }

    public IEnumerator GameOver()
    {
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
