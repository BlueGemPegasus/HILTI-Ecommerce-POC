using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

using System.Collections;
using System.Collections.Generic;

namespace H.Input
{
    public class InputCatcher : MonoBehaviour
    {
        [Header("Player Input Values")]
        public Vector2 place;
        public bool touch;

#if ENABLE_INPUT_SYSTEM
        public void OnPlace(InputValue value)
        {
            PlaceInput(value.Get<Vector2>());
        }

        public void OnTouch(InputValue value)
        {
            TouchInput(value.isPressed);
        }
#endif

        public void PlaceInput(Vector2 newPlaceDirection)
        {
            place = newPlaceDirection;
        }
    
        public void TouchInput(bool newTouchState)
        {
            touch = newTouchState;
        }
    }

}
