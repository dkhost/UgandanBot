using System;
using System.Drawing;
using Robocode;
using Robocode.Util;

namespace LuanEGuilherme
{

    public class UgandanBot : Robot
    {
        private bool peek;
        private double moveAmount;

        
        public override void Run()
        {

            BodyColor = (Color.Black);
            GunColor = (Color.Orange);
            RadarColor = (Color.DarkGreen);
            BulletColor = (Color.PaleGreen);
            ScanColor = (Color.Black);


            moveAmount = Math.Max(855, 595);

            peek = false;


            TurnRight(Heading % 90);
            Ahead(moveAmount);

            peek = true;
            TurnGunLeft(90);
            TurnLeft(90);

            while (true)
            {

                peek = true;
                Ahead(moveAmount);
                peek = false;
                TurnLeft(90);
            }
        }
        public override void OnHitRobot(HitRobotEvent e)
        {

            if (e.Bearing > -90 && e.Bearing < 90)
            {
                Ahead(90);
            }
            else
            {
                Back(90);
            }
        }
        public override void OnScannedRobot(ScannedRobotEvent e)
        {
            Fire(1);
            if (peek)
            {
                Scan();
            }
        }
    }
}