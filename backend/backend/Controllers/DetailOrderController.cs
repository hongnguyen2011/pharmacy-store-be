using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend.Controllers
{
    [Route("api/order/detail")]
    [ApiController]
    public class DetailOrderController : ControllerBase
    {
        private readonly FinalContext db;
        public DetailOrderController(FinalContext _db)
        {
            db = _db;
        }
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Detailorder>>> GetAllDetailOrder()
        {
            if (db.Detailorders == null)
            {
                return Ok(new
                {
                    message = "Dữ liệu trống!",
                    status = 404
                });
            }
            var _data = await db.Detailorders.ToListAsync();
            return Ok(new
            {
                message = "Lấy dữ liệu thành công!",
                status = 200,
                data = _data
            }); ;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Detailorder>>> GetDetailOrder(Guid id)
        {
            if (db.Detailorders == null)
            {
                return Ok(new
                {
                    message = "Dữ liệu trống!",
                    status = 404
                });
            }
            var _data = await db.Detailorders.Where(x => x.Id == id).ToListAsync();
            return Ok(new
            {
                message = "Lấy dữ liệu thành công!",
                status = 200,
                data = _data
            }); ;
        }
        [HttpPost("add")]
        public async Task<ActionResult> AddDetail([FromBody] Detailorder detail)
        {
            await db.Detailorders.AddAsync(detail);
            await db.SaveChangesAsync();
            return Ok(new
            {
                message = "Tạo thành công!",
                status = 200,
                data = detail
            });
        }
        [HttpPut("edit")]
        public async Task<ActionResult> Edit(Detailorder detail)
        {
            var _detail = await db.Detailorders.FindAsync(detail.Id);
            if (_detail == null)
            {
                return Ok(new
                {
                    message = "Dữ liệu không tồn tại!",
                    status = 400
                });
            }
            db.Entry(await db.Detailorders.FirstOrDefaultAsync(x => x.Id == _detail.Id)).CurrentValues.SetValues(detail);
            await db.SaveChangesAsync();
            return Ok(new
            {
                message = "Sửa thành công!",
                status = 200
            });
        }
        [HttpDelete("delete")]
        public async Task<ActionResult> Delete([FromBody] Guid id)
        {
            if (db.Detailorders == null)
            {
                return Ok(new
                {
                    message = "Dữ liệu trống!",
                    status = 404
                });
            }
            var _detail = await db.Detailorders.FindAsync(id);
            if (_detail == null)
            {
                return Ok(new
                {
                    message = "Dữ liệu trống!",
                    status = 404
                });
            }
            try
            {
                db.Detailorders.Remove(_detail);
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
