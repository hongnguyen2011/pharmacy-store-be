using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly FinalContext db;
        public CategoryController(FinalContext _db)
        {
            db = _db;
        }
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategory()
        {
            if (db.Categories == null)
            {
                return Ok(new
                {
                    message = "Dữ liệu trống!",
                    status = 404
                });
            }
            var _data = await db.Categories.ToListAsync();
            return Ok(new
            {
                message = "Lấy dữ liệu thành công!",
                status = 200,
                data = _data
            }); ;
        }
        [HttpGet, Authorize]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategory(Guid id)
        {
            if (db.Categories == null)
            {
                return Ok(new
                {
                    message = "Dữ liệu trống!",
                    status = 404
                });
            }
            var _data = await db.Categories.Where(x => x.Id == id).ToListAsync();
            return Ok(new
            {
                message = "Lấy dữ liệu thành công!",
                status = 200,
                data = _data
            }); ;
        }
        [HttpPost("add")]
        //[Authorize]
        public async Task<ActionResult> AddCategory([FromBody] Category category)
        {
            var _category = await db.Categories.Where(x=>x.Slug.Equals(category.Slug)).ToListAsync();
            if(_category.Count != 0)
            {
                return Ok(new
                {
                    message = "Tạo thất bại!",
                    status = 400,
                });
            }
            await db.Categories.AddAsync(category);
            await db.SaveChangesAsync();
            return Ok(new
            {
                message = "Tạo thành công!",
                status = 200,
                data = category
            });
        }
        [HttpPut("edit"), Authorize]

        public async Task<ActionResult> Edit([FromBody]Category category)
        {
            var _category = await db.Categories.FindAsync(category.Id);
            if (_category == null)
            {
                return Ok(new
                {
                    message = "Dữ liệu không tồn tại!",
                    status = 400
                });
            }
            db.Entry(await db.Categories.FirstOrDefaultAsync(x => x.Id == category.Id)).CurrentValues.SetValues(category);
            await db.SaveChangesAsync();
            return Ok(new
            {
                message = "Sửa thành công!",
                status = 200
            });
        }
        [HttpDelete("delete"), Authorize]

        public async Task<ActionResult> Delete([FromBody] Guid id)
        {
            if (db.Categories == null)
            {
                return Ok(new
                {
                    message = "Dữ liệu trống!",
                    status = 404
                });
            }
            var _category = await db.Categories.FindAsync(id);
            if (_category == null)
            {
                return Ok(new
                {
                    message = "Dữ liệu trống!",
                    status = 404
                });
            }
            try
            {
                db.Categories.Remove(_category);
                await db.SaveChangesAsync();
                return Ok(new
                {
                    message = "Xóa thành công!",
                    status = 200
                });
            }
            catch (Exception e)
            {
                return Ok(new
                {
                    message = "Lỗi rồi!",
                    status = 400,
                    data = e.Message
                });
            }
        }

    }
}
