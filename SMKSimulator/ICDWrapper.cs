using System;
using System.Globalization;

namespace SMKSimulator
{
    public class ICDWrapper
    {
        public string[] FinalGPSPacket = new string[]{ "$GPGGA,Time,0,LAT,N,LONG,E,2,9,1.44,ALT,M,-39.419,M,0000,0000*@\n\r",
                                    "$GPGSA,A,3,08,03,30,09,23,,,,,,,,1.97,1.44,1.36*08",
                                    "$GPGSA,A,3,68,73,69,82,,,,,,,,,1.97,1.44,1.36*07",
                                    "$GPRMC,TIME,A,LAT,N,LONG,E,SPEED_KTS,HDG,020217,,,D*@",
                                    "$GPVTG,HDG,T,,M,SPEED_KTS,N,SPEED_KMPH,K,D*@" };
        public ICDWrapper()
        {


        }

        public string methodGPSDataToDynon(string time, double lat, double lon, double alt, double alt_pressure, double heading, double grd_speed_kts,double grnd_track, 
            double vertical_speed_fpm, double incatedAirSpeed, double roll, double pitch, double aoa,double fuelLevelLeft,double fuelLevelRight,double RPM,double manifoldPres,
            double fuelPres, double oilPres,double oilTemp, double fuelflow,double alternatorCur,double OAT,double mainBusVolt,double EGT,double CHT,double EGT2, double CHT2, double EGT3, double CHT3,double EGT4, double CHT4, double EGT5, double CHT5, double EGT6, double CHT6)
        {

          
          //  latString = "33000000";// 

          //  lonString = "-72000000";

          //  string GPGGA = "GPGGA," + time + "," + latString + ",N," + lonString + ",E,1,8,1.74," + altString + ",M,-39.419,M,,";
          //  GPGGA = "$" + GPGGA + "*" + get_cs(GPGGA) + "\r\n";

          //  //string GPGSA = "$GPGSA,A,3,08,03,30,09,23,,,,,,,,1.97,1.44,1.36*08" + "\r\n";
          //  //string GPGSA2 = "$GPGSA,A,3,68,73,69,82,,,,,,,,,1.97,1.44,1.36*07" + "\r\n";

          //  string GPGSA = "$GPGSA,A,3,10,26,11,16,23,193,01,,,,,,1.94,1.74,0.86*3B\r\n";
          //  string GPGSA2 = "$GPGSA,A,3,76,,,,,,,,,,,,1.94,1.74,0.86*03\r\n";

          //  string GPRMC = "GPRMC," + time + ",A," + latString + ",N," + lonString + ",E," + speed_knts + "," + heding + ",020217,,,D";
          //  GPRMC = "$" + GPRMC + "*" + get_cs(GPRMC) + "\r\n";

          //  string GPVTG = "GPVTG," + heding + ",T,,M," + speed_knts + ",N," + speed_kmph + ",K,D";
          //  GPVTG = "$" + GPVTG + "*" + get_cs(GPVTG) + "\r\n";

          //  /* Tunning
          //  var altstr = ((int)(alt * 304.5)).ToString("#######");                                          //GPS Altitude (millimeters)
          //  var rollstr = string.Format("{00000}", ((int)(roll * 100)).ToString());                         //Roll (centidegrees)
          //  var pitchstr = string.Format("{00000}", ((int)((pitch) * 100)).ToString());                //Pitch (centidegrees)
          //  var aoastr = string.Format("{00000}", ((int)((aoa) * 100)).ToString());
          //  var groundspeed = ((int)(grd_speed_kts * 514.44)).ToString("#####");
          //  //Ground Speed (millimeters per second)
          //  var verticalspeed = string.Format("{00000}", ((int)(vertical_speed_fpm * 5.08)).ToString());


          //  */
          // // var timestr = string.Format("{000000}", (getTime().ToString());

           //DYFSA
          // string timecsv=getTimeDYFSA(time)
            var altstr = Math.Abs((int)(alt*304.8)).ToString("#######");  //GPS Altitude (millimeters)
            var alt_presure= Math.Abs((int)(alt_pressure*304.8)).ToString("#######");
            var rollstr = string.Format("{00000}", ((int)(roll*100)).ToString());                         //Roll (centidegrees)
            var pitchstr = string.Format("{00000}", ((int)((pitch*100))).ToString());                //Pitch (centidegrees)
            var aoastr = string.Format("{00000}", ((int)((aoa*100))).ToString());
            var groundspeed = (Math.Abs((grd_speed_kts * 514.444))).ToString("#####");
            //Ground Speed (millimeters per second)
            var verticalspeed = string.Format("{00000}", ((int)(vertical_speed_fpm/1000)).ToString());

            // string latDYFSA = string.Format("{00000000}", generateGPSValueDYFSA(lat).Substring(0,8)); //"20814333";    ////
            
            string latString = lat.ToString();
            string lonString = lon.ToString();
            if (latString != null || lonString != null)
            {
                if (latString.Length < 8)
                {
                    latString = latString + "00";
                }
                if (lonString.Length < 8)
                {
                    lonString = lonString + "00";

                }
            }

            string latDYFSA = latString.Substring(0, 8);
            string longtDYFSA = lonString.Substring(0, 8);
            // string latDYFSA = "20446333";
            //string longtDYFSA = "43185167";
            //string latDYFSA = generateGPSValue(lat);
            //string longtDYFSA = generateGPSValue(lon);


            //string   longtDYFSA =  string.Format("{00000000}", generateGPSValueDYFSA(lon).Substring(0, 8));
            //"43704833"; 
            // string hedingDYFSA = string.Format("{00000}", getHeadingForDynonICD(heading));
            string gTrackDYFSA = string.Format("{00000}", getHeadingForDynonICD(grnd_track));
            string hedingDYFSA = ((heading * 100)).ToString("#####");

            //DYFSB
            string iasDYFSB = string.Format("{00000}", incatedAirSpeed * 514.444);
            string FuelQLEftDYFSB = ((fuelLevelLeft*100)).ToString("####");
            string FuelQRightDYFSB = ((fuelLevelRight*100)).ToString("####");
            string RPMDYFSB = ((RPM)).ToString("####");
            string ManifoldDYFSB = ((manifoldPres*3.386375)).ToString("###");
            string FuelPresDYFSB = ((fuelPres * 6.895)).ToString("###");
            string OilPresDYFSB = ((oilPres * 6.895)).ToString("###");
            string OilTempDYFSB = ((oilTemp + 273.15)).ToString("###");
            string FuelFlowDYFSB = ((fuelflow *100)).ToString("####");
            string AltcurDYFSB = ((alternatorCur * 1000)).ToString("#####");
            string OutsideATDYFSB = ((OAT +273.15)).ToString("###");
            string mainBusVoltDYFSB = ((mainBusVolt *1000)).ToString("#####");
            string EGTDYFSB = ((EGT +273.15)).ToString("####");
            string CHTDYFSB = ((CHT + 273.15)).ToString("###");
            string EGTDYFSB2 = ((EGT2 + 273.15)).ToString("####");
            string CHTDYFSB2 = ((CHT2 + 273.15)).ToString("###");
            string EGTDYFSB3 = ((EGT3 + 273.15)).ToString("####");
            string CHTDYFSB3 = ((CHT3 + 273.15)).ToString("###");
            string EGTDYFSB4 = ((EGT4 + 273.15)).ToString("####");
            string CHTDYFSB4 = ((CHT4 + 273.15)).ToString("###");
            string EGTDYFSB5 = ((EGT5 + 273.15)).ToString("####");
            string CHTDYFSB5 = ((CHT5 + 273.15)).ToString("###");
            string EGTDYFSB6 = ((EGT6 + 273.15)).ToString("####");
            string CHTDYFSB6 = ((CHT6 + 273.15)).ToString("###");
            //string hedingDYFSA = ((heading * 100)).ToString("#####");

            //Console.WriteLine("pitch string : " + pitchstr);
            //if (altstr.Length > 8)
            //    altstr = altstr.Substring(0, 7);
            //Console.WriteLine(roll + "/" + pitch);
            //string DYFSA = "DYFSA,1119654250,"+time+",300317,P,28747710,-73339917,1242372,1073022,1242372,2995,76,15978,14237,16358,78,1398,478,V,91983,91720,7789,-3654,-88234,25993,-3700,A,351,1041,-1584,-391,25,-1887,12154,W,63,-324,233,277";
            //string DYFSA = "DYFSA,1119654250," +time+ ",300317,P,"+gpsFormatForDynonICD(lat)+","+gpsFormatForDynonICD(lon)+","+altstr+","+ altstr+","+ pitchstr + ","+ rollstr+ ","+getHeadingForDynonICD(heading)+ "," + getHeadingForDynonICD(heading) + ","+ getHeadingForDynonICD(heading) + ",0,0,0,V,"+"0"+","+groundspeed+",0,"+verticalspeed+",0,0," + getHeadingForDynonICD(heading) + ",A,0,0,0,0,0,0,0,W,0,0,0,0";

            //string DYFSA = "DYFSA,1119654250," + time + ",300317,P," + gpsFormatForDynonICD(lat) + "," + gpsFormatForDynonICD(lon) + "," + altstr + "," + altstr/*Pressure altitude -millimeters*/+ "," + "0" + "," + rollstr + "," + pitchstr + "," + "0"/*true heading (centidegrees)*/
            //    + "," + getHeadingForDynonICD(heading) + "," + getHeadingForDynonICD(heading) + "," + aoastr + ",0,V," + "+0" + "," + groundspeed + ",0," + "0" + "," + verticalspeed + ",0," + "0" + ",A,0,0,0,0,0,0,0,W,0,0,0,0";
            //DYFSA = "$" + DYFSA + "*" + get_cs(DYFSA) + "\r\n";
            string DYFSA = "DYFSA,1119654250," + getTimeDYFSA() + ",300317,P," +latDYFSA + "," + longtDYFSA + "," + altstr + ",1073022," + alt_presure/*Pressure altitude -millimeters*/+ ","  + rollstr + "," + pitchstr + "," + hedingDYFSA + "," + hedingDYFSA/*true heading (centidegrees)*/
              + "," + gTrackDYFSA + "," + aoastr + ",0,V," + "0" + "," + groundspeed + ","+ groundspeed + "," +  groundspeed + "," + verticalspeed + ","+verticalspeed+"," + "0" + ",A,0,0,0,0,0,0,0,W,0,0,0,0";
            DYFSA = "$" + DYFSA + "*" + get_cs(DYFSA) + "\r\n";

            //string DYFSB = "DYFSB,1119654250," + getTimeDYFSA() + ",-2995,-76,14234,18473,90663," + iasDYFSB + "," + iasDYFSB + ",277,4587,0,4587,101,E0,2574,127,275,413,0,358,1115,437,301,2053,28000,12000,1115,437,1115,437,1115,437,1115,437,1115,437,1115,437,C,0,0,0,0,0,0,E,280,87,1085,164,0,-1047,M,28000,12000,24000,0";
            //DYFSB = "$" + DYFSB + "*" + get_cs(DYFSB) + "\r\n";    Original
            string DYFSB = "DYFSB,1119654250," + getTimeDYFSA()+0 + ",-2995,-76,14234,18473,90663," + iasDYFSB + "," + "0" + ",277"+","+FuelQLEftDYFSB+",0,"+FuelQRightDYFSB+",101,E0,"+RPMDYFSB+ "," + ManifoldDYFSB + "," + FuelPresDYFSB + "," + OilPresDYFSB + ",0," + OilTempDYFSB + ",0,358,1115," + FuelFlowDYFSB + ",301," + AltcurDYFSB + "," + EGTDYFSB + "," + CHTDYFSB + "," + EGTDYFSB2 + "," + CHTDYFSB2 + "," + EGTDYFSB3 + "," + CHTDYFSB3 + "," + EGTDYFSB4 + "," + CHTDYFSB4 + "," + EGTDYFSB5 + "," + CHTDYFSB5 + "," + EGTDYFSB6 + "," + CHTDYFSB6 + "," + EGTDYFSB6 + "," + CHTDYFSB6 + ",C,0,0,0,0,0,0,E," + OutsideATDYFSB+",87,1085,164,0,-1047,M,"+mainBusVoltDYFSB+",12000,24000,"+alternatorCur;
            DYFSB = "$" + DYFSB + "*" + get_cs(DYFSB) + "\r\n";

            //string PASHR = "PASHR," + time + "," + heding + ",T," + roll_string + "," + pitch_string + ",0.34,0.01,0.03,0.05,2,1";
            //PASHR = "$" + PASHR + "*"+get_cs(PASHR)+"\r\n";

            //string PRDID_ = "PRDID," + pitch_string + "," + roll_string + "," + heding;
            //PRDID_ = "$" + PRDID_ + "*" + get_cs(PRDID_) + "\r\n";

            //GPGGA = "$GPGGA,055946.400,3351.126855,N,07224.835626,E,1,8,1.74,331.170,M,-39.419,M,,*73\r\n";
            

            string[] FinalGPSPacket = new string[] {/*GPGGA ,
                                                    GPGSA,
                                                    GPGSA2,
                                                    GPRMC ,
                                                    GPVTG,*/
                                                    DYFSA,
                                                   DYFSB
                                    };
            string result = "";
            for (int i = 0; i < FinalGPSPacket.Length; i++)
            {
                result = result + FinalGPSPacket[i];
            }
            return result;
        }
        public string getTime()
        {
            var value = DateTime.Now;
            string check = getTimeFormat(value);
            return check;
        }
        public string getTimeDYFSA()
        {
            var value = DateTime.Now;
            string check = getTimeFormatforDYFSA(value);
            return check;
        }

