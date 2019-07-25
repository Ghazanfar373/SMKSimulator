using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMKSimulator
{
    class FDMData
    {
        public int ID;
        public double Velocity_Kts;
        public double MachNumber;
        public double GValue;
        public double SideSlip;
        public double Roll_deg;
        public double Pitch_deg;
        public double AtmosphereTemperature;
        public double Heading_deg;
        public double Altitude_ft;
        public double VerticleVelocity_fpm;
        public double Latitude;
        public double Longitude;
        public double AltitudeAboveSeaLevel_ft;
        public double SimTime;
        public double AngleOFAttack;
        public double TrueAirSpeed;
        public double GroundAirSpeed;
        public double thetadot;
        public double phidot;
        public double psidot;
        public double WindSpeed;
        public double WindDirection;
        public bool GeneratorStatus;
        public bool GeneratorIndicatorLight;
        public double ACBusVoltage;
        public bool ACBusIndicatorLight;
        public double DCBusVoltage;
        public bool DCBusIndicatorLight;
        public double BatteryVoltage;

    }
}
