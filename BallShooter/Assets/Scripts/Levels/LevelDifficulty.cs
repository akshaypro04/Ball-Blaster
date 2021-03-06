﻿using UnityEngine;
using System.Collections.Generic;
using BallBlast.Comman.Game;

namespace BallBlast.level.levelValue
{
    public class LevelDifficulty : MonoBehaviour
    {

        public class levelnum
        {
            public int[] levels;
        }

        public List<levelnum> count = new List<levelnum>();

        void Awake()
        {

            count.Add(new levelnum { levels = new int[] { 1, 3 } });                                                                                                                                   // 1
            count.Add(new levelnum { levels = new int[] { 1, 2, 3, 4, 5, 8, 9, 10 } });                                                                                                                // 2
            count.Add(new levelnum { levels = new int[] { 1, 2, 3, 4, 5, 18, 20, 25, 22, 29, 35 } });                                                                                                  // 3
            count.Add(new levelnum { levels = new int[] { 1, 2, 3, 4, 5, 8, 9, 10, 15, 18, 20, 25, 28, 30 } });                                                                                        // 4  
            count.Add(new levelnum { levels = new int[] { 1, 2, 3, 4, 5, 8, 9, 10, 15, 18, 20, 10, 20, 25, 35, 50 } });                                                                                // 5
            count.Add(new levelnum { levels = new int[] { 1, 2, 3, 4, 5, 8, 9, 10, 20, 25, 48, 62, 74, 80, 100, 120, 135, 111 } });                                                                    // 6
            count.Add(new levelnum { levels = new int[] { 1, 2, 3, 4, 5, 8, 9, 10, 20, 25, 48, 62, 74, 118, 115, 120, 140, 50, 40, 45, 200, 222, 250 } });                                             // 7
            count.Add(new levelnum { levels = new int[] { 1, 2, 3, 4, 5, 8, 9, 10, 20, 25, 48, 62, 74, 80, 110, 118, 40, 111, 75, 60, 100, 111, 188, 160, 180, 200 } });                               // 8
            count.Add(new levelnum { levels = new int[] { 1, 2, 3, 4, 5, 8, 9, 10, 20, 25, 48, 62, 74, 80, 100, 155, 125, 185, 248, 241 } });                                                          // 9
            count.Add(new levelnum { levels = new int[] { 1, 2, 3, 4, 5, 8, 9, 10, 20, 25, 48, 62, 74, 80, 100, 110, 155, 125, 185, 248, 241, 198, 200 } });                                           // 10

            count.Add(new levelnum { levels = new int[] { 1, 2, 3, 4, 5, 8, 9, 10, 20, 25, 48, 62, 74, 80, 100, 110, 180, 222, 250, 140, 150, 120, 280 } });                                           // 11
            count.Add(new levelnum { levels = new int[] { 1, 2, 3, 4, 5, 8, 9, 10, 20, 25, 48, 62, 74, 80, 100, 110, 155, 125, 185, 248, 241, 198, 200, 222 } });                                      // 12
            count.Add(new levelnum { levels = new int[] { 1, 2, 3, 4, 5, 8, 9, 10, 20, 25, 48, 62, 74, 80, 100, 110, 155, 125, 185, 248, 241, 198, 200, 222 } });                                      // 13
            count.Add(new levelnum { levels = new int[] { 1, 2, 3, 4, 5, 8, 9, 10, 20, 25, 48, 62, 74, 80, 100, 110, 155, 125, 185, 248, 241, 198, 200, 222 } });                                      // 14
            count.Add(new levelnum { levels = new int[] { 1, 2, 3, 4, 5, 8, 9, 10, 20, 25, 48, 100, 120, 158, 128, 119, 110, 155, 125, 185, 248, 241, 198, 200 } });                                   // 15

            count.Add(new levelnum { levels = new int[] { 1, 2, 3, 4, 5, 8, 9, 10, 20, 25, 40, 78, 88, 90, 95, 120, 158, 128, 119, 200, 300, 250, 280, 320, 325, 400, 420, 11, 22, 33, 44, 55, 66, 77, 88, 99, 121, 232, 454, 565 } });                        // 16
            count.Add(new levelnum { levels = new int[] { 1, 2, 3, 4, 5, 8, 9, 10, 20, 25, 40, 78, 88, 90, 95, 120, 158, 128, 119, 200, 300, 250, 280, 320, 325, 400, 420, 11, 22, 33, 44, 55, 66, 77, 88, 99, 121, 232, 454, 565 } });                        // 17
            count.Add(new levelnum { levels = new int[] { 1, 2, 3, 4, 5, 8, 9, 10, 20, 25, 40, 78, 88, 90, 95, 120, 158, 128, 119, 200, 300, 250, 280, 320, 325, 400, 420, 11, 22, 33, 44, 55, 66, 77, 88, 99, 121, 232, 454, 565 } });                        // 18
            count.Add(new levelnum { levels = new int[] { 1, 2, 3, 4, 5, 8, 9, 10, 20, 25, 40, 78, 88, 90, 95, 120, 158, 128, 119, 200, 300, 250, 280, 320, 325, 400, 420, 11, 22, 33, 44, 55, 66, 77, 88, 99, 121, 232, 454, 565 } });                        // 19
            count.Add(new levelnum { levels = new int[] { 1, 2, 3, 4, 5, 8, 9, 10, 20, 25, 40, 78, 88, 90, 120, 158, 128, 119, 200, 300, 250, 300, 320, 350, 325, 400, 420, 11, 22, 33, 44, 55, 66, 77, 88, 99, 121, 232, 454, 565 } });                       // 20

            count.Add(new levelnum { levels = new int[] { 1, 2, 3, 4, 5, 8, 9, 10, 20, 25, 40, 78, 99, 180, 128, 119, 200, 300, 250, 300, 500, 800, 11, 22, 33, 44, 55, 66, 77, 88, 99, 121, 232, 454, 565, 787, 898, 1001 } });                                               // 21
            count.Add(new levelnum { levels = new int[] { 1, 2, 3, 4, 5, 8, 9, 10, 20, 25, 48, 62, 74, 80, 120, 158, 128, 119, 200, 300, 250, 300, 320, 350, 250, 300, 500, 800, 11, 22, 33, 44, 55, 66, 77, 88, 99, 121, 232, 454, 565, 787, 898, 1001 } });                  // 22
            count.Add(new levelnum { levels = new int[] { 1, 2, 3, 4, 5, 8, 9, 10, 20, 25, 48, 62, 74, 80, 120, 158, 128, 119, 200, 300, 250, 300, 320, 350, 250, 300, 500, 800, 11, 22, 33, 44, 55, 66, 77, 88, 99, 121, 232, 454, 565, 787, 898, 1001 } });                  // 23
            count.Add(new levelnum { levels = new int[] { 1, 2, 3, 4, 5, 8, 9, 10, 20, 25, 48, 62, 74, 80, 120, 158, 128, 150, 200, 400, 250, 705, 1111, 1000, 1200, 1111, 11, 22, 33, 44, 55, 66, 77, 88, 99, 121, 232, 454, 565, 787, 898, 1001 } });                        // 24
            count.Add(new levelnum { levels = new int[] { 1, 2, 3, 4, 5, 8, 9, 10, 20, 25, 48, 62, 74, 80, 120, 158, 150, 119, 202, 300, 895, 620, 560, 896, 752, 952, 100, 1200, 1500, 1100 } });     // 25
            count.Add(new levelnum { levels = new int[] { 1, 2, 3, 4, 5, 8, 9, 10, 20, 25, 48, 62, 74, 80, 120, 158, 128, 119, 200, 300, 250, 620, 560, 896, 752, 952, 100, 1125, 1300, 1300, 11, 22, 33, 44, 55, 66, 77, 88, 99, 121, 232, 454, 565, 787, 898, 1001 } });     // 26
            count.Add(new levelnum { levels = new int[] { 1, 2, 3, 4, 5, 8, 9, 10, 20, 25, 48, 62, 74, 80, 120, 158, 128, 620, 560, 896, 752, 952, 100, 1200, 985, 888, 777, 555, 666, 1000, 11, 22, 33, 44, 55, 66, 77, 88, 99, 121, 232, 454, 565, 787, 898, 1001 } });      // 27
            count.Add(new levelnum { levels = new int[] { 1, 2, 3, 4, 5, 8, 9, 10, 20, 25, 48, 62, 74, 80, 120, 158, 128, 119, 200, 300, 250, 300, 320, 1200, 985, 888, 777, 555, 666, 1000, 11, 22, 33, 44, 55, 66, 77, 88, 99, 121, 232, 454, 565, 787, 898, 1001 } });      // 28
            count.Add(new levelnum { levels = new int[] { 1, 2, 3, 4, 5, 8, 9, 10, 20, 25, 48, 62, 74, 80, 120, 158, 128, 119, 200, 300, 250, 300, 320, 1200, 985, 888, 777, 555, 666, 1000, 11, 22, 33, 44, 55, 66, 77, 88, 99, 121, 232, 454, 565, 787, 898, 1001 } });      // 29
            count.Add(new levelnum { levels = new int[] { 1, 2, 3, 4, 5, 8, 9, 48, 62, 74, 80, 120, 158, 128, 119, 200, 300, 250, 300, 320, 1200, 985, 888, 777, 555, 666, 1000, 11, 22, 33, 44, 55, 66, 77, 88, 99, 121, 232, 454, 565, 787, 898, 1001 } });                  // 30

            count.Add(new levelnum { levels = new int[] { 1, 2, 3, 4, 5, 8, 9, 10, 20, 111, 222, 333, 444, 555, 555, 666, 777, 888, 999, 1010, 1111, 1212, 1313, 1414, 3333, 11, 22, 33, 44, 55, 66, 77, 88, 99, 121, 232, 454, 565, 787, 898, 1001 } });                      // 31
            count.Add(new levelnum { levels = new int[] { 1, 2, 3, 4, 5, 8, 9, 10, 20, 111, 222, 333, 444, 555, 11, 22, 33, 44, 55, 66, 77, 88, 99, 121, 232, 454, 565, 787, 898, 1001 } });                                                                                   // 32
        }

        void Start()
        {
            GameManager.instances.levelManager.CheckUserLevel();
        }
    }
}