using pradev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConstruct : MonoBehaviour
{
    [SerializeField] private float _pointScale = 1f;
    [SerializeField] private List<EnemyParameters> _enemyCatalog;
    [SerializeField] private Transform _player;
    [SerializeField] private float _cooldown = 5f;

    //Cashing
    private float _startTime;
    private float _points;
    private float _pointIncrement;

    private float _cooldownEnd;

    private void Awake()
    {
        _startTime = Time.time;
        _cooldownEnd = Time.time + _cooldown;
    }

    public void Update()
    {
        //points logic should be outside
        _pointIncrement = (Time.time - _startTime) / 10 * _pointScale;
        _points += _pointIncrement;

        if (Time.time > _cooldownEnd)
        {
            _cooldownEnd = Time.time + _cooldown;

            //todo pick enemy
            int pickedEnemyInd = 0;

            if (_points > _enemyCatalog[pickedEnemyInd].cost)
            {
                _points -= _enemyCatalog[pickedEnemyInd].cost;

                GameObject enemy = GameObject.Instantiate(_enemyCatalog[pickedEnemyInd].shape, Vector3.zero, Quaternion.identity);
                enemy.AddComponent<Enemy>().Initialize(_enemyCatalog[pickedEnemyInd], _player);

            }
        }
    }
}
