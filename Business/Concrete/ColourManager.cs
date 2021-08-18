using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColourManager : IColourService
    {
        IColourDal _colourDal;

        public ColourManager(IColourDal colourDal)
        {
            _colourDal = colourDal;
        }
        [ValidationAspect(typeof(ColourValidator))]
        public IResult Add(Colour colour)
        {
            _colourDal.Add(colour);
            return new SuccessResult("Boya eklenmiştir");
        }

        public IResult Delete(Colour colour)
        {
            _colourDal.Delete(colour);
            return new SuccessResult("Boya silinmiştir");

        }

        public IDataResult<List<Colour>> GetAll()
        {
            return new SuccessDataResult<List<Colour>> (_colourDal.GetAll());
        }

        public IDataResult<Colour> GetById(int colourId)
        {
           return new SuccessDataResult<Colour> (_colourDal.Get(c=>c.ColourId == colourId));
        }

        public IResult Update(Colour colour)
        {
            _colourDal.Update(colour);
            return new SuccessResult("Boya güncellenmiştir");
        }
    }
}
