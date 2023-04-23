using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public static class CookieUIModel
    {
        public static event Action OnChangeHp;
        public static event Action OnChangeScore;
        
        // HP
        private static float _maxHp;
        public static float MaxHp
        {
            get => _maxHp;

            set
            {
                _maxHp = value;
            }
        }
        
        private static float _hp;
        public static float Hp
        {
            get => _hp;
            set
            {
                _hp = value;
                OnChangeHp?.Invoke();
            }
        }
        
        // Score
        private static float _score;

        public static float Score
        {
            get => _score;

            set
            {
                _score = value;
                OnChangeScore?.Invoke();
            }
        }
    }    
}

