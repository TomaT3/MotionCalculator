using System;

namespace MotionCalculator
{
    public static class MotionCalculatorHelper
    {
        public static MotionCalculationResult GetTimeForDistance(double distance, double acceleration, double deceleration, double travelSpeed)
        {
            var calculationResult = new MotionCalculationResult();
            distance = Math.Abs(distance);
            var isMaxSpeedReachable = IsMaxSpeedReached(distance, acceleration, deceleration, travelSpeed, calculationResult);
            if (isMaxSpeedReachable)
            {
                calculationResult.MaxReachableSpeed = travelSpeed;
                calculationResult.AccelerationTime = GetTimeToReachTravelSpeed(acceleration, travelSpeed);
                calculationResult.DecelerationTime = GetTimeToReachTravelSpeed(deceleration, travelSpeed);
                calculationResult.AccelerationDistance = GetDistanceForConstAcceleration(acceleration, calculationResult.AccelerationTime);
                calculationResult.DecelerationDistance = GetDistanceForConstAcceleration(deceleration, calculationResult.DecelerationTime);

                calculationResult.TravelSpeedDistance = distance - calculationResult.AccelerationDistance - calculationResult.DecelerationDistance;
                calculationResult.TravelSpeedTime = GetTimeForConstVelocity(travelSpeed, calculationResult.TravelSpeedDistance);
                calculationResult.TotalTime = calculationResult.AccelerationTime + calculationResult.TravelSpeedTime + calculationResult.DecelerationTime;
            }
            else
            {
                calculationResult.AccelerationDistance = GetDistanceForConstAcceleration(acceleration, calculationResult.AccelerationTime);
                calculationResult.DecelerationDistance = distance - calculationResult.AccelerationDistance;
                calculationResult.DecelerationTime = GetTimeForConstAcceleration(calculationResult.DecelerationDistance, deceleration);
                
                
                calculationResult.TotalTime = calculationResult.AccelerationTime + calculationResult.DecelerationTime;
            }

            return calculationResult;
        }

        private static double GetTime(double distance, double acceleration, double deceleration)
        {
            var timeForAcelerationWithoutMaxSpeed = Math.Sqrt(2 * distance / (acceleration + (Math.Pow(acceleration, 2) / deceleration)));
            return timeForAcelerationWithoutMaxSpeed;
        }

        private static bool IsMaxSpeedReached(double distance, double acceleration, double deceleration, double travelSpeed, MotionCalculationResult calculationResult)
        {
            calculationResult.AccelerationTime = GetTime(distance, acceleration, deceleration);
            calculationResult.MaxReachableSpeed = acceleration * calculationResult.AccelerationTime;
            //var maxReachableSpeed = Math.Sqrt(distance / acceleration);
            return calculationResult.MaxReachableSpeed > travelSpeed;
        }

        private static double GetTimeForConstAcceleration(double distance, double acceleration)
        {
            var time = Math.Sqrt(2 * distance / acceleration);
            return time;
        }

        private static double GetTimeToReachTravelSpeed(double acceleration, double travelSpeed)
        {
            var time = travelSpeed / acceleration;
            return time;
        }

        private static double GetDistanceForConstAcceleration(double acceleration, double time)
        {
            var distance = 0.5 * acceleration * Math.Pow(time, 2);
            return distance;
        }

        private static double GetTimeForConstVelocity(double velocity, double distance)
        {
            var time = distance / velocity;
            return time;
        }
    }
}
