using System;
using System.Collections.Generic;

namespace RRL
{
    public class State
    {
        // Random class for implementing randomness
        Random random = new Random();

        // X and Y location at current time
        int xtLocation;
        int ytLocation;

        // X and Y velocity at current time
        int xtVelocity;
        int ytVelocity;

        // X and Y acceleration at current time
        int accelerationX;
        int accelerationY;

        bool isStartState;
        bool isFinishState;

        public State(bool _isStart, bool _isFinish)
        {
            isStartState = _isStart;
            isFinishState = _isFinish;
        }

        /// <summary>
        /// Applies X and Y acceleration changes to this state.
        /// </summary>
        /// <param name="_xAcceleration"></param>
        /// <param name="_yAcceleration"></param>
        public void ApplyAcceleration(int _xAcceleration, int _yAcceleration)
        {
            int success = random.Next(5);
            switch (success)
            {
                case 0:
                    Console.WriteLine("FAILURE: 20% acceleration failure event.");
                    return;
                default:
                    break;
            }

            bool canApplyAcceleration = true;

            if (!new List<int> { 1, 0, -1 }.Contains(_xAcceleration))
                canApplyAcceleration = false;
            if (!new List<int> { 1, 0, -1 }.Contains(_yAcceleration))
                canApplyAcceleration = false;

            if (canApplyAcceleration)
            {
                accelerationX += _xAcceleration;
                accelerationY += _yAcceleration;
            }
            else
                Console.WriteLine("ERROR @ ApplyAcceleration(): Invalid acceleration value change.");
        }

        /// <summary>
        /// Returns true if this state is a start state.
        /// Returns false if this state is not a start state.
        /// </summary>
        /// <returns></returns>
        public bool IsStartState()
        {
            return isStartState;
        }

        /// <summary>
        /// Returns true if this state is a finish state.
        /// Returns false if this state is not a finish state.
        /// </summary>
        /// <returns></returns>
        public bool IsFinishState()
        {
            return isFinishState;
        }

        /// <summary>
        /// Checks if a change in the X and Y velocities of the current state and returns true if valid.
        /// Returns false if the change is invalid.
        /// </summary>
        /// <param name="_xChange"></param>
        /// <param name="_yChange"></param>
        /// <returns></returns>
        public bool CheckVelocity(int _xChange, int _yChange)
        {
            bool hasValidVelocity = true;

            int xtvNew = xtVelocity + _xChange;
            int ytvNew = ytVelocity + _yChange;

            if (xtvNew > 5 || xtvNew < -5)
                hasValidVelocity = false;
            if (ytvNew > 5 || ytvNew < -5)
                hasValidVelocity = false;

            return hasValidVelocity;
        }

        /// <summary>
        /// Checks the X and Y velocities of the current state and returns true if they are valid.
        /// Returns false and sets the values to their maximum if invalid.
        /// </summary>
        /// <returns></returns>
        public bool CheckVelocity()
        {
            bool hasValidVelocity = true;

            if (xtVelocity > 5 || xtVelocity < -5)
            {
                hasValidVelocity = false;
                if (xtVelocity > 5)
                    xtVelocity = 5;
                else xtVelocity = -5;
            }
            if (ytVelocity > 5 || ytVelocity < -5)
            {
                hasValidVelocity = false;
                if (ytVelocity > 5)
                    ytVelocity = 5;
                else
                    ytVelocity = -5;
            }

            return hasValidVelocity;
        }

        /// <summary>
        /// Restets the X and Y velocity
        /// </summary>
        void ResetVelocity()
        {
            xtVelocity = 0;
            ytVelocity = 0;
        }
    }
}