using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField]
    private float invincibilityDeltaTime;

    [SerializeField]
    private float invincibilityDurationSeconds;

    [SerializeField]
    private GameObject Model;

    public bool isInvincible = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BecomeTemporarilyInvincible());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator BecomeTemporarilyInvincible()
    {
        Debug.Log("Player turned invincible!");
        isInvincible = true;
        
        for (float i = 0; i < invincibilityDurationSeconds; i += invincibilityDeltaTime)
        {
            if (Model.transform.localScale == Vector3.one)
            {
                ScaleModelTo(Vector3.zero);
                }
            else
            {
                ScaleModelTo(Vector3.one);
            }
            yield return new WaitForSeconds(invincibilityDeltaTime);
        }

        Debug.Log("Player is no longer invincible!");
        ScaleModelTo(Vector3.one);
        isInvincible = false;
    }

    public void MethodThatTriggersInvulnerability()
    {
        if (!isInvincible)
        {
            StartCoroutine(BecomeTemporarilyInvincible());
        }
    }

    private void ScaleModelTo(Vector3 scale)
    {
        Model.transform.localScale = scale;
    }
}
