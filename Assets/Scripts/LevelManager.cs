using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<Level> levelPrefabs = new List<Level>();
    public Level currentLevel;
    public int currentLevelIndex;
    public GameObject deathScreen;

    public void LoadLevel(int level)
    {
        if (currentLevel != null)
        {
            Destroy(currentLevel.gameObject);
            currentLevel = null;
        }

        currentLevelIndex = level;
        currentLevel = Instantiate(levelPrefabs[level].gameObject).GetComponent<Level>();
    }

    public IEnumerator GameOver()
    {
        deathScreen.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        LoadLevel(currentLevelIndex);        
        deathScreen.SetActive(false);

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
