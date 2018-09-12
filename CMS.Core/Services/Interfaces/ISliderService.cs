using CMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Services.Interfaces
{
    public interface ISliderService : IService
    {
        void Create(string ImageUrl, string Title, bool IsActive);
        List<Slider> ImageList();
        void Activate(int id);
        void DeleteImage(int id);
        List<Slider> ActiveImage();
    }
}
