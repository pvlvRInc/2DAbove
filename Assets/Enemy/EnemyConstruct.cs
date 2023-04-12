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
    private Rect _spawnBox;

    private float _cooldownEnd;

    private void Awake()
    {
        _startTime = Time.time;
        _cooldownEnd = Time.time + _cooldown;

        _spawnBox.xMin = -20;
        _spawnBox.xMax = 20;
        _spawnBox.yMin = -10;
        _spawnBox.yMax = 10;
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

                Vector2 enemySpawnPoint;
                float border = 5;
                do
                {
                    var x = Random.Range(-_spawnBox.width / 2 - border, _spawnBox.width / 2 + border);
                    var y = Random.Range(-_spawnBox.height / 2 - border, _spawnBox.height / 2 + border);
                    enemySpawnPoint = new Vector2(x, y);
                }
                while (_spawnBox.Contains(enemySpawnPoint, true));
                Vector3 spawnPoint = new Vector3(enemySpawnPoint.x, enemySpawnPoint.y, 0);


                GameObject enemy = GameObject.Instantiate(_enemyCatalog[pickedEnemyInd].shape, spawnPoint, Quaternion.identity);
                enemy.AddComponent<Enemy>().Initialize(_enemyCatalog[pickedEnemyInd], _player);
            }
        }
    }
}
