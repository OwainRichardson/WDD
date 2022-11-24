using Microsoft.AspNetCore.Mvc;
using WDD.Models.DataModels;
using WDD.Models.InputModels;
using WDD.Models.ViewModels;
using WDD.Services.Interfaces;

namespace WDD.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhoneBookController : ControllerBase
    {
        private readonly IPhoneBookService _phoneBookService;

        public PhoneBookController(IPhoneBookService phoneBookService)
        {
            _phoneBookService = phoneBookService;
        }

        [HttpGet]
        [Route("GetEntries")]
        public GetEntriesViewModel GetEntries()
        {
            List<PhoneBookEntry> entries = _phoneBookService.GetEntries();

            return new GetEntriesViewModel
            {
                PhoneBookEntries = entries
            };
        }

        [HttpPost]
        [Route("CreateEntry")]
        public CreateEntryViewModel CreateEntry([FromBody] CreateEntryInputModel model)
        {
            PhoneBookEntry newEntry = _phoneBookService.CreateEntry(model.FirstName, model.LastName, model.PhoneNumber);

            return new CreateEntryViewModel
            {
                Id = newEntry.Id,
                FirstName = newEntry.FirstName,
                LastName = newEntry.LastName,
                PhoneNumber = newEntry.PhoneNumber,
                FullName = newEntry.FullName
            };
        }

        [HttpPut]
        [Route("UpdateEntry")]
        public UpdateEntryViewModel UpdateEntry([FromBody] UpdateEntryInputModel model)
        {
            PhoneBookEntry updatedEntry = _phoneBookService.UpdateEntry(model.Id, model.FirstName, model.LastName, model.PhoneNumber);

            return new UpdateEntryViewModel
            {
                Id = updatedEntry.Id,
                FirstName = updatedEntry.FirstName,
                LastName = updatedEntry.LastName,
                PhoneNumber = updatedEntry.PhoneNumber,
                FullName = updatedEntry.FullName
            };
        }

        [HttpDelete]
        [Route("DeleteEntry")]
        public DeleteEntryViewModel DeleteEntry([FromQuery] int entryId)
        {
            try
            {
                _phoneBookService.DeleteEntry(entryId);

                return new DeleteEntryViewModel
                {
                    Success = true
                };
            }
            catch
            {
                return new DeleteEntryViewModel
                {
                    Success = false
                };
            }

        }
    }
}
