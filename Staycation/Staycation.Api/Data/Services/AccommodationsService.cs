﻿using Staycation.Api.Data.Access;
using Staycation.Api.Data.Models;
using Staycation.Api.Data.ViewModels;

namespace Staycation.Api.Data.Services
{
    public class AccommodationsService
    {
        private AccommodationContext _context;
        
        public AccommodationsService(AccommodationContext context)
        {
            _context = context;
        }

        public Accommodation AddAccommodationWithLocation(AccommodationVM accommodationVM)
        {
            var _location = _context.Locations.
                Where(a => a.Name.ToLower() == accommodationVM.LocationName.ToLower()).Where(a => a.PostalCode == accommodationVM.PostalCode).SingleOrDefault();

            if (_location == null)
            {
                var newLocation = new Location()
                {
                    Name = accommodationVM.LocationName,
                    PostalCode = accommodationVM.PostalCode
                };
                _context.Locations.Add(newLocation);
                _context.SaveChanges();
            }

            int locationId = _context.Locations.Where(b => b.Name.ToLower() == accommodationVM.LocationName.ToLower())
    .Where(b => b.PostalCode == accommodationVM.PostalCode).SingleOrDefault().Id;

            var _accommodation = new Accommodation()
            {
                Title = accommodationVM.Title,
                Subtitle = accommodationVM.Subtitle,
                Description = accommodationVM.Description,
                Type = accommodationVM.Type,
                Categorization = accommodationVM.Categorization,
                PersonCount = accommodationVM.PersonCount,
                ImageTitle = accommodationVM.ImageUrl,
                FreeCancelation = accommodationVM.FreeCancelation,
                Price = accommodationVM.Price,
                LocationId = locationId,
            };
            _context.Accommodations.Add(_accommodation);
            _context.SaveChanges();

            return _accommodation;
        }

        public void AddImageForAccommodation(int id, IFormFile file)
        {
            var _accommodation = _context.Accommodations.FirstOrDefault(n => n.Id == id);
            if (_accommodation != null)
            {
                if (file != null)
                {
                    MemoryStream ms = new MemoryStream();
                    file.CopyTo(ms);
                    byte[] imageData = ms.ToArray();
                    ms.Close();
                    ms.Dispose();
                    _accommodation.ImageData=imageData;
                    _context.SaveChanges();
                }
            }
        }

        public List<Accommodation> GetAccommodations()
        {
            var allAccommodations = _context.Accommodations.ToList();
            return allAccommodations;
        }

        public Accommodation UpdateAccommodationById(int id, AccommodationVM accommodationVM)
        {
            var _accommodation = _context.Accommodations.FirstOrDefault(n => n.Id == id);
            if (_accommodation != null)
            {
                var locationId = _context.Locations.Where(a => a.PostalCode == accommodationVM.PostalCode).Where(a => a.Name == accommodationVM.LocationName).FirstOrDefault().Id;
                if (locationId == null) throw new Exception($"Location with postal code: {accommodationVM.PostalCode} and name: {accommodationVM.LocationName} does not exist!");
                else
                {
                    _accommodation.LocationId = locationId;
                    _accommodation.Title = accommodationVM.Title;
                    _accommodation.Subtitle = accommodationVM.Subtitle;
                    _accommodation.Description = accommodationVM.Description;
                    _accommodation.Type = accommodationVM.Type;
                    _accommodation.Categorization = accommodationVM.Categorization;
                    _accommodation.PersonCount = accommodationVM.PersonCount;
                    _accommodation.ImageTitle = accommodationVM.ImageUrl;
                    _accommodation.FreeCancelation = accommodationVM.FreeCancelation;
                    _accommodation.Price = accommodationVM.Price;
                    _context.SaveChanges();
                }
            }
            else
            {
                throw new Exception($"Accommodation with id: {id} does not exist!");
            }
            return _accommodation;
        }

        public void DeleteAccommodationById(int id)
        {
            var _accommodation = _context.Accommodations.FirstOrDefault(n => n.Id == id);
            if (_accommodation != null)
            {
                _context.Remove(_accommodation);
                _context.SaveChanges();
            }
        }

        public List<Accommodation> GetAccommodationRecommendations()
        {
            var accommodationRecommendation = _context.Accommodations.OrderByDescending(a => a.Id).Take(10).ToList();
            return accommodationRecommendation;
        }

        public List<Accommodation> GetAccommodationsOfALocation(int locationId)
        {
            var location = _context.Locations.Where(a => a.Id == locationId).FirstOrDefault();
            if(location==null) throw new Exception($"Location with id: {locationId} does not exist!");
            else
            {
                var accommodationsOfALocation = _context.Accommodations.Where(a => a.LocationId == locationId).ToList();
                return accommodationsOfALocation;
            }
        }
    }
}