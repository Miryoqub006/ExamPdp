using System.Text.Json;
using TestProject.Api.Entites;

namespace TestProject.Api.Repositories;

public class QuestionsRepositories : IQuestionRepository
{
    private readonly string _filePath;
    public QuestionsRepositories()
    {
        _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Questions.json");
        var directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        if (!File.Exists(_filePath))
        {

            var stream = File.Create(_filePath);
            stream.Close();
        }
    }

    public void AddQuestion(Question question)
    {
        throw new NotImplementedException();
    }

    public List<Question>? GetAllQuestions()
    {
        string json = File.ReadAllText(_filePath);

        if (string.IsNullOrEmpty(json))
        {
            return new List<Question>();
        }

        List<Question> questions = JsonSerializer.Deserialize<List<Question>>(json);
        return questions;


    }
    
   

    


}



