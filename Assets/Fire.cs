using System.Collections;

using UnityEngine;

public class Fire : MonoBehaviour
{
    [System.Serializable]
    public class EnemyStats
    {
        public int maxHealth = 100;
        //public float startPctHealth = 1f;

        private int _curHealth;
        public int curHealth
        {
            get { return _curHealth; }
            set { _curHealth = Mathf.Clamp(value, 0, maxHealth); }
        }

        public int damage = 10;



        public void Init()
        {
            curHealth = maxHealth;
        }


    }

    public EnemyStats stats = new EnemyStats();


    [Header("Optional: ")]
    [SerializeField]
    private StatusIndicator statusIndicator;

    void Start()
    {
        stats.Init();

        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
        }

    }

    public void TakeDamage(int damage)
    {
        stats.curHealth -= damage;
        if (stats.curHealth <= 0)
        {
            Destroy(gameObject);

        }


        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
        }

    }

    void OnCollisionEnter2D(Collision2D _colInfo)
    {
        PlayerHealth _player = _colInfo.collider.GetComponent<PlayerHealth>();
        if (_player != null)
        {
            _player.TakeDamage(stats.damage);
            //TakeDamage(999999); 
        }
    }
}