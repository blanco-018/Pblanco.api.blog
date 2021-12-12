using Microsoft.AspNetCore.Mvc;
using Pblanco.Api.blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pblanco.Api.blog.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostController : Controller
    {
            [HttpGet]
            public ActionResult<IEnumerable<Post>> Get()
            {
                if (Contextdb.Post.Any())
                    return Ok(Contextdb.Post);
                else
                    return NoContent();
            }

            [HttpGet("{id}")]
            public ActionResult<Post> GetId(int id)
            {
                if (Contextdb.Post.Any(p => p.Id == id))
                    return Ok(Contextdb.Post.FirstOrDefault(p => p.Id == id));
                else
                    return NoContent();
            }

            [HttpGet("title/{title}")]
            public ActionResult<Post> GetTitle(string title)
            {
                var result = new List<Post>();
                if (title.StartsWith("$") && title.EndsWith("$"))
                {
                    result = Contextdb.Post.Where(p => p.Title.ToLower().Contains(title.Replace("$", "").ToLower())).ToList();
                }
                else if (title.EndsWith("$"))
                {
                    result = Contextdb.Post.Where(p => p.Title.ToLower().StartsWith(title.Replace("$", "").ToLower())).ToList();
                }
                else if (title.StartsWith("$"))
                {
                    result = Contextdb.Post.Where(p => p.Title.ToLower().EndsWith(title.Replace("$", "").ToLower())).ToList();
                }
                else
                {
                    result = Contextdb.Post.Where(p => p.Title == title).ToList();
                }

                if (result.Any())
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound($"there´s no title on the database: {title}");
                }
            }

            [HttpGet("body/{body}")]
            public ActionResult<Post> GetBody(string body)
            {
                var result = new List<Post>();
                if (body.StartsWith("") && body.EndsWith("$"))
                {
                    result = Contextdb.Post.Where(p => p.Body.ToLower().Contains(body.Replace("$", "").ToLower())).ToList();
                }
                else if (body.EndsWith("$"))
                {
                    result = Contextdb.Post.Where(p => p.Body.ToLower().StartsWith(body.Replace("$", "").ToLower())).ToList();
                }
                else if (body.StartsWith("$"))
                {
                    result = Contextdb.Post.Where(p => p.Body.ToLower().EndsWith(body.Replace("$", "").ToLower())).ToList();
                }
                else
                {
                    result = Contextdb.Post.Where(p => p.Body == body).ToList();
                }

                if (result.Any())
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound($"there´s no body on the database: {body}");
                }
            }

            [HttpPost]
            public IActionResult Post([FromBody] Post value)
            {
                if (!Contextdb.Post.Any(p => p.Id == value.Id))
                {
                Contextdb.Post.Add(value);
                    return Ok();
                }
                else
                {
                    return BadRequest($"Exists a post with id{value.Id}");
                }
            }

            [HttpDelete("{id}")]
            public void Delete(int id)
            {
                var PostToDelete = Contextdb.Post.Single(p => p.Id == id);
            Contextdb.Post.Remove(PostToDelete);
            }

            //no funciona bien del todo
            [HttpPut("{id}")]
            public void Put(int id, [FromBody] Post value)
            {
                var PostToUpdate = Contextdb.Post.Single(p => p.Id == id);
            Contextdb.Post.Remove(PostToUpdate);
            Contextdb.Post.Add(value);
            }

        }
    }
