using CMS.Common.Models.Menu;
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
    public class MenuService : BaseService, IMenuService
    {

        public List<Page> GetPage()
        {
            using (BaseRepository<Page> _repo = new BaseRepository<Page>())
            {
                var menuList = _repo.Query<Menu>().Where(k=>k.IsDeleted==false).ToList();
                var pages = _repo.Query<Page>().Where(p=>p.IsDeleted == false).ToList();
                foreach (var item in menuList)
                {
                    var page = _repo.Query<Page>().Where(k => k.Id == item.PageId).FirstOrDefault();
                    pages.Remove(page);
                }
                return pages;
            }
        }

        public void CreateMenu(int id)
        {
            using (BaseRepository<Menu> _repo = new BaseRepository<Menu>())
            {
                var page = _repo.Query<Page>().FirstOrDefault(k => k.Id == id&&k.IsDeleted == false);
                var result = _repo.Query<Menu>().Where(k => k.PageId == id);
                if (result.Any())
                {
                    if (result.FirstOrDefault().MenuId != null)
                    {
                        result.FirstOrDefault().MenuId = null;
                    }
                    _repo.Update(result.FirstOrDefault());
                }
                else
                {
                    Menu menu = new Menu()
                    {
                        PageId = page.Id,
                        Menus = null
                    };
                    _repo.Add(menu);
                }
                
            }
        }
        public List<MenuDto> GetMenu()
        {
            using (BaseRepository<Page> _repo = new BaseRepository<Page>())
            {
                var menuList = _repo.Query<Menu>().Where(k=>k.IsDeleted==false).ToList();
                var pages = _repo.Query<Page>().Where(p => p.IsDeleted == false).ToList();
                List<MenuDto> menuDtos = new List<MenuDto>();                
                foreach (var item in menuList)
                {
                    var page = _repo.Query<Page>().Where(k => k.Id == item.PageId).FirstOrDefault();
                    MenuDto dto = new MenuDto();
                    dto.MenuId = item.Id;
                    dto.ParentID = item.MenuId;
                    dto.MenuName = page.Name;
                    dto.PageId = page.Id;
                    menuDtos.Add(dto);
                }
                return menuDtos;
            }
        }

        public void CreateSubMenu(int menuid, int subid)
        {
            using (BaseRepository<Menu> _repo = new BaseRepository<Menu>())
            {
                var menu = _repo.Query<Menu>().Where(k => k.Id == menuid).FirstOrDefault();
                var result = _repo.Query<Menu>().Where(k => k.PageId == subid);
                if(result.Any())
                {                    
                    if(result.FirstOrDefault().MenuId == null)
                    {
                        result.FirstOrDefault().MenuId = menuid;
                    }
                    else
                    {
                        result.FirstOrDefault().MenuId = menuid;
                    }
                    _repo.Update(result.FirstOrDefault());
                }
                else
                {
                    Menu newmenu = new Menu()
                    {
                        PageId = subid,
                        Page = _repo.Query<Page>().Where(k => k.Id == subid).FirstOrDefault(),
                        MenuId = menu.Id,
                        Menus = menu
                    };
                    _repo.Add(newmenu);
                }
                
            }
        }
        public List<MenuDto> GetSubItem(int id)
        {
            using (BaseRepository<Page> _repo = new BaseRepository<Page>())
            {
                var menuList = _repo.Query<Menu>().Where(k=>k.MenuId==id).ToList();
                var pages = _repo.Query<Page>().Where(p=>p.IsDeleted == false).ToList();
                var menu = _repo.Query<Menu>().Where(k => k.Id ==id).FirstOrDefault();
                MenuDto mdto = new MenuDto();
                mdto.MenuId = menu.Id;
                mdto.ParentID = menu.MenuId;
                mdto.MenuName = _repo.Query<Page>().Where(k => k.Id == menu.PageId).FirstOrDefault().Name;
                mdto.PageId = menu.PageId;             

                List<MenuDto> menuDtos = new List<MenuDto>();
                menuDtos.Add(mdto);

                foreach (var item in menuList)
                {
                    var page = _repo.Query<Page>().Where(k => k.Id == item.PageId).FirstOrDefault();
                    MenuDto dto = new MenuDto();
                    dto.MenuId = item.Id;
                    dto.ParentID = item.MenuId;
                    dto.MenuName = page.Name;
                    dto.PageId = page.Id;
                    menuDtos.Add(dto);
                }
                return menuDtos;
            }
        }

        public string GetMenuRecursion()
        {
            using (BaseRepository<Menu> repo = new BaseRepository<Menu>())
            {
                var all = repo.Query<Menu>().Where(x => !x.IsDeleted).ToList();
                var strBuilder = new StringBuilder();
                var parentItems = all.Where(x => x.MenuId == null).ToList();
                strBuilder.Append("<header><nav id='cssmenu' style='width:1400px'><div id='head-mobile'></div><div class='button'></div><ul>");
                foreach (var parentcat in parentItems)
                {
                    var childItems = all.Where(x => x.MenuId == parentcat.Id);
                    if (childItems.Count() > 0)
                    {
                        var page = repo.Query<Page>().Where(k => k.Id == parentcat.PageId).FirstOrDefault();
                        strBuilder.Append("<li ><a href='/Home/Preview/" + parentcat.PageId + "'>" + page.Name + "</a>");
                        AddChildItem(parentcat, strBuilder);
                        strBuilder.Append("</li>");                      
                    }
                    else
                    {
                        var page = repo.Query<Page>().Where(k => k.Id == parentcat.PageId).FirstOrDefault();
                        strBuilder.Append("<li><a href='/Home/Preview/" + parentcat.PageId + "'>" + page.Name + "</a>" + "</li>");
                    }
                }
                strBuilder.Append("<li><a href='/Home/GetSlider/'>Slider</a>" + "</li>");
                strBuilder.Append("</ul></nav></header>");

                return strBuilder.ToString();
            }

        }

        public void AddChildItem(Menu childItem, StringBuilder strBuilder)
        {
            using (BaseRepository<Menu> repo = new BaseRepository<Menu>())
            {
                var all = repo.Query<Menu>().Where(x => !x.IsDeleted).ToList();
                strBuilder.Append("<ul>");
                var childItems = all.Where(x => x.MenuId == childItem.Id);
                foreach (Menu cItem in childItems)
                {
                    var subChilds = all.Where(x => x.MenuId == cItem.Id);
                    if (subChilds.Count() > 0)
                    {
                        var page = repo.Query<Page>().Where(k => k.Id == cItem.PageId).FirstOrDefault();
                        strBuilder.Append("<li><a href='/Home/Preview/" + cItem.PageId + "'>" + page.Name + "</a>");
                        AddChildItem(cItem, strBuilder);
                        strBuilder.Append("</li>");
                    }
                    else
                    {
                        var page = repo.Query<Page>().Where(k => k.Id == cItem.PageId).FirstOrDefault();
                        strBuilder.Append("<li><a href='/Home/Preview/" + cItem.PageId + "'>" + page.Name + "</a></li>");
                    }
                }
                strBuilder.Append("</ul>");
            }
        }

        public void RemoveMenu(int id)
        {
            using (BaseRepository<Menu> _repo = new BaseRepository<Menu>())
            {
                var menu = _repo.Query<Menu>().FirstOrDefault(k => k.Id == id);
                var childmenu = _repo.Query<Menu>().Where(k => k.MenuId == id).ToList();
                foreach (var item in childmenu)
                {
                    _repo.Delete(item);
                    RemoveChild(item);
                }
                _repo.Delete(menu);
            }
        }

        public void RemoveChild(Menu menu)
        {
            using (BaseRepository<Menu> _repo = new BaseRepository<Menu>())
            {
                var childmenu = _repo.Query<Menu>().Where(k => k.MenuId == menu.Id).ToList();
                foreach (var item in childmenu)
                {
                    _repo.Delete(item);
                    RemoveChild(item);                    
                }
            }
                
        }

    }
}
