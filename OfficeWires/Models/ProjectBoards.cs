using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace OfficeWires.Models
{
    public class ProjectBoards
    {
        static public async Task<IEnumerable<ProjectBoard>> ProjectList( string userId )
        {
            List<ProjectBoard> boards = new List<ProjectBoard>();
            HttpClient GithubAPI = new HttpClient();
            HttpResponseMessage resp = null;

            GithubAPI.DefaultRequestHeaders.UserAgent.TryParseAdd("request");
            string requestUrl = $"https://api.github.com/users/{userId}/repos";
            
            
            resp = await GithubAPI.GetAsync(requestUrl);

            if (resp.IsSuccessStatusCode)
            {
                var result = await resp.Content.ReadAsStringAsync();
                boards = JsonSerializer.Deserialize<List<ProjectBoard>>(result.ToString());
            }

            else
            {
                boards.Add(
                        new ProjectBoard
                        {
                            Name = "not found",
                            Description = "",
                        }
                    );
            }

            for (int i = 0; i < boards.Count; i++)
            {
                if( boards[i].GitHubUrl.Length > 1 ) 
                {
                    boards[i].ImageTitle = await imageFileName_Async(userId, boards[i]);
                    boards[i].URL = await appLinkUrl_Async(userId, boards[i]);
                }
            }

            return boards;
        }

        static async Task<string> imageFileName_Async(string owner, ProjectBoard proj)
        {
            HttpClient ReadmeContent = new HttpClient();
            HttpResponseMessage resp = null;

            // string breakpoint = proj.Name;

            ReadmeContent.DefaultRequestHeaders.UserAgent.TryParseAdd("request");
            resp = await ReadmeContent.GetAsync($"https://raw.githubusercontent.com/{owner}/{proj.Name}/{proj.WorkingBranch}/README.md");

            if (resp.IsSuccessStatusCode)
            {
                string line = await resp.Content.ReadAsStringAsync();

                //if (line.Contains("![icon]"))
                if (line.Contains("!["))
                {
                    int start = line.IndexOf('(') + 1;
                    int len = line.IndexOf(')') - start;
                    return line.Substring(start, len);
                }
            }

            return "";
        }

        static async Task<string> appLinkUrl_Async(string owner, ProjectBoard proj)
        {
            HttpClient ReadmeContent = new HttpClient();
            HttpResponseMessage resp = null;

            // string breakpoint = proj.Name;

            ReadmeContent.DefaultRequestHeaders.UserAgent.TryParseAdd("request");
            resp = await ReadmeContent.GetAsync($"https://raw.githubusercontent.com/{owner}/{proj.Name}/{proj.WorkingBranch}/README.md");

            if (resp.IsSuccessStatusCode)
            {
                StringReader readme = new StringReader(await resp.Content.ReadAsStringAsync());

                while(true)
                {
                    string line = readme.ReadLine();
                    if (line == null) break;
                    if (line.Contains("[url]"))
                    {
                        int start = line.IndexOf('(') + 1;
                        int len = line.IndexOf(')') - start;
                        return line.Substring(start, len);
                    }
                }
            }

            return "";
        }
    }
}
