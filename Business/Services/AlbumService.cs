using AppCore.Business.Models.Result;
using Business.Models;
using Business.Services.Bases;
using DataAccess.EntityFramework.Repositories;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Business.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly AlbumRepositoryBase _albumRepository;

        public AlbumService(AlbumRepositoryBase albumRepository)
        {
            _albumRepository = albumRepository;
        }
        public Result Add(AlbumModel model)
        {
            try
            {
                if (_albumRepository.EntityQuery().Any(a => a.Name.ToLower() == model.Name.ToLower().Trim()))
                {
                    return new ErrorResult("album with the same name exists");
                }
                //double unitPrice;
                //if (!double.TryParse(model.UnitePriceText.Trim().Replace(",", "."), NumberStyles.Any, new CultureInfo("en"),out unitPrice))
                //{
                //    return new ErrorResult("Unit price must be a number");
                //}
                var entity = new Album()
                {
                    Name = model.Name.Trim(),
                    Description = model.Description?.Trim(),
                    UnitePrice = Convert.ToDouble(model.UnitePriceText.Replace(",", "."), new CultureInfo("en")),
                    StockAmount = model.StockAmount,
                    SingerId = model.SingerId,
                    NumberofDiscs = model.NumberofDiscs
                };

                if (!string.IsNullOrWhiteSpace(model.YearText))
                {
                    entity.Year = DateTime.Parse(model.YearText, new CultureInfo("en"));
                }

                _albumRepository.Add(entity);

                return new SuccessResult();
            }
            catch (Exception exc)
            {

                return new ExceptionResult(exc);
            }
        }

        public Result Delete(int id)
        {
            try
            {
                _albumRepository.Delete(id);
                return new SuccessResult();
            }
            catch (Exception exc)
            {

                return new ExceptionResult(exc);
            }
        }

        public void Dispose()
        {
            _albumRepository.Dispose();
        }

        public IQueryable<AlbumModel> Query()
        {
            try
            {
                return _albumRepository.EntityQuery("Singer").OrderBy(a => a.Name).Select(a => new AlbumModel()
                {

                    Id = a.Id,
                    SingerId = a.SingerId,
                    Name = a.Name,
                    UnitePrice = a.UnitePrice,
                    Description = a.Description,
                    NumberofDiscs = a.NumberofDiscs,
                    Year = a.Year,
                    Guid = a.Guid,
                    StockAmount = a.StockAmount,
                    UnitePriceText = a.UnitePrice.ToString(new CultureInfo("en")),
                    YearText = a.Year != null ? a.Year.Value.ToString("yyy/MM/dd", new CultureInfo("en")) : "",

                    Singer = new SingerModel()
                    {
                        Name = a.Singer.Name,
                        SurName = a.Singer.SurName,
                        Id = a.Singer.Id,
                        Guid = a.Singer.Guid

                    }


                });
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public Result Update(AlbumModel model)
        {
            try
            {
                if (_albumRepository.EntityQuery().Any(a => a.Name.ToLower() == model.Name.ToLower().Trim() && a.Id != model.Id))
                    return new ErrorResult("Album with the same name exists");
                var entity = _albumRepository.EntityQuery().SingleOrDefault(a => a.Id == model.Id);

                entity.Name = model.Name.Trim();
                entity.Description = model.Description?.Trim();
                entity.UnitePrice = Convert.ToDouble(model.UnitePriceText.Replace(",", "."), new CultureInfo("en"));
                entity.StockAmount = model.StockAmount;
                entity.SingerId = model.SingerId;
                entity.NumberofDiscs = model.NumberofDiscs;
                entity.Year = null;
                if (string.IsNullOrWhiteSpace(model.YearText))

                entity.Year = DateTime.Parse(model.YearText, new CultureInfo("en"));

                _albumRepository.Update(entity);
                return new SuccessResult();
            }

            catch (Exception exc)
            {

                return new ExceptionResult(exc);
            }
        }
    }
}
