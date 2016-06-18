using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IR_BackOffice.Objects
{
    public class Codes
    {
        public static String GetLeagueNameFromCode(string code, bool fromCode)
        {
            if (fromCode)
            {
                switch (code)
                {
                    case ("ANG-D1"):
                        return "Angolan First Division";
                    case ("ARG-AP"):
                        return "Argentine Primera División";
                    case ("AUT-CTR"):
                        return "Austria Regional League Central";
                    case ("AUT-EST"):
                        return "Austria Regional League East";
                    case (" AUT-WST"):
                        return "Austria Regional League West";
                    case ("AUT-EL"):
                        return "Austrian First League";
                    case ("AUT-BL"):
                        return "Austrian Football Bundesliga";
                    case ("AZE-D1"):
                        return "Azerbaijan Premier League";
                    case ("BLR-D1"):
                        return "Belarusian Premier League";
                    case ("BEL-PL"):
                        return "Belgian Pro League";
                    case ("BEL-D2"):
                        return "Belgian Second Division";
                    case ("BUL-AFG"):
                        return "Bulgarian A Group";
                    case ("BUL-BG"):
                        return "Bulgarian B Football Group";
                    case ("GER-FA"):
                        return "Bundesliga";
                    case ("NCA-CCC"):
                        return "CONCACAF Champions League";
                    case ("NCA-CCL"):
                        return "CONCACAF Champions League";
                    case ("BRA-D1"):
                        return "Campeonato Brasileiro Série A";
                    case ("BRA-D2"):
                        return "Campeonato Brasileiro Série B";
                    case ("CHI-"):
                        return "Chilean";
                    case ("CHI-AP"):
                        return "Chilean Primera División";
                    case ("CHN-CUP"):
                        return "Chinese FA Cup";
                    case ("CHN-D1"):
                        return "Chinese Super League";
                    case ("COL-CL"):
                        return "Columbian Categoría Primera A";
                    case ("COL-FA"):
                        return "Columbian Categoría Primera B";
                    case ("CAF-CCL"):
                        return "Confederation of African Football Champions League";
                    case ("CAF-CCC"):
                        return "Confederation of African Football Confederation Cup";
                    case ("ARG-FA"):
                        return "Copa Argentina";
                    case ("CON-CS"):
                        return "Copa Sudamericana";
                    case ("ITA-FA"):
                        return "Coppa Italia";
                    case ("CRC-AP"):
                        return "Costa Rican Primera División";
                    case ("CRO-D1"):
                        return "Croatian Prva HNL (I)";
                    case ("CZE-D2"):
                        return "Czech 2. Liga";
                    case ("CZE-D1"):
                        return "Czech Gambrinus Liga (I)";
                    case ("DEN-D1"):
                        return "Danish 1st Division";
                    case ("DEN-SL"):
                        return "Danish Superliga";
                    case ("NED-D1"):
                        return "Dutch Eerste Divisie (Jupiler League)";
                    case ("NED-ERD"):
                        return "Dutch Eredivisie";
                    case ("ECU-D1"):
                        return "Ecuadorian Serie A";
                    case ("ENG-LC"):
                        return "England League Cup";
                    case ("ENG-CS"):
                        return "English Community Shield";
                    case ("ENG-FC"):
                        return "English Conference";
                    case ("ENG-ECH"):
                        return "English Football League Championship";
                    case ("ENG-EL1"):
                        return "English Football League One";
                    case ("ENG-EL2"):
                        return "English Football League Two";
                    case ("ENG-PR"):
                        return "English Premier League";
                    case ("EST-D1"):
                        return "Estonia Meistriliiga";
                    case ("FIN-YKN"):
                        return "Finnish First Division";
                    case ("FIN-VKL"):
                        return "Finnish Premier League";
                    case ("FRA-CN"):
                        return "French Championnat National";
                    case ("FRA-LC"):
                        return "French League Cup";
                    case ("FRA-L1"):
                        return "French Ligue 1";
                    case ("FRA-L2"):
                        return "French Ligue 2";
                    case ("GEO-D1"):
                        return "Georgian Premier League";
                    case ("GER-2BL"):
                        return "German 2. Bundesliga";
                    case ("GER-3LG"):
                        return "German 3. Liga";
                    case ("GER-BL"):
                        return "German Bundesliga";
                    case ("GER-NTH"):
                        return "German Regional League North";
                    case ("GER-RLNE"):
                        return "German Regionalliga Northeast";
                    case ("GER-RLSW"):
                        return "German Regionalliga Südwest";
                    case ("GER-WST"):
                        return "German Regionalliga West";
                    case ("HON-APE"):
                        return "Honduran Professional National Football League";
                    case ("HUN-D1"):
                        return "Hungarian Division I";
                    case ("IRN-PL"):
                        return "Iran Pro League";
                    case ("IRE-D1"):
                        return "Ireland First Division";
                    case ("IRE-PR"):
                        return "Ireland Premier Division";
                    case ("NIR-IFA"):
                        return "Irish League";
                    case ("ISL-PR"):
                        return "Israeli Premier League";
                    case ("JPN-D1"):
                        return "Japanese League Division 1";
                    case ("JPN-D2"):
                        return "Japanese League Division 2";
                    case ("JPN-D3"):
                        return "Japanese League Division 3";
                    case ("KOR-D1"):
                        return "K League Classic";
                    case ("KOR-FA"):
                        return "Korean FA Cup";
                    case ("LAT-D1"):
                        return "Latvian Higher League";
                    case ("IRE-LC"):
                        return "League of Ireland Cup";
                    case ("IRE-FA"):
                        return "League of Ireland Premier Division";
                    case ("MEX-AP"):
                        return "Liga MX";
                    case ("BOL-AP"):
                        return "Liga de Fútbol Profesional Boliviano";
                    case ("LIT-D1"):
                        return "Lithuanian A League";
                    case ("FYR-D1"):
                        return "Macedonian First League";
                    case ("MDA-D1"):
                        return "Moldovan National Division";
                    case ("MNE-D1"):
                        return "Montenegrin First League";
                    case ("USA-NASL"):
                        return "North American Soccer League";
                    case ("NOR-2G1"):
                        return "Norwegian 2. Divisjon Group 1";
                    case ("NOR-2G2"):
                        return "Norwegian 2. Divisjon Group 2";
                    case ("NOR-2G3"):
                        return "Norwegian 2. Divisjon Group 3";
                    case ("NOR-2G4"):
                        return "Norwegian 2. Divisjon Group 4";
                    case ("NOR-ADE"):
                        return "Norwegian Adeccoligaen (II)";
                    case ("NOR-TIP"):
                        return "Norwegian Tippeligaen (I)";
                    case ("PAR-CL"):
                        return "Paraguayan Primera División";
                    case ("PER-D1"):
                        return "Peruvian Primera División";
                    case ("POL-D1"):
                        return "Polish Ekstraklasa";
                    case ("POL-D3"):
                        return "Polish First League";
                    case ("POL-D2"):
                        return "Polish I liga";
                    case ("POR-LC"):
                        return "Portuguese Second Division";
                    case ("POR-LH"):
                        return "Portuguese Segunda Liga";
                    case ("GER-RLBV"):
                        return "Regionalliga Bayern (IV)";
                    case ("ROU-L1"):
                        return "Romanian Liga I";
                    case ("ROU-L2"):
                        return "Romanian Liga II";
                    case ("RUS-PR"):
                        return "Russian Football Premier League";
                    case ("RUS-D1"):
                        return "Russian National Football League";
                    case ("SLV-APE"):
                        return "Salvadoran Primera División";
                    case ("SCO-D1"):
                        return "Scottish Football League First Division";
                    case ("SCO-D2"):
                        return "Scottish Football League Second Division";
                    case ("SCO-D3"):
                        return "Scottish Football League Third Division";
                    case ("SCO-LC"):
                        return "Scottish League Cup";
                    case ("SCO-PR"):
                        return "Scottish Premier League";
                    case ("SRB-D1"):
                        return "Serbian SuperLiga";
                    case ("SIN-D1"):
                        return "Singapore League";
                    case ("SVK-D1"):
                        return "Slovak Super Liga";
                    case ("SLO-D1"):
                        return "Slovenian PrvaLiga";
                    case ("RSA-MTN"):
                        return "South Africa's MTN 8 Cup";
                    case ("RSA-PR"):
                        return "South African Premier Division";
                    case ("INT-SBC"):
                        return "Suruga Bank Championship";
                    case ("SWE-ASV"):
                        return "Swedish Allsvenskan (I)";
                    case ("SWE-SPR"):
                        return "Swedish Superettan (II)";
                    case ("SWI-CHL"):
                        return "Swiss Super League";
                    case ("SWI-SL"):
                        return "Swiss Super League";
                    case ("THA-TPL"):
                        return "Thai Premier League";
                    case ("ARG-D2"):
                        return "Torneo Argentino A";
                    case ("TUR-USC"):
                        return "Turkish Super Cup";
                    case ("UEFA-GS"):
                        return " UEFA Champions League Group Stage";
                    case ("UEFA-CHL"):
                        return " UEFA Champions League";
                    case ("UEFA-UC"):
                        return "UEFA Europa League";
                    case ("UEFA-U21"):
                        return "UEFA Under 21 Championship";
                    case ("USA-MLS"):
                        return "US Major League Soccer";
                    case ("USA-CUP"):
                        return "US Open Cup";
                    case ("UKR-D1"):
                        return "Ukrainian Premier League";
                    case (" VNM-VL"):
                        return "V. League (Vietnam)";
                    case ("VEN-AP"):
                        return "Venezuelan Primera División";
                    default:
                        return "Other: (" + code + ")";
                }
            }
            else
            {
                var db = new IR_BackOffice.Infrastructure.IR_Database();
                var items = db.LeagueCodes;

                foreach (var item in items)
                {
                    if (item.LeagueCode == code)
                    {
                        return item.Name;
                    }
                }

                return code;
            }
        }
    }
}