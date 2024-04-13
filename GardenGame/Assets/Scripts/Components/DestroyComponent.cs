using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Components
{
    public class DestroyComponent : MonoBehaviour
    {
        
        [SerializeField] private GameObject _target;


        public void DestroyObject()
        {
            DestroyImmediate(_target);
        }
    }
}
