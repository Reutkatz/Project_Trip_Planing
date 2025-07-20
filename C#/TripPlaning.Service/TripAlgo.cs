using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlaning.Core.Model;
using TripPlaning.Core.Service;

namespace TripPlaning.Service
{
    public class TripAlgo
    {
       
        private readonly IAttractionService attractionService;
        private readonly ITrailService trailService;
        private readonly IStopoverPlaceService stopoverPlaceService;

        public TripAlgo(IAttractionService attractionService,ITrailService trailService,IStopoverPlaceService stopoverPlaceService)
        {
            this.attractionService = attractionService;
            this.trailService = trailService;
            this.stopoverPlaceService = stopoverPlaceService;
        }
        private List<T> FilterAndSort<T>(List<T> list, IsraelRegion area, int budget, DateTime tripDate, TimeOnly startTime, TimeOnly endTime) where T : Place
        {
            return list
                .Where(a=> a.Region.Equals(area))
                .Where(a => a.ReviewsCount > 10) 
                .Where(a => a.Price <= budget)
                .OrderByDescending(a => a.Rating) 
                .ThenByDescending(a => a.ReviewsCount) 
                .ToList();
        }

        public List<Place> SelectBestCombination(Trip trip)
        {
            List<Attraction> attractions = FilterAndSort(attractionService.GetList(), trip.Region, trip.Budget,trip.Date,trip.StartTime,trip.EndTime);
            List<Trail> trails = FilterAndSort(trailService.GetList(), trip.Region, trip.Budget, trip.Date, trip.StartTime, trip.EndTime);
            List<StopoverPlace> stopoverPlaces = FilterAndSort(stopoverPlaceService.GetList(), trip.Region, trip.Budget, trip.Date, trip.StartTime, trip.EndTime);

            var allPlaces = new List<Place>();
            allPlaces.AddRange(attractions);
            allPlaces.AddRange(trails);
            allPlaces.AddRange(stopoverPlaces);

            
            allPlaces = allPlaces.OrderByDescending(a => a.Rating).ThenByDescending(a => a.ReviewsCount).ToList();

            var bestSelection = new List<Place>();
            bestSelection.AddRange(attractions.Take(trip.NumOfAttractions));
            bestSelection.AddRange(trails.Take(trip.NumOfTrails));
            bestSelection.AddRange(stopoverPlaces.Take(trip.NumOfStoppingPlaces));

            while (bestSelection.Sum(a => a.Price) > trip.Budget)
            {
                var toReplace = bestSelection
                    .OrderByDescending(a => PriceDropImpact(a, allPlaces))
                    .First();

                var replacement = FindCheaperAlternative(toReplace, attractions, trails, stopoverPlaces);
                if (replacement != null)
                {
                    bestSelection.Remove(toReplace);
                    bestSelection.Add(replacement);
                }
                else
                {
                    break;
                }
            }

            if (bestSelection.Sum(a => a.Price) > trip.Budget)
            {
                return new List<Place>();
            }

            return bestSelection;
        }


        private double PriceDropImpact(Place a, List<Place> allPlaces)
        {
            int index = allPlaces.IndexOf(a);
            if (index == -1 || index == allPlaces.Count - 1)
                return 0; 

            Place nextPlace = allPlaces[index + 1];

            double priceDifference = a.Price - nextPlace.Price;
            double reviewsDifference = a.ReviewsCount - nextPlace.ReviewsCount;

            return reviewsDifference == 0 ? priceDifference : priceDifference / reviewsDifference;
        }


        private Place FindCheaperAlternative(Place current,List<Attraction> attractions, List<Trail> trails, List<StopoverPlace> stopoverPlaces)
        {
            var category = attractions.Contains(current) ? attractions.Cast<Place>() :
                           trails.Contains(current) ? trails.Cast<Place>() :
                           stopoverPlaces.Cast<Place>();
            return category.FirstOrDefault(a => a.Price < current.Price && a.Rating >= current.Rating - 0.5);
        }
    }
}
