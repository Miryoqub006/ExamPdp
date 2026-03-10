using Microsoft.AspNetCore.Mvc;
using TestProject.Api.Entites;
using TestProject.Api.Repositories;
using TestProject.Api.Service;

namespace TestProject.Api.Controllers;
[ApiController]
[Route("question api")]
public class QuestionController : Controller
{
    private readonly IQuestionService _question;
    private readonly IQuestionRepository _questionRepository;
    
    public QuestionController()
    {
        _question = new QuestionService();
        _questionRepository = new QuestionsRepositories();
    }

    [HttpPost("get question")]
    public Question GetQuestion()
    {
        return _question.GetRandomQuestion();
    }
    [HttpPost("set question")]

    public void PostQuestion(Question question)
    {
         _questionRepository.AddQuestion(question);
    }



}







