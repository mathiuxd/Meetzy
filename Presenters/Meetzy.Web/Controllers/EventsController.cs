using Meetzy.Application.UseCases.Events.Commands.CreateEvent;
using Meetzy.Application.UseCases.Events.Commands.DeleteEvent;
using Meetzy.Application.UseCases.Events.Commands.UpdateEvent;
using Meetzy.Application.UseCases.Events.Queries.GetAllEvents;
using Meetzy.Application.UseCases.Events.Queries.GetEventById;
using Meetzy.Application.Utilities.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Meetzy.Web.Controllers
{
    public class EventsController : Controller
    {
        private readonly IMediator _mediator;

        public EventsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var events = await _mediator.Send(new GetAllEventsRequest());
            return View(events);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateEventRequest request)
        {
            if (!ModelState.IsValid) return View(request);
            await _mediator.Send(request);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var ev = await _mediator.Send(new GetEventByIdRequest(id));
            var request = new UpdateEventRequest(ev.EventId, ev.Title, ev.Description, ev.DateTime, ev.MaxAttendees);
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateEventRequest request)
        {
            if (!ModelState.IsValid) return View(request);
            await _mediator.Send(request);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteEventRequest(id));
            return RedirectToAction("Index");
        }
    }
}