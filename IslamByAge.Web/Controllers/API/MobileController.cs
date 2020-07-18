using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using IslamByAge.Core.Domain;
using IslamByAge.Core.Enums;
using IslamByAge.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IslamByAge.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileController : ControllerBase
    {
        private readonly IRepository<Topic> topicRepo;
        private readonly IRepository<Category> categoryRepo;

        public MobileController(IRepository<Topic> topicRepo,IRepository<Category> categoryRepo)
        {
            this.topicRepo = topicRepo;
            this.categoryRepo = categoryRepo;
        }
        // GET: api/<MobileController>
        [HttpGet]
        public JsonResult Get()
        {
            var categories = from category in categoryRepo.All()
                             where category.Status==Status.Approved
                             select new
                             {
                                 id=category.Id,
                                 title=category.Title,
                                 image=category.Image,
                             };
            var topics = from topic in topicRepo.All()
                         join category in categoryRepo.All() on topic.CategoryId equals category.Id
                         where topic.Status == Status.Approved && category.Status==Status.Approved
                         select new
                         {
                             categoryid=topic.CategoryId,
                             title=topic.Title,
                             id=topic.Id,
                             desc=topic.Description,
                         };
            var result = new
            {
                Categories=categories,
                Topics=topics
            };
            return new JsonResult(result);
        }
    }
}
