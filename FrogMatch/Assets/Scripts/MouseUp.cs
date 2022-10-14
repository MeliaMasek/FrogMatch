using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MouseUp : MonoBehaviour

    {
        public UnityEvent startEvent;

        void OnMouseUp()
        {
            print("Drag ended!");
        }
    }

