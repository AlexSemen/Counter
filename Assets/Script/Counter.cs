using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TMP_Text _textMeshPro;

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

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(KeepScore());
            }
            else
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }
    }

    private IEnumerator KeepScore()
    {
        while (_isWork)
        {
            yield return _waitForSeconds;

            _curretScore++;
            Debug.Log(_curretScore.ToString());
            _textMeshPro.text = _curretScore.ToString();
        }
    }
}
