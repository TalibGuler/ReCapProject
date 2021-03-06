using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helpers
{
    public interface IFileHelper
    {
        IResult Upload(IFormFile file, string path);
        void Delete(string filePath);
        IResult Update(IFormFile file, string original, string root);
    }
}
