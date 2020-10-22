using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuScript : MonoBehaviour
{
    private float endCpt = 0;
    private bool end = false;
    // Start is called before the first frame update
    public string LevelToLoad = "";
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(endCpt > 0)
        {
            endCpt -= Time.deltaTime;
        }
        else if(end)
        {
            Cursor.lockState = CursorLockMode.None;
            transform.GetChild(6).gameObject.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
        }
    }

    public void showGameOver()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        transform.GetChild(4).gameObject.SetActive(true);
        Cursor.visible = true;
    }

    public void loadLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(LevelToLoad);
    }

    public void quit()
    {
        Application.Quit();
    }

    public void showPause()
    {
        Cursor.lockState = CursorLockMode.None;
        transform.GetChild(5).gameObject.SetActive(true);
        Cursor.visible = true;
    }

    public void hidePause()
    {
        transform.GetChild(5).gameObject.SetActive(false);
        Cursor.visible = false;
    }

    public void showHealthBar()
    {
        transform.GetChild(2).gameObject.SetActive(true);
    }

    public void hideHealthBar()
    {
        transform.GetChild(2).gameObject.SetActive(false);
    }

    public void setHealthBarPercent(float percent)
    {
        Vector2 size = new Vector2(500*percent,30);
        transform.GetChild(2).gameObject.GetComponent<RectTransform>().sizeDelta = size;
    }

    public void endGame()
    {
        end = true;
        endCpt = 2f;
    }
}
