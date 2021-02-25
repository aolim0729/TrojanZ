using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

public class Spawner : UbhMonoBehaviour
{
    [SerializeField, FormerlySerializedAs("_Waves")]
    private GameObject[] m_waves = null;

    private int m_currentWave;
    private int count = 0;
    private UbhGameManager m_manager;

    private IEnumerator Start()
    {
        if (m_waves.Length == 0)
        {
            yield break;
        }

        m_manager = FindObjectOfType<UbhGameManager>();

        while (m_waves.Length > count)
        {
            while (m_manager.IsPlaying() == false)
            {
                yield return null;
            }

            GameObject wave = (GameObject)Instantiate(m_waves[m_currentWave], transform);
            Transform waveTrans = wave.transform;
            waveTrans.position = transform.position;

            while (0 < waveTrans.childCount)
            {
                yield return null;
            }

            Destroy(wave);

            m_currentWave = (int)Mathf.Repeat(m_currentWave + 1f, m_waves.Length);
            count += 1;
        }
        LevelEnded();

    }

    private void LevelEnded()
    {
        m_manager.NextLevel();
    }
}