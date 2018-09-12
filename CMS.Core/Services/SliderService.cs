using CMS.Core.Repository;
using CMS.Core.Services.Interfaces;
using CMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Services
{
    public class SliderService : BaseService, ISliderService
    {
        public void Create(string ImageUrl, string Title, bool IsActive)
        {
            using (BaseRepository<Slider> _repo = new BaseRepository<Slider>())
            {
                Slider slider = new Slider()
                {
                    ImageUrl = ImageUrl,
                    Title = Title,
                    IsActive = IsActive,
                    CreateTime = DateTime.Now,
                };
                _repo.Add(slider);
            }
        }
        public List<Slider> ImageList()
        {
            using (BaseRepository<Slider> _repo = new BaseRepository<Slider>())
            {
                var list = _repo.Query<Slider>().ToList();
                return list;
            }
        }
        public void Activate(int id)
        {
            using (BaseRepository<Slider> _repo = new BaseRepository<Slider>())
            {
                var model = _repo.Query<Slider>().Where(p => p.Id == id).First();
                if (model.IsActive == true)
                {
                    model.IsActive = false;

                }
                else
                {
                    model.IsActive = true;

                }
                _repo.Update(model);
            }
        }
        public void DeleteImage(int id)
        {
            using (BaseRepository<Slider> _repo = new BaseRepository<Slider>())
            {
                var model = _repo.Query<Slider>().Where(p => p.Id == id).First();
                _repo.Delete(model);
            }
        }

        public List<Slider> ActiveImage()
        {
            using (BaseRepository<Slider> _repo = new BaseRepository<Slider>())
            {
                var list = _repo.Query<Slider>().Where(p => p.IsActive == true).ToList();
                return list;
            }
        }

    }
}
