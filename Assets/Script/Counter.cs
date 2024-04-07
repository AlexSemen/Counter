using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] TMP_Text _textMeshPro;

    private float _timeScore = 0.5f;
    private WaitForSeconds _waitForSeconds;
    private bool _isWork;
    private int _curretScore;
    private Coroutine _coroutine;


    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_timeScore);
        _isWork = true;
        _curretScore = 0;
    }

    IEnumerator Score()
    {
        while (_isWork) 
        {
            yield return _waitForSeconds;
            _curretScore++;
            Debug.Log(_curretScore.ToString());
            
            if (_textMeshPro != null)
            {
                _textMeshPro.text = _curretScore.ToString();
            }
        }
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            if (_coroutine == null)
            {
                TurnOnScore();
            }
            else
            {
                OffScore();
            }
        }
    }

    private void TurnOnScore()
    {
        _coroutine = StartCoroutine(Score());
    }

    private void OffScore()
    {
        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }
}
