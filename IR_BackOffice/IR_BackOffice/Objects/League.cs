using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using PagedList;
using WebGrease.Extensions;

namespace IR_BackOffice.Objects
{
    public class League
    {
        public String LeagueName { get; set; }
        public String LeagueCode { get; set; }
        public List<Score> Scores { get; set; }

        public static String ExtractCodeFromTitle(string title)
        {
            try
            {
                string[] parts = title.Split('(');
                string[] parts2 = parts[1].Split(')');

                return parts2[0];

            }
            catch {
                return "";
            }                        
        }

        public static String ExtractTitleFromTitle(string title)
        {
            string[] parts = title.Split('(');

            if (parts.Length == 4)
            {
                string[] parts2 = parts[1].Split(')');
                string[] parts3 = Regex.Split(parts[2], " vs ");
                string[] parts4 = Regex.Split((parts[3]), ": ");

                return parts2[1] + " vs " + parts3[1] + ": " + parts4[1];
            }
            else
            {
                string[] parts2 = parts[1].Split(')');
                return parts2[1].Substring(1);
            }
        }

        public static String GetLeagueNameFromCode(string code, bool fromCode)
        {
            return Codes.GetLeagueNameFromCode(code, fromCode);
        }

        public static string[] GetAlternateScoreArray(Score score)
        {
            var scores = new string[3];

            try
            {
                string[] parts = Regex.Split(score.Title, " vs ");
                string[] parts2 = Regex.Split(parts[1], ": ");

                scores[0] = parts[0];
                scores[1] = parts2[1];
                scores[2] = parts2[0];
            }
            catch (Exception e)
            {
                // Corrupt data, deal with it in view
                return null;
            }

            return scores;
        }
    }

    public class Score
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
    }

    public class LeagueCollection : IEnumerable<League>
    {
        private List<League> m_leagues = new List<League>();

        public IEnumerator<League> GetEnumerator()
        {
            return this.m_leagues.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(League leauge)
        {
            m_leagues.Add(leauge);
        }

        public List<League> Items()
        {
            return m_leagues;
        }

        public Boolean ContainsLeague(string leagueNameOrCode)
        {
            return m_leagues.Any(l => l.LeagueName == leagueNameOrCode || l.LeagueCode == leagueNameOrCode);
        }

        public void AddLeaugeScore(string leaugeNameOrCode, string title, string description, string date)
        {
            foreach (var league in m_leagues)
            {
                if (league.LeagueCode == leaugeNameOrCode || league.LeagueName == leaugeNameOrCode)
                {
                    var score = new Score { Title = title, Description = description, DateAdded = DateTime.Parse(date) };
                    league.Scores.Add(score);

                    break;
                }
            }
        }
    }
}
