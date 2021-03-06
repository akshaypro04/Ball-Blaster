﻿using System.Collections;
using UnityEngine;

namespace BallBlast.UI.SceneEnd
{
    public class SceneTrasitionEnding : MonoBehaviour
    {
        public Animator anim;

        void Update()
        {
            StartCoroutine(StartingTrasition());
        }


        IEnumerator StartingTrasition()
        {
            yield return new WaitForSeconds(2f);
            gameObject.SetActive(false);
        }
    }

}