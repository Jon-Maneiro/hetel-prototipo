using UnityEngine;


public class HealthComponent : MonoBehaviour
{
    private int _healthPoints;


    public void Set(int points)
    {
        _healthPoints = points;
    }

    public int Get()
    {
        return _healthPoints;
    }

    public void AddHealth(int points)
    {
        _healthPoints = _healthPoints + points;
    }

    public void RemoveHealth(int points)
    {
        if (_healthPoints > 0)
        {
            _healthPoints = _healthPoints - points;
        }


        if (_healthPoints <= 0)
        {
            _healthPoints = 0;
        }
    }
}