        public string gpsFormatForDynonICD(double value)
        {
            double latdouble = Convert.ToDouble(value) * 60;
            string latstring = latdouble.ToString().Replace(".", "");
            if (latstring.Length > 9)
            {
                latstring = latstring.Substring(0, 8);
            }
            return latstring;
        }
        public string getHeadingForDynonICD(double value)
        {
            double centidegree = value * 100;
            string strval = centidegree.ToString();
            if (strval.Length > 5)
            {
                strval = strval.Substring(0, 6);
            }
            return strval;
        }
        public string getTimeFormat(DateTime value)
        {
            return value.ToString("HHmmss.fff");
        }
        public string getTimeFormatforDYFSA(DateTime value)
        {
            return value.ToString("HHmmss");
        }
        //public string getTimeGPSDYFSA(string dateTime) { }
        //CultureInfo culture = new CultureInfo("en-US");
        //string dateValue = "03/15/2019 06:30:23 PM";
        //DateTime value = DateTime.ParseExact(dateValue, "MM/dd/yyyy hh:mm:ss tt", culture);
        //string desiredValue = value.ToString("MM/dd/yy HH:mm", culture);

        public string generateGPSValue(double value)
        {
            int constVal = 60;
            string finalString = "";
            string finalVal = null;
            string part1 = "";

            string part2 = "";
            double degrees;
            int minutes;
            int seconds;
            string finalval = "";
            string decimalHead = "";
            double val = 0.0;
            double sum = 0.0;
            string valuestr="";

            try
            {

                string stringval = Convert.ToString(value);
                string[] stringarray = stringval.Split('.');

                decimalHead = stringarray[0];

                double doubleVal = Convert.ToDouble("." + stringarray[1]);
                //Console.WriteLine(stringarray[0] + "/" + stringarray[1]);


                double MulbySixty = doubleVal * constVal;

                String string_MulbySixty = Convert.ToString(MulbySixty);
                string[] stringArray2 = string_MulbySixty.Split('.');

                part1 = stringArray2[0];
                if (part1.Length == 1)
                    part1 = "0" + part1;

                part2 = stringArray2[1];
                //part2 = part2.Substring(0, 4);
                double secondsVal = Convert.ToDouble(part2);
                //new chNGES
                double hours = Convert.ToDouble(decimalHead);
                double minute = Convert.ToDouble(part1)/60;
                double second = Convert.ToDouble(part2)/3600;
                sum = Convert.ToDouble(hours + minute + second);
                val = (sum*60) *10000.0;
                 valuestr = val.ToString();
                valuestr = valuestr.Replace(".", "");

            }
            catch (Exception e)
            {
                Console.WriteLine("No Data From FDM....!\t\t Please Check FDM Connection Status.");
            }
            //  return decimalHead + part1 + "." + part2;

            return valuestr.Substring(0, 8);
        }

