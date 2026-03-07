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
        return _questionRepository.AddQuestion(question);
    }



}



[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService AuthService;
    public AuthController()
    {
        AuthService = new AuthService();
    }

    [HttpPost("register")]
    public Guid Register(UserRegisterDto userRegisterDto)
    {
        return AuthService.RegisterUser(userRegisterDto);
    }

    [HttpPost("login")]
    public string Login(UserLoginDto userLoginDto)
    {
        return AuthService.LoginUser(userLoginDto);
    }
}

