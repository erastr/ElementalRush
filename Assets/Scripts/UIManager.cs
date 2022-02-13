using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;
using Cinemachine;

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
    [SerializeField] private TextMeshProUGUI coinTMP;
    [SerializeField] private TextMeshPro inGameCoinTMP;
    [SerializeField] private PlayerController player;


    [SerializeField] private CinemachineVirtualCamera startCam;


    private int coin;

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

    //Method that starts the game
    private void StartGame()
    {
        startCam.Priority = 0;
        coinTMP.text = "0";
        inGameCoinTMP.text = "0";
        inGameCoinTMP.enabled = true;
        isPlaying = true;
        tapToPlayPanel.SetActive(false);
        tapToPlayText.gameObject.SetActive(false);
        player.canMove = true;
        player.inputController.canMove = true;
        player.ChangeAnimation("Run");
    }

    //The method that works at the end of the game
    public void EndGame()
    {
        inGameCoinTMP.enabled = false;
        endGamePanel.SetActive(true);
    }

    //The method that takes us to the next level
    public void NextGameButton(int level)
    {
        SceneManager.LoadScene(level);
    }

    //The method where we increase the number of gold collected by the user and update the text on the screen
    public void UpdateCoin()
    {
        coin++;
        coinTMP.text = coin.ToString();
        inGameCoinTMP.text = coin.ToString();
    }

}