        public string generateGPSValueDYFSA(double value)
        {
            string val = "";
            try {
               
               string stringval = Convert.ToString(value);
                //if (stringval.Length >= 7)
                //{
                    

                string[] decimalParts = stringval.Split('.');

                int degrees = Convert.ToUInt16(decimalParts[0]);
                int minutes = Convert.ToInt16(decimalParts[1].Substring(0, 2));

                //int decimalpart = Convert.ToUInt16(decimalParts[1]) / 100;
                // string str_decimalpart = Convert.ToString(decimalpart);
                //  string[] minutesDecimal = str_decimalpart.Split('.');
                int seconds = Convert.ToInt16(decimalParts[1].Substring(2));
              //  int part2Minut = Convert.ToInt16(minutesDecimal[0]);
                //int part3Minut = Convert.ToInt16(minutesDecimal[1]);


                degrees = degrees * 60;
                seconds = seconds / 60;
                double calculatedval = ((degrees) + (minutes) + (seconds) )* 10000.0;
                    val = (calculatedval).ToString("########").Replace(".","");
               // }
            }
            catch (Exception e)
            {
                
            }
            return val;
        }
        public string get_cs(string data)
        {
            byte result = 0x00;
            for (int i = 0; i < data.Length; i++)
            {
                result = (byte)(result ^ data[i]);
            }
            string temp = string.Format("{0:X}", result);
            if (temp.Length == 1)
                temp = "0" + temp;
            return temp;
            //Console.WriteLine(result);
        }
    }
}
