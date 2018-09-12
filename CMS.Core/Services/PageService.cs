using CMS.Common.Models.Page;
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
    public class PageService : BaseService, IPageService
    {

        public void CreatePage(string namepage, int id, Array text, Array order)
        {
            using (BaseRepository<Page> _repoP = new BaseRepository<Page>())
            {
                Page page = new Page()
                {
                    PageLayoutId = id,
                    Slug = "slug" + namepage,
                };
                var res = _repoP.Query<Page>().Where(k => k.Name == namepage).Any();

                if (namepage == "")
                {
                    page.Name = "No Name";

                }
                else
                {
                    if (res)
                    {
                        page.Name = namepage + "_1";
                    }
                    else
                    {
                        page.Name = namepage;
                        page.PublishDate = DateTime.Now;
                    }
                }
                _repoP.Add(page);
                _repoP.Update(page);

                //Add Content
                using (BaseRepository<PageContent> _repo = new BaseRepository<PageContent>())
                {
                    var pages = _repo.Query<Page>().Where(k => k.Id == page.Id ).FirstOrDefault();
                    int i = 1;
                    foreach (var item in text)
                    {

                        PageContent pageContent = new PageContent()
                        {
                            PageId = pages.Id,
                            Content = item.ToString(),
                            divId = i
                        };
                        _repo.Add(pageContent);
                        i++;
                    }

                }
            }
        }

        public List<PageLayout> GetLayouts()
        {
            using (BaseRepository<PageLayout> _repo = new BaseRepository<PageLayout>())
            {
                return _repo.Query<PageLayout>().ToList();
            }
        }

        public List<PageDto> GetPage()
        {
            using (BaseRepository<Page> _repo = new BaseRepository<Page>())
            {
                List<PageDto> pageDtos = new List<PageDto>();
                var pageList = _repo.Query<Page>().Where(k=>k.IsDeleted==false).ToList();
                foreach (var item in pageList)
                {

                    PageDto dto = new PageDto()
                    {
                        PageName = item.Name,
                        LayoutName = _repo.Query<PageLayout>().Where(k => k.Id == item.PageLayoutId).FirstOrDefault().Name,
                        LayoutId = item.PageLayoutId,
                        PageId = item.Id,
                        IsPublish=item.IsPublish
                    };
                    pageDtos.Add(dto);
                }

                return pageDtos;
            }
        }

        public List<PLItem> GetPLItems(int id)
        {
            using (BaseRepository<PLItem> _repo = new BaseRepository<PLItem>())
            {
                return _repo.Query<PLItem>().Where(k => k.PageLayoutId == id).ToList();
            }
        }

        public void AddContents(int id, Array text, Array order)
        {
            using (BaseRepository<PageContent> _repo = new BaseRepository<PageContent>())
            {
                int i = 1;
                var contList = _repo.Query<PageContent>().Where(k => k.PageId == id).ToList();
                foreach (var item in text)
                {
                    if (contList == null)
                    {
                        PageContent pageContent = new PageContent()
                        {
                            PageId = id,
                            Content = item.ToString(),
                            divId = i
                        };
                        _repo.Add(pageContent);
                    }
                    else
                    {
                        var div = Convert.ToInt32(order.GetValue(i - 1));
                        var cont = contList.Where(k => k.PageId == id && k.divId == div).FirstOrDefault();
                        cont.Content = item.ToString();
                        cont.divId = div;
                        _repo.Update(cont);
                    }
                    i++;
                }

            }
        }

        public List<ContentDto> GetContent(int id)
        {
            using (BaseRepository<PageContent> _repo = new BaseRepository<PageContent>())
            {
                var page = _repo.Query<Page>().Where(p => p.Id == id).First();
                var PLitem = _repo.Query<PLItem>().Where(p => p.PageLayoutId == page.PageLayoutId);
                var contList = _repo.Query<PageContent>().Where(p => p.PageId == page.Id).ToList();
                List<ContentDto> contDto = new List<ContentDto>();
                foreach (var item in contList)
                {
                    ContentDto dto = new ContentDto()
                    {
                        Content = item.Content,
                        DivId = item.divId,
                        PageID = page.Id,
                        Size = PLitem.Where(k => k.Order == item.divId).FirstOrDefault().SizeValue,
                        PageName = page.Name
                    };
                    contDto.Add(dto);
                }

                return contDto;
            }
        }

        public void DeletePage(int id)
        {
            using (BaseRepository<Page> _repo = new BaseRepository<Page>())
            {
                var page = _repo.Query<Page>().FirstOrDefault(k => k.Id == id);
               
                using (BaseRepository<PageContent> _repoCon = new BaseRepository<PageContent>())
                {
                    var contList = _repoCon.Query<PageContent>().Where(k => k.PageId == page.Id).ToList();
                    foreach (var item in contList)
                    {
                        _repoCon.Delete(item);
                    }
                }
                _repo.Delete(page);
            }
        }
        public void PublishPage(int id)
        {
            using (BaseRepository<Page> _repo = new BaseRepository<Page>())
            {
                var page = _repo.Query<Page>().FirstOrDefault(k => k.Id == id);
                if (page.IsPublish ==true)
                {
                    page.IsPublish = false;                    
                }
                else
                {
                    page.IsPublish = true;
                    page.PublishDate = DateTime.Now;
                }
                _repo.Update(page);
            }
        }
        public List<ContentDto> GetPageContent(int id)//for UI
        {
            using (BaseRepository<PageContent> _repo = new BaseRepository<PageContent>())
            {
                var page = _repo.Query<Page>().Where(p => p.Id == id).First();
                var PLitem = _repo.Query<PLItem>().Where(p => p.PageLayoutId == page.PageLayoutId);
                var contList = _repo.Query<PageContent>().Where(p => p.PageId == page.Id).ToList();
                List<ContentDto> contDto = new List<ContentDto>();
                foreach (var item in contList)
                {
                    if (page.IsPublish == false)
                    {
                        ContentDto dto = new ContentDto()
                        {
                            Content = "preparing..",
                            DivId = item.divId,
                            PageID = page.Id,
                            Size = PLitem.Where(k => k.Order == item.divId).FirstOrDefault().SizeValue,
                            PageName = page.Name
                        };
                        contDto.Add(dto);
                        break;
                    }
                    else
                    {
                        ContentDto dto = new ContentDto()
                        {
                            Content = item.Content,
                            DivId = item.divId,
                            PageID = page.Id,
                            Size = PLitem.Where(k => k.Order == item.divId).FirstOrDefault().SizeValue,
                            PageName = page.Name
                        };
                        contDto.Add(dto);
                    }

                }
                return contDto;
            }
        }
        
    }
}
