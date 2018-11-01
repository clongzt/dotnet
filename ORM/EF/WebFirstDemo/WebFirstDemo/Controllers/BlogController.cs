using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.UI;
using Newtonsoft.Json;
using WebFirstDemo.Models;

namespace WebFirstDemo.Controllers
{
    public class BlogController : ApiController
    {
        // GET api/blogs
        public string Get()
        {
            using (var db = new BloggingContext())
            {
                var query = from b in db.Blogs
                    orderby b.Name
                    select b;

                var result = new Results
                {
                    Code = 0,
                    info = query.ToList(),
                    msg = "success"

                };
                return JsonConvert.SerializeObject(result); ;
            }
        }


        // GET api/blogs/5
        public string Get(int id)
        {
            return "value" + id;
        }


        public string Get(string name)
        {
            return name + "kaka";
        }

        [Route("api/Address")]
        public string GetByAddress(string Address)
        {
            return Address + "kaddka";
        }

        [Route("api/users/update")]
        // POST api/values
        public string PostUpdate([FromBody]Blog blog)
        {
            using (var db = new BloggingContext())
            {
                try
                {
                    var query = from b in db.Blogs
                                where b.BlogId == blog.BlogId
                        select b;
                    var users = query.ToList();
                    if (users.Count > 0)
                    {
                        var memcard = users[0];
                        memcard.Name = blog.Name;
                        if (blog.Name != null)
                        {
                            memcard.Name = blog.Name;
                        }
                        //if (memCard.sex != null)
                        //{
                        //    memcard.sex = memCard.sex;
                        //}
                        //if (memCard.birthday != null)
                        //{
                        //    memcard.birthday = memCard.birthday;
                        //}

                    }

                    db.SaveChanges();
                    var result = new Results
                    {
                        Code = 0,
                        msg = "会员信息同步成功!"

                    };
                    return JsonConvert.SerializeObject(result);
                    ;
                }
                catch (Exception e)
                {
                    var result = new Results
                    {
                        Code = -1,
                        msg = "会员信息同步失败!"

                    };
                    return JsonConvert.SerializeObject(result);
                }
            }
        }

        public object PostNativeSQL([FromBody]Blog blog)
        {
            using (var db = new BloggingContext())
            {
               
                
                var cardno = db.Database.SqlQuery<string>("select serialno from f_get_serialno('MEM')").First();
                return cardno;
                // return JsonConvert.SerializeObject(result); ;
            }
        }


        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            using (var db = new BloggingContext())
            {
                var query = from b in db.Blogs
                    where b.BlogId == id
                    select b;
                db.Blogs.Remove(query.First());
            }
        }



    }
}