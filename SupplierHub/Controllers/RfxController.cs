using Microsoft.AspNetCore.Mvc;
using SupplierHub.DTOs.BidDTO;
using SupplierHub.DTOs.BidLineDTO;
using SupplierHub.DTOs.AwardDTO;
using SupplierHub.DTOs.RfxInviteDTO;
using SupplierHub.DTOs.RFxLineDTO;
using SupplierHub.DTOs.RfxEventDTO;
using SupplierHub.Services.Interface;

namespace SupplierHub.Controllers
{
	/// <summary>
	/// Controller for managing RFx (Request for eXchange) operations including events, lines, invites, bids, and awards.
	/// </summary>
	[ApiController]
	[Route("api/[controller]")]
	public class RfxController : ControllerBase
	{
		private readonly IRfxService _service;

		/// <summary>
		/// Initializes a new instance of the RfxController class.
		/// </summary>
		/// <param name="service">The RFx service instance</param>
		public RfxController(IRfxService service)
		{
			_service = service;
		}

		/// <summary>
		/// Retrieves all RFx events.
		/// </summary>
		/// <returns>List of RFx events</returns>
		[HttpGet("rfx")]
		public async Task<IActionResult> GetAllRfx()
		{
			try
			{
				var result = await _service.GetAllRfxAsync();
				return Ok(result);
			}
			catch (Exception ex)
			{
				return StatusCode(500, new
				{
					message = "An error occurred while retrieving RFx events.",
					error = ex.Message
				});
			}
		}

		/// <summary>
		/// Retrieves a specific RFx event by ID.
		/// </summary>
		/// <param name="id">The RFx event ID</param>
		/// <returns>RFx event details if found; 404 if not found</returns>
		[HttpGet("rfx/{id:long}")]
		public async Task<IActionResult> GetRfx(long id)
		{
			try
			{
				var result = await _service.GetRfxByIdAsync(id);
				return result == null ? NotFound(new { message = $"RFx event with ID {id} not found." }) : Ok(result);
			}
			catch (Exception ex)
			{
				return StatusCode(500, new
				{
					message = "An error occurred while retrieving RFx event.",
					error = ex.Message
				});
			}
		}

		/// <summary>
		/// Creates a new RFx event.
		/// </summary>
		/// <param name="dto">RFx event creation DTO</param>
		/// <returns>Created RFx event details</returns>
		[HttpPost("rfx")]
		public async Task<IActionResult> CreateRfx(RFxEventCreateDto dto)
		{
			try
			{
				var result = await _service.CreateRfxAsync(dto);
				return Ok(new { message = "RFx event created successfully.", data = result });
			}
			catch (Exception ex)
			{
				return StatusCode(500, new
				{
					message = "An error occurred while creating RFx event.",
					error = ex.Message
				});
			}
		}

		/// <summary>
		/// Updates an existing RFx event.
		/// </summary>
		/// <param name="dto">RFx event update DTO</param>
		/// <returns>Updated RFx event details if found; 404 if not found</returns>
		[HttpPut("rfx")]
		public async Task<IActionResult> UpdateRfx(RFxEventUpdateDto dto)
		{
			try
			{
				var result = await _service.UpdateRfxAsync(dto);
				return result == null ? NotFound(new { message = $"RFx event with ID {dto.RfxID} not found." }) : Ok(new { message = "RFx event updated successfully.", data = result });
			}
			catch (Exception ex)
			{
				return StatusCode(500, new
				{
					message = "An error occurred while updating RFx event.",
					error = ex.Message
				});
			}
		}

		/// <summary>
		/// Retrieves all RFx lines for a specific RFx event.
		/// </summary>
		/// <param name="rfxId">The RFx event ID</param>
		/// <returns>List of RFx lines</returns>
		[HttpGet("rfx/{rfxId:long}/lines")]
		public async Task<IActionResult> GetRfxLines(long rfxId)
		{
			try
			{
				var result = await _service.GetLinesByRfxAsync(rfxId);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return StatusCode(500, new
				{
					message = "An error occurred while retrieving RFx lines.",
					error = ex.Message
				});
			}
		}

		/// <summary>
		/// Adds a new RFx line to an RFx event.
		/// </summary>
		/// <param name="dto">RFx line creation DTO</param>
		/// <returns>Created RFx line details</returns>
		[HttpPost("rfx-lines")]
		public async Task<IActionResult> AddRfxLine(RfxLineCreateDto dto)
		{
			try
			{
				var result = await _service.AddRfxLineAsync(dto);
				return Ok(new { message = "RFx line created successfully.", data = result });
			}
			catch (Exception ex)
			{
				return StatusCode(500, new
				{
					message = "An error occurred while creating RFx line.",
					error = ex.Message
				});
			}
		}

