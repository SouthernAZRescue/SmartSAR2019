using System;
using System.Threading.Tasks;
using SSar.Presentation.BlazorSpaUI.Exceptions;
using SSar.Presentation.BlazorSpaUI.Services;
using SSar.Presentation.BlazorSpaUI.Shared;

namespace SSar.Presentation.BlazorSpaUI.Utilities
{
    public static class ApiTools
    {
        public static async Task WrapApiCallWithValidationModalAsync(
            Func<Task> function, ModalService modalService)
        {
            try
            {
                await function.Invoke();
            }
            catch (ServerValidationException ex)
            {
                modalService.Show(
                    "Please fix the following issues:", typeof(ErrorMessageDictionary), ex.ErrorDictionary);

                throw;
            }
        }

        public static async Task<T> WrapApiCallWithValidationModalAsync<T>(
            Func<Task<T>> function, ModalService modalService)
        {
            T result;

            try
            {
                result = await function.Invoke();
            }
            catch (ServerValidationException ex)
            {
                modalService.Show(
                    "Please fix the following issues:", typeof(ErrorMessageDictionary), ex.ErrorDictionary);

                throw;
            }

            return result;
        }
    }
}
