using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<Level> levelPrefabs = new List<Level>();
    public Level currentLevel;
    public int currentLevelIndex;
    public GameObject deathScreen;
<<<<<<< HEAD
    public GameObject banner;
    [SerializeField]
    public AudioSource ambient;
    [SerializeField]
    public AudioSource death;
=======

>>>>>>> ac6f58bb5f66a43cbfd58124bb94f94b7e46d44b
    public void LoadLevel(int level)
    {
        if (currentLevel != null)
        {
            Destroy(currentLevel.gameObject);
            currentLevel = null;
        }
<<<<<<< HEAD
        ambient.Play();
        currentLevelIndex = level;
        currentLevel = Instantiate(levelPrefabs[level].gameObject).GetComponent<Level>();

=======

        currentLevelIndex = level;
        currentLevel = Instantiate(levelPrefabs[level].gameObject).GetComponent<Level>();
>>>>>>> ac6f58bb5f66a43cbfd58124bb94f94b7e46d44b
    }

    public IEnumerator GameOver()
    {
<<<<<<< HEAD
        ambient.Stop();
        death.Play();
        deathScreen.SetActive(true);
        yield return new WaitForSeconds(1.5f);
             
        deathScreen.SetActive(false);
        banner.SetActive(true);
        yield return new WaitForSeconds(2f);
        banner.SetActive(false);
        LoadLevel(currentLevelIndex);

=======
        deathScreen.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        LoadLevel(currentLevelIndex);        
        deathScreen.SetActive(false);
>>>>>>> ac6f58bb5f66a43cbfd58124bb94f94b7e46d44b

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
