using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Task5Hakers:Itask
    {
        public string main(string input)
        {
            var inputList = input.Split('_');
            List<ResponseStruct> responseList = new();
            var timeInput = inputList[0].Split(":");
            var n = int.Parse(inputList[1]);
            TimeOnly startTime = new TimeOnly(int.Parse(timeInput[0]), int.Parse(timeInput[1]), int.Parse(timeInput[2]));
            TimeOnly endTime = startTime.AddHours(23).AddMinutes(59).AddMinutes(0.99);
            for (int i = 0; i < n; i++)
            {
                var responsetInput = inputList[2+i];
                var indexOfEndTeamName = responsetInput.LastIndexOf("\"");
                var teamName = responsetInput.Substring(1, indexOfEndTeamName-1);
                var splitedresponse = responsetInput.Substring(indexOfEndTeamName+2).Split(" ");
                var hackTime = new TimeOnly(int.Parse(splitedresponse[0].Split(":")[0]),
                                            int.Parse(splitedresponse[0].Split(":")[1]),
                                            int.Parse(splitedresponse[0].Split(":")[2]));
                var serverName = splitedresponse[1];
                var ResponseResult = splitedresponse[2];
                responseList.Add(new ResponseStruct()
                {
                    teamName = teamName,
                    hackTime = hackTime,
                    serverName = serverName,
                    ResponseResult = ResponseResult
                });
            }

            Dictionary<string, int> playersResultMap = new();
            Dictionary<string, int> playersPenality = new();
            const string accessedStatus = "ACCESSED";
            const string deniedStatus = "DENIED";
            const string forbiddenStatus = "FORBIDEN";
            const string pingStatus = "PING";
            int penaltyTime = 20; //20 минут штрафа за неудачный взлом

            foreach (var response in responseList)
            {
                if (response.ResponseResult == accessedStatus)
                {
                        playersResultMap[response.teamName] = (playersResultMap.TryGetValue(response.teamName, out int result) ? result : 0) + 1;
                        TimeSpan hackTimeFromStart =  response.hackTime - startTime;
                        var deniedTryCount = responseList.Where(r => 
                            r.teamName == response.teamName
                            && (r.ResponseResult == deniedStatus 
                            || r.ResponseResult == forbiddenStatus));

                        playersPenality[response.teamName] = (playersPenality.TryGetValue(response.teamName, out int minute) 
                            ? minute
                            : (int)hackTimeFromStart.TotalMinutes + deniedTryCount.Count()*penaltyTime);
                }
            }
            List<ResultString> results = new List<ResultString>();
            foreach(var kvPair in playersResultMap)
            {
                results.Add(new ResultString
                {
                    place = -1,
                    TeamName = kvPair.Key,
                    HackedServerCount = kvPair.Value,
                    PenaltyTime = playersPenality[kvPair.Key]
                });
            }
            results = results.OrderByDescending(result => result.HackedServerCount).ThenBy(result => result.PenaltyTime).ThenBy(result => result.TeamName).ToList();
            results[0].place = 1;
            var repetedPlacesCount = 1;
            for (int i = 1; i < results.Count; i++)
            {

                if (results[i].HackedServerCount == results[i - 1].HackedServerCount
                    && results[i].PenaltyTime == results[i - 1].PenaltyTime)
                {
                    results[i].place = results[i - 1].place;
                    repetedPlacesCount++;
                }
                else
                {
                    results[i].place = results[i - 1].place + repetedPlacesCount;
                    repetedPlacesCount = 1;
                }
            }
            var finalResult = "";
            foreach (var res in results)
            {
                finalResult += res.ToString() + " ";
            }
            return finalResult;
        }
        public class ResponseStruct()
        {
            public string teamName;
            public TimeOnly hackTime;
            public string serverName;
            public string ResponseResult;
        }
        public class ResultString
        {
            public int place;
            public string TeamName;
            public int HackedServerCount;
            public int PenaltyTime;

            public override string ToString()
            {
                var result = $"{place} \"{TeamName}\" {HackedServerCount} {PenaltyTime}";
                return result;

            }
        }
    }

}
