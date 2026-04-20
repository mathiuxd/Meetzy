using Meetzy.Application.UseCases.Communities.Commands.CreateCommunity;
using Meetzy.Application.UseCases.Communities.Commands.DeleteCommunity;
using Meetzy.Application.UseCases.Communities.Commands.UpdateCommunity;
using Meetzy.Application.UseCases.Communities.Queries.GetAllCommunities;
using Meetzy.Application.UseCases.Communities.Queries.GetCommunityById;
using Meetzy.Application.Utilities.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Meetzy.Web.Controllers
{
    public class CommunitiesController : Controller
    {
        private readonly IMediator _mediator;

        public CommunitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var communities = await _mediator.Send(new GetAllCommunitiesRequest());
            return View(communities);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var community = await _mediator.Send(new GetCommunityByIdRequest(id));
            return View(community);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string name, string? description, int type)
        {
            var createdBy = Guid.Parse("F2A232F0-8812-443F-80F0-4B661ECFF161");

            var request = new CreateCommunityRequest(
                name,
                description,
                type,
                createdBy
            );

            var result = await _mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var community = await _mediator.Send(new GetCommunityByIdRequest(id));

            var request = new UpdateCommunityRequest(
                community.CommunityId,
                community.Name,
                community.Description
            );

            return View(request);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateCommunityRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var community = await _mediator.Send(new GetCommunityByIdRequest(id));
            return View(community);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _mediator.Send(new DeleteCommunityRequest(id));
            return RedirectToAction(nameof(Index));
        }
    }
}