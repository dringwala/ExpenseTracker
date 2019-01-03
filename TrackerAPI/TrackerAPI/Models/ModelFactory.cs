using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackerDB;
using TrackerDB.Entities;

namespace TrackerAPI.Models
{
    public class ModelFactory
    {
        ITrackerRepository _repo;
        UrlHelper _urlHelper;
        public ModelFactory(ActionContext context, ITrackerRepository repo)
        {
            _repo = repo;
            _urlHelper = new UrlHelper(context);
            
        }

        public BankModel Create(Bank bank)
        {
            return new BankModel
            {
                Links = new List<LinkModel> {
                    CreateLink(_urlHelper.Link("GetBank", new{ id = bank.Id }), "self")
                },
                BankUrl = bank.BankUrl,
                IsActive = bank.IsActive,
                Name = bank.Name
            };
        }

        public Bank Parse(BankModel bankModel)
        {
            try
            {
                var bank = new Bank();
                var selfLink = bankModel.Links.Where(l => l.Rel == "self").FirstOrDefault();
                if (selfLink != null && !string.IsNullOrWhiteSpace(selfLink.Href))
                {
                    var uri = new Uri(selfLink.Href);
                    bank.Id = int.Parse(uri.Segments.Last());
                }

                
                bank.IsActive = bankModel.IsActive;
                bank.Name = bankModel.Name;

                return bank;
            }
            catch
            {
                return null;
            }
        }

        public LinkModel CreateLink(string href, string rel, string method = "GET", bool isTemplated = false)
        {
            return new LinkModel()
            {
                Href = href,
                Rel = rel,
                Method = method,
                IsTemplated = isTemplated
            };
        }

    }
}
