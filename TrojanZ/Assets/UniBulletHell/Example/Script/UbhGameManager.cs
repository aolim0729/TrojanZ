using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;
using UnityEngine.SceneManagement;

public class UbhGameManager : UbhMonoBehaviour
{
    public const int BASE_SCREEN_WIDTH = 600;
    public const int BASE_SCREEN_HEIGHT = 450;

    [FormerlySerializedAs("_ScaleToFit")]
    public bool m_scaleToFit = false;

    [SerializeField, FormerlySerializedAs("_PlayerPrefab")]
    private GameObject m_playerPrefab = null;
    [SerializeField, FormerlySerializedAs("_GoTitle")]
    private GameObject m_goTitle = null;
    [SerializeField, FormerlySerializedAs("_Score")]
    private UbhScore m_score = null;
    public LevelLoader m_levelLoader = null;


    private void Start()
    {
        GameStart();
    }

    private void Update()
    {
    }

    private void GameStart()
    {
        if (m_score != null)
        {
            m_score.Initialize();
        }
        if (m_goTitle != null)
        {
            m_goTitle.SetActive(false);
        }

        CreatePlayer();
        
    }

    public void GameOver()
    {
        if (m_score != null)
        {
            m_score.Save();
            Invoke("RestartLevel",1);
        }

        else
        {
            // for UBH_ShotShowcase scene.
            CreatePlayer();
        }
    }

    private void CreatePlayer()
    {
        Instantiate(m_playerPrefab, m_playerPrefab.transform.position, m_playerPrefab.transform.rotation);
    }

    public bool IsPlaying()
    {
        if (m_goTitle != null)
        {
            return m_goTitle.activeSelf == false;
        }
        else
        {
            // for UBH_ShotShowcase scene.
            return true;
        }
    }

    public void NextLevel()
    {
        m_levelLoader.LoadNextLevel();
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
