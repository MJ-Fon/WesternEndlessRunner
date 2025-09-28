using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public static Score Instance;

    [Header("UI")]
    public TMP_Text DistanceText;
    public TMP_Text CoinText;

    

    [Header("Distance Settings")]
    public float distanceMultiplier = 1f; // multiply Unity units to "meters" if you want

    private Transform referenceTransform; // camera or player
    private float startY = 0f;
    private float maxDistance = 0f; // measured in Unity units (before multiplier)

    private int coinScore = 0;
    
    

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        // Prefer camera for distance (works well for upward-scrolling games).
        if (Camera.main != null)
        {
            referenceTransform = Camera.main.transform;
            startY = referenceTransform.position.y;
        }
        else
        {
            // fallback to player if camera is absent
            var player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                referenceTransform = player.transform;
                startY = referenceTransform.position.y;
            }
        }

        // safe UI check
        if (DistanceText == null) Debug.LogWarning("[Score] DistanceText not assigned in inspector.");
        if (CoinText == null) Debug.LogWarning("[Score] CoinText not assigned in inspector.");
    }

    private void Update()
    {
        // If the referenceTransform is lost (player respawned), try to re-find it
        if (referenceTransform == null)
        {
            if (Camera.main != null)
            {
                referenceTransform = Camera.main.transform;
                startY = referenceTransform.position.y;
            }
            else
            {
                var player = GameObject.FindGameObjectWithTag("Player");
                if (player != null)
                {
                    referenceTransform = player.transform;
                    startY = referenceTransform.position.y;
                }
            }
        }

        // Update measured distance (use max so it never goes backward)
        if (referenceTransform != null)
        {
            float raw = referenceTransform.position.y - startY;
            if (raw > maxDistance) maxDistance = raw;
        }

        // Convert & display
        int displayDistance = Mathf.Max(0, Mathf.FloorToInt(maxDistance * distanceMultiplier));
        
        if (DistanceText != null) DistanceText.text = displayDistance.ToString();
        if (CoinText != null) CoinText.text = coinScore.ToString();
        
    }

    // Called by coins
    public void AddCoin(int amount)
    {
        coinScore += amount;
        if (CoinText != null) CoinText.text = coinScore.ToString();
    }

    // Safe getters used by HighScoreManager etc.
    public int GetDistance() => Mathf.Max(0, Mathf.FloorToInt(maxDistance * distanceMultiplier));
    public int GetCoins() => coinScore;

    private void OnDestroy()
    {
        Debug.Log($"[Score] Destroying. Final distance={GetDistance()}, coins={GetCoins()}");
    }

    /*
        public static Score Instance;

        [Header("UI")]
        public TMP_Text DistanceText;
        public TMP_Text CoinText;

        private float distanceScore = 0;
        private int coinScore = 0;

        public int GetDistance() => (int)distanceScore;
        public int GetCoins() => coinScore;

        private void Awake()
        {
            Instance = this;
        }
        void OnDestroy()
        {
            Debug.Log("Final Distance: " + distanceScore);
        }

        void Start()
        {

            if (DistanceText == null)
                Debug.LogError("DistanceText is not assigned in the Inspector!");

            if (CoinText == null)
                Debug.LogError("CoinText is not assigned in the Inspector!");

        }

        void Update()
        {
            if (Time.timeScale == 0) return;

            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                distanceScore += 1 * Time.deltaTime;
                DistanceText.text = ((int)distanceScore).ToString();
            }
        }

        public void AddCoin(int amount)
        {
            coinScore += amount;
            CoinText.text = coinScore.ToString();
        }

        /*
        public TMP_Text ScoreText;
        private float score;

        // Update is called once per frame
        void Update()
        {
            if(GameObject.FindGameObjectsWithTag("Player") != null)
            {
                score += 1 * Time.deltaTime;
                ScoreText.text = ((int)score).ToString();
            }
        }
        */

}
