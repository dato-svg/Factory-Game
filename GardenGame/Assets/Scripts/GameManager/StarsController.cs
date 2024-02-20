using System.Collections;
using UnityEngine;

namespace GameManager
{
    public class StarsController : MonoBehaviour
    {
        [SerializeField] private GameObject[] stars;

        private void Start()
        {
            StartCoroutine(EnableDisableStars());
        }

        private IEnumerator EnableDisableStars()
        {
            while (true)
            {
                var randomIndex = GetRandomIndex();
                SetStarActive(randomIndex, true);
                yield return new WaitForSeconds(0.2f);
                SetStarActive(randomIndex, false);
            }
        }

        private void SetStarActive(int index, bool isActive)
        {
            if (index >= 0 && index < stars.Length)
            {
                stars[index].SetActive(isActive);
            }
            else
            {
                Debug.LogWarning("Invalid star index: " + index);
            }
        }

        private int GetRandomIndex()
        {
            return Random.Range(0, stars.Length);
        }
    }
}