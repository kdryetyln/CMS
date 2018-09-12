using CMS.Common.Models.Layout;
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
    public class LayoutService : BaseService, ILayoutService
    {
        CMS.Core.Context.CMSDbContext CMSDb = new Context.CMSDbContext();
        public void NewLayout(string Name, Array List)
        {
            using (BaseRepository<PageLayout> _repoPL = new BaseRepository<PageLayout>())
            {
                PageLayout pl = new PageLayout();
                var lay = _repoPL.Query<PageLayout>().Where(k => k.Name == Name).Any();

                if(Name=="")
                {
                    pl.Name = "No Name";
                    
                }
                else
                {
                    if(lay)
                    {
                        pl.Name = Name + "_1";
                    }
                    else
                    {
                        pl.Name = Name;
                    }                    
                }
                
                _repoPL.Add(pl);
                using (BaseRepository<PLItem> _repoPLI = new BaseRepository<PLItem>())
                {
                    int i = 1;
                    foreach (var item in List)
                    {

                        PLItem pLItem = new PLItem()
                        {
                            PageLayoutId = pl.Id,
                            SizeValue = item.ToString(),
                            Order = i
                        };
                        i++;
                        _repoPLI.Add(pLItem);
                    }
                }
            }
        }

        public IEnumerable<LayoutDto> List()
        {
            using (BaseRepository<PageLayout> _repoPL = new BaseRepository<PageLayout>())
            {
                var pL = _repoPL.Query<PageLayout>().ToList();

                List<LayoutDto> listDto = new List<LayoutDto>();
                foreach (var item in pL)
                {
                    LayoutDto dto = new LayoutDto()
                    {
                        Id=item.Id,
                        Name = item.Name,
                        PLItems = _repoPL.Query<PLItem>().Where(k => k.PageLayoutId == item.Id).ToList()
                    };
                    listDto.Add(dto);
                }

                return listDto;
            }
        }

        public LayoutDto GetLayouts(int id)
        {
            using (BaseRepository<PageLayout> _repoPL = new BaseRepository<PageLayout>())
            {
                var pL = _repoPL.Query<PageLayout>().Where(k => k.Id == id).FirstOrDefault();


                    LayoutDto dto = new LayoutDto()
                    {
                        Id = pL.Id,
                        Name = pL.Name,
                        PLItems = _repoPL.Query<PLItem>().Where(k => k.PageLayoutId == id).ToList()
                    };

                return dto;
            }
        }

        public void UpdateLayout(int id, Array List, Array Order)
        {
            using (BaseRepository<PageLayout> _repoPL = new BaseRepository<PageLayout>())
            {
                var pL = _repoPL.Query<PLItem>().Where(k => k.PageLayoutId == id).ToList();
                int i = 0;
                foreach (var item in pL)
                {
                    item.SizeValue = List.GetValue(i).ToString();
                    item.Order = Convert.ToInt32(Order.GetValue(i));

                    using (BaseRepository<PLItem> _repo = new BaseRepository<PLItem>())
                    {
                        _repo.Update(item);
                    }                     

                    i++;
                }
            }

        }
    }
}
