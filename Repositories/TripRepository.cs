using Microsoft.EntityFrameworkCore;
using ProjectTourism.ClassDTO;
using ProjectTourism.Data;
using ProjectTourism.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTourism.Repositories
{
    public class TripRepository
    {
        //private readonly AppContext context;

        //public TripRepository (AppContext context)
        //{
        //    this.context = context;
        //}

        public static IEnumerable<TripDTO> GetAllTrips()
        {
            var context = new AppDbContext();
            
                var Trips = context.Trips.
                            Select(Trip => new TripDTO{
                                TripId = Trip.TripId,
                                Title  = Trip.Title,
                                Description = Trip.Description,
                                StartDate = Trip.StartDate,
                                EndDate = Trip.EndDate,
                                Price = Trip.Price,
                            }).ToList();
            
                return Trips;
    }
    public static List<TripDTO> FindTripByID(int Id)
        {
            var context = new AppDbContext();

            var Trip = context.Trips.Where(Trip => Trip.TripId == Id).
                Select(Trip => new TripDTO
                {
                    TripId = Trip.TripId,
                    Title = Trip.Title,
                    Description = Trip.Description,
                    StartDate = Trip.StartDate,
                    EndDate = Trip.EndDate,
                    Price = Trip.Price,
                }).ToList();

            return Trip;
        }

       

        public static bool AddNewTrip(Trip NewTrip)
        {
            var context = new AppDbContext();

            bool IsAdded = false;

            context.Trips.Add(NewTrip);

            try
            {
                if (context.SaveChanges() == 1)
                    IsAdded = true;
            }
            catch (Exception e)
            {
                IsAdded = false;
            }

            return IsAdded;
        }
        public static bool UpdateTrip(Trip Trip)
        {
            var context = new AppDbContext();

            bool IsUpdate = false; 

            context.Trips.Update(Trip);

                try
                {
                    if (context.SaveChanges() == 1)
                        IsUpdate = true;
                }
                catch (Exception e)
                {
                    IsUpdate = false;
                }
            
            return IsUpdate;
        }
        public static bool DeleteTrip(int ID)
        {
            var context = new AppDbContext();

            var Trip = context.Trips.Find(ID);

            bool IsDeleted = false;


            try
            {
                if (Trip != null)
                {
                    context.Trips.Remove(Trip);
                    context.SaveChanges();
                    IsDeleted = true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                IsDeleted = false;
            }

            return IsDeleted;
        }

    }
}
