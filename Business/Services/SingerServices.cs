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
    public class SingerServices : ISingerService
    {
        private readonly SingerRepositoryBase _singerRepository;

        public SingerServices(SingerRepositoryBase singerRepository)
        {
            _singerRepository = singerRepository;
        }
        public Result Add(SingerModel model)
        {
            try
            {
                if (_singerRepository.EntityQuery().Any(s => s.Name.ToLower() == model.Name.ToLower().Trim() && s.SurName.ToLower() == model.SurName.ToLower().Trim()))
                    return new ErrorResult("Singer with the same name exsits");
                Singer entity = new Singer()
                {
                    Name = model.Name.Trim(),
                    SurName = model.SurName?.Trim()
                };
                if (!string.IsNullOrWhiteSpace(model.BirthDateText))
                {
                    entity.BirthDate = DateTime.Parse(model.BirthDateText, new CultureInfo("en"));
                }
                _singerRepository.Add(entity);
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
                _singerRepository.Delete(id);
                return new SuccessResult();

            }
            catch (Exception exc)
            {

                return new ExceptionResult(exc);
            }
        
        }

        public void Dispose()
        {
            _singerRepository.Dispose();
        }

        public IQueryable<SingerModel> Query()
        {
            try
            {
                return _singerRepository.EntityQuery("Albums").OrderBy(s => s.Name).Select(s => new SingerModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    SurName = s.SurName,
                    BirthDate = s.BirthDate,
                    Guid = s.Guid,
                    BirthDateText = s.BirthDate != null ? s.BirthDate.Value.ToString("yyyy-MM-dd", new CultureInfo("en")) : "",
                    AlbumCount = s.Albums.Count

                });
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public Result Update(SingerModel model)
        {
            try
            {

                if (_singerRepository.EntityQuery().Any(s => s.SurName.ToLower() == model.SurName.ToLower().Trim() && s.Id != model.Id))
                    return new ErrorResult("Singer with the same surname exist");


               var entity = _singerRepository.Query().SingleOrDefault(c => c.Id == model.Id);
                entity.SurName = model.SurName.Trim();
                entity.Name = model.Name.Trim();
                entity.BirthDate = null;

                if (!string.IsNullOrWhiteSpace(model.BirthDateText))
                {
                    entity.BirthDate = DateTime.Parse(model.BirthDateText, new CultureInfo("en"));
                }

                _singerRepository.Update(entity);
                return new SuccessResult();
            }
            catch (Exception exc)
            {

                return new ExceptionResult(exc);
            }
        }
    }
}
