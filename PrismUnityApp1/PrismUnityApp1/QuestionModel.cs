using SiwakeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace SiwakeApp
{
    public class QuestionModel
    {
        public IEnumerable<QuestionSetInfo> Questions { get; private set; }

        public QuestionModel()
        {
            LoadQuestion(PCLResource.Questions);
        }

        public QuestionModel(string QuestionUrl)
        {
            if (QuestionUrl == "")
            {
                LoadQuestion(PCLResource.Questions);
            }
            else
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        var json = client.GetStringAsync(QuestionUrl);
                        json.Wait();
                        LoadQuestion(json.Result);
                    }
                    catch (Exception)
                    {
                        LoadQuestion(PCLResource.Questions);
                    }
                }
            }
        }

        public void LoadQuestion(string json)
        {
            Questions = Newtonsoft.Json.JsonConvert.DeserializeObject<List<QuestionSetInfo>>(json);
        }
    }
}
