using NTDShop.Model.Models;
using NTDShop.Service;
using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NTDShop.Web.Infrastructure.Core
{
    public class ApiControllerBase : ApiController
    {
        private IErrorService _errorService;

        public ApiControllerBase(IErrorService errorService)
        {
            this._errorService = errorService;
        }

        protected HttpResponseMessage CreateHttpReponse(HttpRequestMessage requestMessage, Func<HttpResponseMessage> funtion)
        {
            HttpResponseMessage response = null;
            try
            {
                response = funtion.Invoke();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Trace.WriteLine(string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation error.", eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Trace.WriteLine(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                LogError(ex);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.InnerException.Message);
            }
            catch (DbUpdateException dbex)
            {
                LogError(dbex);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, dbex.InnerException.Message);
            }
            catch (Exception ex)
            {
                LogError(ex);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return response;
        }

        private void LogError(Exception ex)
        {
            try
            {
                Error error = new Error()
                {
                    Message = ex.Message,
                    CreateDate = DateTime.Now,
                    StackTrace = ex.StackTrace,
                };
                _errorService.Create(error);
                _errorService.Save();
            }
            catch
            {
            }
        }
    }
}