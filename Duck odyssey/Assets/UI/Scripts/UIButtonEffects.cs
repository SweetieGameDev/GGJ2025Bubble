using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace UWEGames.Examples
{

    public class UIButtonEffects : MonoBehaviour
    {
        [SerializeField] private float scaleFactor = 1.3f;
        [SerializeField] private float scaleTime = 0.25f;
        [SerializeField] private Ease scaleEaseType = Ease.InOutExpo;

        // Start is called before the first frame update
        void Start()
        {
        }

        public void ScaleUp()
        {
            transform.DOScale(Vector3.one * scaleFactor, scaleTime).SetEase(scaleEaseType);
        }

        public void ScaleDown()
        {
            transform.DOScale(Vector3.one, scaleTime).SetEase(scaleEaseType);
        }
    }

}