		/// <summary>
		/// Updates an existing RFx line.
		/// </summary>
		/// <param name="dto">RFx line update DTO</param>
		/// <returns>Updated RFx line details if found; 404 if not found</returns>
		[HttpPut("rfx-lines")]
		public async Task<IActionResult> UpdateRfxLine(RfxLineUpdateDto dto)
		{
			try
			{
				var result = await _service.UpdateRfxLineAsync(dto);
				return result == null ? NotFound(new { message = $"RFx line with ID {dto.RfxLineID} not found." }) : Ok(new { message = "RFx line updated successfully.", data = result });
			}
			catch (Exception ex)
			{
				return StatusCode(500, new
				{
					message = "An error occurred while updating RFx line.",
					error = ex.Message
				});
			}
		}

		/// <summary>
		/// Retrieves all RFx invites for a specific RFx event.
		/// </summary>
		/// <param name="rfxId">The RFx event ID</param>
		/// <returns>List of RFx invites</returns>
		[HttpGet("rfx/{rfxId:long}/invites")]
		public async Task<IActionResult> GetRfxInvites(long rfxId)
		{
			try
			{
				var result = await _service.GetInvitesByRfxAsync(rfxId);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return StatusCode(500, new
				{
					message = "An error occurred while retrieving RFx invites.",
					error = ex.Message
				});
			}
		}

		/// <summary>
		/// Creates a new RFx invite for a supplier.
		/// </summary>
		/// <param name="dto">RFx invite creation DTO</param>
		/// <returns>Created RFx invite details</returns>
		[HttpPost("invites")]
		public async Task<IActionResult> AddInvite(RfxInviteCreateDto dto)
		{
			try
			{
				var result = await _service.AddInviteAsync(dto);
				return Ok(new { message = "RFx invite created successfully.", data = result });
			}
			catch (Exception ex)
			{
				return StatusCode(500, new
				{
					message = "An error occurred while creating RFx invite.",
					error = ex.Message
				});
			}
		}

		/// <summary>
		/// Updates an existing RFx invite status.
		/// </summary>
		/// <param name="dto">RFx invite update DTO</param>
		/// <returns>Updated RFx invite details if found; 404 if not found</returns>
		[HttpPut("invites")]
		public async Task<IActionResult> UpdateInvite(RfxInviteUpdateDto dto)
		{
			try
			{
				var result = await _service.UpdateInviteAsync(dto);
				return result == null ? NotFound(new { message = $"RFx invite with ID {dto.InviteID} not found." }) : Ok(new { message = "RFx invite updated successfully.", data = result });
			}
			catch (Exception ex)
			{
				return StatusCode(500, new
				{
					message = "An error occurred while updating RFx invite.",
					error = ex.Message
				});
			}
		}

		/// <summary>
		/// Retrieves all bids for a specific RFx event.
		/// </summary>
		/// <param name="rfxId">The RFx event ID</param>
		/// <returns>List of bids</returns>
		[HttpGet("rfx/{rfxId:long}/bids")]
		public async Task<IActionResult> GetBids(long rfxId)
		{
			try
			{
				var result = await _service.GetBidsByRfxAsync(rfxId);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return StatusCode(500, new
				{
					message = "An error occurred while retrieving bids.",
					error = ex.Message
				});
			}
		}

		/// <summary>
		/// Retrieves a specific bid by ID.
		/// </summary>
		/// <param name="bidId">The bid ID</param>
		/// <returns>Bid details if found; 404 if not found</returns>
		[HttpGet("bids/{bidId:long}")]
		public async Task<IActionResult> GetBid(long bidId)
		{
			try
			{
				var result = await _service.GetBidByIdAsync(bidId);
				return result == null ? NotFound(new { message = $"Bid with ID {bidId} not found." }) : Ok(result);
			}
			catch (Exception ex)
			{
				return StatusCode(500, new
				{
					message = "An error occurred while retrieving bid.",
					error = ex.Message
				});
			}
		}

		/// <summary>
		/// Creates a new bid for an RFx event.
		/// </summary>
		/// <param name="dto">Bid creation DTO</param>
		/// <returns>Created bid details</returns>
		[HttpPost("bids")]
		public async Task<IActionResult> AddBid(BidCreateDto dto)
		{
			try
			{
				var result = await _service.AddBidAsync(dto);
				return Ok(new { message = "Bid created successfully.", data = result });
			}
			catch (Exception ex)
			{
				return StatusCode(500, new
				{
					message = "An error occurred while creating bid.",
					error = ex.Message
				});
			}
		}

