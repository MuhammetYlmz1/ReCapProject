using Business.Abstract;
using Core.Utilities;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserServices
    {
        IUserDal _userDal;
        public UserManager(IUserDal _user)
        {
            _userDal = _user;
        }
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult("Kullanıcı Eklendi");
        }

        public IResult Delete(User user)
        {
           _userDal.Delete(user);
            return new SuccessResult("Kullanıcı Silindi");
        }

        public IDataResult<List<User>> GetAll()
        {
           return new SuccessDataResult<List<User>>( _userDal.GetAll());
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult("Kullanıcı Güncelledi");
        }
    }
}
