using System;
using System.Collections.Generic;
using System.Text;

namespace MotionCalculator
{
    public class MotionCalculationResult
    {
        public double TotalTime { get; set; }
        public double AccelerationTime { get; set; }
        public double AccelerationDistance { get; set; }
        public double DecelerationTime { get; set; }
        public double DecelerationDistance { get; set; }
        public double TravelSpeedTime { get; set; }
        public double TravelSpeedDistance { get; set; }
        public double MaxReachableSpeed { get; set; }
    }
}
