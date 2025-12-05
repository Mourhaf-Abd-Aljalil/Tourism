using Microsoft.AspNetCore.Mvc;
using ProjectTourism.ClassDTO;
using ProjectTourism.Data;
using ProjectTourism.Entities;
using ProjectTourism.Repositories;

namespace ProjectTourism.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TripConrtoller : Controller
    {

        private readonly TripDTO TripsDTO;
        private readonly Trip Trips;
        public TripConrtoller(Trip Trips , TripDTO TripsDTO)
        {
            this.Trips = Trips;
            this.TripsDTO = TripsDTO;
        }
        [HttpGet("GetAllTrips")]
            public ActionResult<IEnumerable<TripDTO>> GetAllTrips()
            {

            var Trips = TripRepository.GetAllTrips();
                using (var context = new AppDbContext())
            {

                if (Trips == null)
                    return BadRequest();
                else
                    return Ok(Trips);
            }
        }

        [HttpGet("FindTripBy{Id}")]
        public ActionResult<TripDTO> FindTripByID(int Id)
        {
            var Trip = TripRepository.FindTripByID(Id);

                if (Trip != null)
                    return Ok(Trip);
                else
                    return BadRequest();
        }
    

        [HttpPost("AddNewTrip")]
        public ActionResult<TripDTO> AddNewTrip( string Title, string Description, DateTime StartDate, DateTime EndDate, decimal Price)
        {

            Trip NewTrip = new Trip();

            NewTrip.Title = Title;
            NewTrip.Description = Description;
            NewTrip.StartDate = StartDate;
            NewTrip.EndDate = EndDate;
            NewTrip.Price = Price;

            if (TripRepository.AddNewTrip(NewTrip))
                return Ok($" YES,the Trip has been Added ");
                else
                return BadRequest(); 
        }

        [HttpPut("UpdateTrip")]
        public ActionResult<TripDTO> UpdateTrip(int Id, string Title, string Description, DateTime StartDate, DateTime EndDate, decimal Price)
        {

                Trip UpdateTrip = new Trip();
           
                UpdateTrip.TripId = Id;
                UpdateTrip.Title = Title;
                UpdateTrip.Description = Description;
                UpdateTrip.StartDate = StartDate;
                UpdateTrip.EndDate = EndDate;
                UpdateTrip.Price = Price;

            if (TripRepository.UpdateTrip(UpdateTrip))
                return Ok($" YES,the Trip has been Update {Id}");
            else
                return NotFound();
        }

        [HttpDelete("DeleteTrip{ID}")]
        public ActionResult DeleteTrip(int ID)
        {
            if (TripRepository.DeleteTrip(ID))
            {
                return Ok($"YES,The Trip Has been Deleted {ID}");
            }
            return BadRequest($"NO,The Trip Has not been Deleted {ID}");
        }
    }
}
