using TestProject.Api.DTOS;
using TestProject.Api.Entites;
using TestProject.Api.Repositories;

namespace TestProject.Api.Service;

public class QuestionService : IQuestionService
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IQuestionService _questionService;
    public QuestionService()
    {
        _questionRepository = new QuestionsRepositories();
        _questionService = new QuestionService();

    }
    public int GetCountOfQuestions()
    {
        int counter = 0;
        List<Question> questions = _questionRepository.GetAllQuestions();

        for (int i = 0; i < questions.Count i++)
        {
            if (questions[i] is not null)
            {
                counter++;
            }
        }

        return counter;
    }

    public  GetQuestionDto GetRandomQuestion()
    {
         List<Question> randomQuestion = _questionRepository.GetAllQuestions();


        Random random = new Random(0,randomQuestion.Count); 
        
        for(int i = 0; i < randomQuestion.Count; i++)
        {
            if(random == randomQuestion[i].QuestionId)
            {
                return randomQuestion[i];
            }
        }
        return null;
    }

    public bool IsCorrect(string answer)
    {
        List<Question> questions = _questionRepository.GetAllQuestions();

        for(int i = 0;i < questions.Count; i++)
        {
            if (questions[i].Answer == answer)
            {
                return true;
            }
        }
        return false;
    }

    public (bool,string) SolveQuestion(Question questionId, Question answer)
    {
        List<Question> questions = _questionRepository.GetAllQuestions();

        for(int i = 0;i < questions.Count;i++)
        {
            if (questions[i].QuestionId == questionId.QuestionId 
                && _questionService.IsCorrect(answer.Answer) )
            {
                return (true, $"{answer} is correct");
            }
            
        }
        return (false, $"{answer} is incorrect");
    }

   
}

    