using Microsoft.AspNetCore.Mvc;
using ReviewMicroservice.Models;
using ReviewMicroservice.Services;
using System.Threading.Tasks;

namespace ReviewMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly ReviewService _reviewService;

        public ReviewController(ReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] Review review)
        {
            if (review == null)
            {
                return BadRequest("Ви повинні залишити відгук");
            }

            await _reviewService.AddReview(review);
            return CreatedAtAction(nameof(GetReviews), new { id = review.Id }, review);
        }

        [HttpGet]
        public async Task<IActionResult> GetReviews(int pageNumber = 1, int pageSize = 10)
        {
            var reviews = await _reviewService.GetReviews(pageNumber, pageSize);
            return Ok(reviews);
        }

        [HttpGet("count")]
        public async Task<IActionResult> GetReviewCount()
        {
            var count = await _reviewService.GetReviewCount();
            return Ok(count);
        }
    }
}
