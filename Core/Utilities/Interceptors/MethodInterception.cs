using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)//Buradaki Invocation aslında bizim çalıştımak istedğimiz metodumuz oluyor
        {//biz hangisini doldurursak(OnBefore, OnException...)o çalışacak
            //OnBefore u dolduracağız program çalıştığında 1 kere çalışacak ve bitecek
            var isSuccess = true;
            OnBefore(invocation);//OnBefore dersek metodun başında çalışır(En çok kullanılan)
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);//Hata verdikten sonra çalışır(En çok kullanılan )
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);//metod başarılı olursa bu çalışsın 
                }
            }
            OnAfter(invocation);//
        }
    }
}
