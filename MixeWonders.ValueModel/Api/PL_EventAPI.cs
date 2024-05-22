using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixeWonders.ValueModel.Api
{
    public class PL_EventAPI
    {
        public string idEvent { get; set; }
        public string idSoccerXML { get; set; }
        public string idAPIfootball { get; set; }
        public string strEvent { get; set; }
        public string strEventAlternate { get; set; }
        public string strFilename { get; set; }
        public string strSport { get; set; }
        public string idLeague { get; set; }
        public string strLeague { get; set; }
        public string strSeason { get; set; }
        public string strDescriptionEN { get; set; }
        public string strHomeTeam { get; set; }
        public string strAwayTeam { get; set; }
        public string intHomeScore { get; set; }
        public string intRound { get; set; }
        public string intAwayScore { get; set; }
        public string intSpectators { get; set; }
        public string strOfficial { get; set; }
        public string strTimestamp { get; set; }
        public string dateEvent { get; set; }
        public string dateEventLocal { get; set; }
        public string strTime { get; set; }
        public string strTimeLocal { get; set; }
        public string strTVStation { get; set; }
        public string idHomeTeam { get; set; }
        public string idAwayTeam { get; set; }
        public string intScore { get; set; }
        public string intScoreVotes { get; set; }
        public string strResult { get; set; }
        public string strVenue { get; set; }
        public string strCountry { get; set; }
        public string strCity { get; set; }
        public string strPoster { get; set; }
        public string strSquare { get; set; }
        public string strFanart { get; set; }
        public string strThumb { get; set; }
        public string strBanner { get; set; }
        public string strMap { get; set; }
        public string strTweet1 { get; set; }
        public string strTweet2 { get; set; }
        public string strTweet3 { get; set; }
        public string strVideo { get; set; }
        public string strStatus { get; set; }
        public string strPostponed { get; set; }
        public string strLocked { get; set; }
    }

    public class PL_EventAPIResponse
    {
        public List<PL_EventAPI> events { get; set; }
    }
}
