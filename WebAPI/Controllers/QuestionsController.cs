using Business.Abstract;
using Business.DTOs.Questions;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        IQuestionService _questionService;

        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost("add")]

        public async Task<IActionResult> Add([FromBody] CreateQuestionRequest createQuestionRequest)
        {

            var result = await _questionService.Add(createQuestionRequest);

            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateQuestionRequest updateQuestionRequest)
        {

            var result = await _questionService.Update(updateQuestionRequest);

            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteQuestionRequest deleteQuestionRequest)
        {

            var result = await _questionService.Delete(deleteQuestionRequest);

            return Ok(result);
        }

        [HttpGet("getList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _questionService.GetListAsync(pageRequest);
            return Ok(result);
        }
    }
}
