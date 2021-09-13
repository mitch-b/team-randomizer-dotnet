using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace TeamRandomizer
{
    public class TestApp
    {
        private readonly ILogger<TestApp> _log;
        private readonly IConfiguration _config;
        private readonly Random _random = new Random();

        public TestApp(ILogger<TestApp> log, IConfiguration config)
        {
            this._log = log;
            this._config = config;
        }

        public async Task RunAsync()
        {
            // Setup stuff
            var members = new List<string>(await File.ReadAllLinesAsync("people.txt"));
            var numberOfGroups = this._config.GetValue<int>("settings:NumberOfGroups");
            var maxPerGroup = Math.Ceiling(members.Count / (double)numberOfGroups);

            this._log.LogInformation($"Sorting {members.Count} into {numberOfGroups} groups (max per group of {maxPerGroup})");

            // Logic stuff
            var groups = CreateGroups(members, numberOfGroups, maxPerGroup);
            await PrintAndWriteToFileAsync(groups, "output.txt");
        }

        private List<List<string>> CreateGroups(IEnumerable<string> people, double numberOfGroups, double maxPerGroup)
        {
            // setup all empty groups
            var groups = new List<List<string>>();
            for (int i = 0; i < numberOfGroups; i++) groups.Add(new List<string>());

            // loop through each person and sort into a 
            // random group (by random index) from "available groups"
            // which are groups that haven't already hit 'maxPerGroup' membership
            foreach (var person in people)
            {
                var availableGroups = groups.Where(g => g.Count < maxPerGroup).ToList();
                var groupIndex = _random.Next(0, availableGroups.Count);
                availableGroups[groupIndex].Add(person);
            }
            return groups;
        }

        private async Task PrintAndWriteToFileAsync(List<List<string>> groups, string filePath)
        {
            using var sw = new StreamWriter(filePath);
            for (int i = 0; i < groups.Count; i++)
            {
                this._log.LogInformation($"> Group {i+1}");
                await sw.WriteLineAsync($"> Group {i+1}");
                for (int j = 0; j < groups[i].Count; j++)
                {
                    this._log.LogInformation(groups[i][j]);
                    await sw.WriteLineAsync(groups[i][j]);
                }
                this._log.LogInformation("");
                await sw.WriteLineAsync("");
            }
        }
    }
}
