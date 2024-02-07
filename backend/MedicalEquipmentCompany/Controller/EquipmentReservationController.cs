using FluentResults;
using MedicalEquipmentCompany.Model.Dtos;
using MedicalEquipmentCompany.Model.Result;
using MedicalEquipmentCompany.Service.Base;
using MedicalEquipmentCompany.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QRCoder;

namespace MedicalEquipmentCompany.Controller
{
    [ApiController]
    [Authorize(Policy = "registredUserPolicy")]
    [Route("api/equipmentReservation")]
    public class EquipmentReservationController : BaseApiController
    {
        private readonly IEquipmentReservationService _equipmentReservationService;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly IEquipmentService _equipmentService;
        private readonly IEquipmentPickupService _equipmentPickupService;
        private readonly IAccountService _accountService;
        public EquipmentReservationController(IEquipmentReservationService equipmentReservationService, IUserService userService, IEmailService emailService, IEquipmentService equipmentService, IEquipmentPickupService equipmentPickupService, IAccountService accountService)
        {
            _equipmentReservationService = equipmentReservationService;
            _userService = userService;
            _emailService = emailService;
            _equipmentService = equipmentService;
            _equipmentPickupService = equipmentPickupService;
            _accountService = accountService;
        }

        [HttpPost]
        public ActionResult<EquipmentReservationDto> Create([FromBody] EquipmentReservationDto reservation)
        {
            var equipment = _equipmentService.Get((int)reservation.ReservedEquipment[0]);
            
            // Proverava da li je u medjuvremenu smanjen broj opreme pre rezervacije.
            if (!_equipmentService.CheckEquipmentCount((int)equipment.Value.Id, reservation.EquipmentCount[0]).Value)
            {
                return CreateResponse(Result.Fail("There's not enough equipment"));
            } 
            var pickup = _equipmentPickupService.Get((int)reservation.EquipmentPickup);
            
            // Proverava da li je u medjuvremenu rezervisan termin za preuzimanje opreme
            if (pickup.Value.IsReserved)
            {
                return CreateResponse(Result.Fail("The pickup is reserved."));
            }
            pickup.Value.IsReserved = true;
            _equipmentPickupService.UpdatePickup(pickup.Value);

            var final_result = _equipmentReservationService.Create(reservation);

            // Generate QR code with reservation information
            string reservationInfo = $"Reservation ID: {reservation.Id}\nReservation date: {reservation.ReservationDate}\nEquipment: {equipment.Value.Name}\nEquipment count: {reservation.EquipmentCount.Count}\n Price:{reservation.EquipmentCount[0] * equipment.Value.Price}\nStart Date: {pickup.Value.DateAndTime}\nStatus: {reservation.ReservationStatus}\n";
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(reservationInfo, QRCodeGenerator.ECCLevel.Q);
            BitmapByteQRCode qrCode = new BitmapByteQRCode(qrCodeData);

            // Attach the QR code image to the email
            _emailService.SendEmailWithAttachment(_userService.Get((int)reservation.UserId).Value, "Your Reservation Details", "Please find your reservation details attached.", qrCode.GetGraphic(20), "QRCode.png");

            return CreateResponse(final_result);
        }

        [HttpGet("userReservations/{userId:int}")]
        public ActionResult<PagedResult<EquipmentReservationDto>> Search(int userId)
        {
            var result = _equipmentReservationService.SearchByUserId((int)userId);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var reservation = _equipmentReservationService.Get(id);
            var pickup = _equipmentPickupService.Get((int)reservation.Value.EquipmentPickup);
            pickup.Value.IsReserved = false;
            _equipmentPickupService.UpdatePickup(pickup.Value);
            var user = _accountService.GetByUserId((int)reservation.Value.UserId);
            DateTime pickupDateTime = DateTime.Parse(pickup.Value.DateAndTime);
            TimeSpan timeDifference = pickupDateTime - DateTime.Now;
            if (timeDifference.TotalHours < 24)
            {
                user.Value.Penalties += 2;
            } else
            {
                user.Value.Penalties += 1;
            }
            _accountService.UpdatePenalties(user.Value);
            var result = _equipmentReservationService.Delete(id);
            return CreateResponse(result);
        }

    }
}