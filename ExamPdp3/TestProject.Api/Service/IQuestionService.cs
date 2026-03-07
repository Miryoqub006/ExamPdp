using TestProject.Api.DTOS;
using TestProject.Api.Entites;

namespace TestProject.Api.Service;

public interface IQuestionService
{
    public bool IsCorrect( string answer);

    public (bool,string) SolveQuestion(Question questionId, Question answer);

    public GetQuestionDto GetRandomQuestion();

    public int GetCountOfQuestions();

}