		/// <summary>
		/// Updates an existing bid.
		/// </summary>
		/// <param name="dto">Bid update DTO</param>
		/// <returns>Updated bid details if found; 404 if not found</returns>
		[HttpPut("bids")]
		public async Task<IActionResult> UpdateBid(BidUpdateDto dto)
		{
			try
			{
				var result = await _service.UpdateBidAsync(dto);
				return result == null ? NotFound(new { message = $"Bid with ID {dto.BidID} not found." }) : Ok(new { message = "Bid updated successfully.", data = result });
			}
			catch (Exception ex)
			{
				return StatusCode(500, new
				{
					message = "An error occurred while updating bid.",
					error = ex.Message
				});
			}
		}

		/// <summary>
		/// Retrieves all bid lines for a specific bid.
		/// </summary>
		/// <param name="bidId">The bid ID</param>
		/// <returns>List of bid lines</returns>
		[HttpGet("bids/{bidId:long}/lines")]
		public async Task<IActionResult> GetBidLines(long bidId)
		{
			try
			{
				var result = await _service.GetBidLinesByBidAsync(bidId);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return StatusCode(500, new
				{
					message = "An error occurred while retrieving bid lines.",
					error = ex.Message
				});
			}
		}

		/// <summary>
		/// Adds a new bid line to a bid.
		/// </summary>
		/// <param name="dto">Bid line creation DTO</param>
		/// <returns>Created bid line details</returns>
		[HttpPost("bid-lines")]
		public async Task<IActionResult> AddBidLine(BidLineCreateDto dto)
		{
			try
			{
				var result = await _service.AddBidLineAsync(dto);
				return Ok(new { message = "Bid line created successfully.", data = result });
			}
			catch (Exception ex)
			{
				return StatusCode(500, new
				{
					message = "An error occurred while creating bid line.",
					error = ex.Message
				});
			}
		}

		/// <summary>
		/// Updates an existing bid line.
		/// </summary>
		/// <param name="dto">Bid line update DTO</param>
		/// <returns>Updated bid line details if found; 404 if not found</returns>
		[HttpPut("bid-lines")]
		public async Task<IActionResult> UpdateBidLine(BidLineUpdateDto dto)
		{
			try
			{
				var result = await _service.UpdateBidLineAsync(dto);
				return result == null ? NotFound(new { message = $"Bid line with ID {dto.BidLineID} not found." }) : Ok(new { message = "Bid line updated successfully.", data = result });
			}
			catch (Exception ex)
			{
				return StatusCode(500, new
				{
					message = "An error occurred while updating bid line.",
					error = ex.Message
				});
			}
		}

		/// <summary>
		/// Retrieves all awards for a specific RFx event.
		/// </summary>
		/// <param name="rfxId">The RFx event ID</param>
		/// <returns>List of awards</returns>
		[HttpGet("rfx/{rfxId:long}/awards")]
		public async Task<IActionResult> GetAwards(long rfxId)
		{
			try
			{
				var result = await _service.GetAwardsByRfxAsync(rfxId);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return StatusCode(500, new
				{
					message = "An error occurred while retrieving awards.",
					error = ex.Message
				});
			}
		}

		/// <summary>
		/// Creates a new award for an RFx event.
		/// </summary>
		/// <param name="dto">Award creation DTO</param>
		/// <returns>Created award details</returns>
		[HttpPost("awards")]
		public async Task<IActionResult> AddAward(AwardCreateDto dto)
		{
			try
			{
				var result = await _service.AddAwardAsync(dto);
				return Ok(new { message = "Award created successfully.", data = result });
			}
			catch (Exception ex)
			{
				return StatusCode(500, new
				{
					message = "An error occurred while creating award.",
					error = ex.Message
				});
			}
		}

		/// <summary>
		/// Updates an existing award.
		/// </summary>
		/// <param name="dto">Award update DTO</param>
		/// <returns>Updated award details if found; 404 if not found</returns>
		[HttpPut("awards")]
		public async Task<IActionResult> UpdateAward(AwardUpdateDto dto)
		{
			try
			{
				var result = await _service.UpdateAwardAsync(dto);
				return result == null ? NotFound(new { message = $"Award with ID {dto.AwardID} not found." }) : Ok(new { message = "Award updated successfully.", data = result });
			}
			catch (Exception ex)
			{
				return StatusCode(500, new
				{
					message = "An error occurred while updating award.",
					error = ex.Message
				});
			}
		}
	}
}
