using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Sketeton_StateMC : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] float _plDistance = Mathf.Infinity;
    [SerializeField] float _distanceToPlayerThreshold = 5f;
    [SerializeField] Animator anim;
    
    const string _isSad = "isSad";
    const string _seePlayer = "PlayerVisible";
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float invertHappiness = Random.Range(0f, 1f);
        if (invertHappiness > 0.999f)
        {
            anim.SetBool(_isSad, !anim.GetBool(_isSad));
        }
        _plDistance = (_player.position - transform.position).magnitude;
        // Debug.Log("Distance to player: " + _plDistance);
        if (_plDistance < _distanceToPlayerThreshold)
        {
            anim.SetBool(_seePlayer, true);
        }
        else
        {
            anim.SetBool(_seePlayer, false);
        }
    }

    public bool CanSeePlayer()
    {
        return anim.GetBool(_seePlayer);
    }
}
