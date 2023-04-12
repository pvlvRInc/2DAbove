using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConstruct : MonoBehaviour
{
    [SerializeField] private float _pointScale;
    [SerializeField] private List<EnemyParameters> _enemyCatalog;

    //Cashing
    private float startTime;
    private float points;
    private float pointIncrement;

    private void Awake()
    {
        startTime = Time.time;
    }

    public void Update()
    {
        //points logic should be outside
        pointIncrement = (Time.time - startTime)/10;
        points += pointIncrement;


    }
}
