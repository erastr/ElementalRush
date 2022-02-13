using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    #region Singleton


    private static UIManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            if (instance != this)
                Destroy(this);
        }

    }

    public static UIManager GetInstance()
    {
        return instance;
    }


    #endregion

    [SerializeField] private TextMeshProUGUI tapToPlayText;
    [SerializeField] private GameObject tapToPlayPanel;
    [SerializeField] private GameObject endGamePanel;

    [SerializeField] private PlayerController player;

    
    private bool isPlaying = false;

    public void Start()
    {
        tapToPlayText.DOFade(1, 1f).SetLoops(-1,LoopType.Yoyo);
    }



    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isPlaying)
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        isPlaying = true;
        tapToPlayPanel.SetActive(false);
        tapToPlayText.gameObject.SetActive(false);
        player.canMove = true;
        player.inputController.canMove = true;
        player.ChangeAnimation("Run");
    }

    public void EndGame()
    {
        endGamePanel.SetActive(true);
    }

    public void NextGameButton(int level)
    {
        SceneManager.LoadScene(level);
    }

}
