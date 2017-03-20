using SiwakeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiwakeApp
{
    public class QuestionModel
    {
        public IEnumerable<QuestionSetInfo> Questions { get; private set; }

        public QuestionModel()
        {
            LoadQuestion();
        }

        public async void LoadQuestion()
        {
            Questions = Newtonsoft.Json.JsonConvert.DeserializeObject<List<QuestionSetInfo>>(PCLResource.Questions);
        }

        public ObservableCollection<QuestionSetInfo> GetQuestionSetList()
        {
            var result = new ObservableCollection<QuestionSetInfo>();
            foreach(var item in Questions)
            {
                result.Add(item);
            }
            return result;
        }
    }
}
