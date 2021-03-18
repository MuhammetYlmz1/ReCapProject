using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
   public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);

    }//Kullanıcı adı şifresini girdikten sonra veritabanına gidecek veritabanından ilgili kişinin claimlerini bulacak
    //Orada bir tane jwt(Json Web Token) üretecek onları alıp tekrar ana ekrana gönderecek 
}
