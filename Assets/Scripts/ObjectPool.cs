using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;

    [SerializeField] private int _capacity;

    private List<EnemyTank> _pool;

    private void Start()
    {
        _pool = new List<EnemyTank>();
    }

    public void Initialize(EnemyTank prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            EnemyTank spawned = Instantiate(prefab, _container.transform);

            spawned.gameObject.SetActive(false);

            _pool.Add(spawned);
        }
    }

    public bool TryGetObject(out EnemyTank enemyTank)
    {
        enemyTank = _pool.Find(enemyTank => enemyTank.gameObject.activeSelf == false);

        return enemyTank != null;
    }
}
